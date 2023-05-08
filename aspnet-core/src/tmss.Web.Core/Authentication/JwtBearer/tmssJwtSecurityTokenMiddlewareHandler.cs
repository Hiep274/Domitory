using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Abp;
using Abp.UI;
using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.Runtime.Caching;
using Abp.Threading;
using Abp.Runtime.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using tmss.Authorization.Users;
using tmss.Authorization;
using tmss.Authorization.Delegation;

namespace tmss.Web.Authentication.JwtBearer
{
    public class tmssJwtSecurityTokenMiddlewareHandler
    {
        private readonly RequestDelegate _next;
        private readonly JwtSecurityTokenHandler _tokenHandler;
        private readonly IJwtSecurityStampHandler _jwtSecurityStampHandler;
        private readonly ICacheManager _cacheManager;
        private readonly TokenAuthConfiguration _tokenAuthConfiguration;
        private readonly PermissionChecker _permissionChecker;
        private readonly IUserDelegationConfiguration _userDelegationConfiguration;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly UserManager _userManager;

        public tmssJwtSecurityTokenMiddlewareHandler(RequestDelegate next, IJwtSecurityStampHandler jwtSecurityStampHandler,
            ICacheManager cacheManager, TokenAuthConfiguration tokenAuthConfiguration,  PermissionChecker permissionChecker,
            IUserDelegationConfiguration userDelegationConfiguration, IUnitOfWorkManager unitOfWork, UserManager userManager)
        {
            _next = next;
            _tokenHandler = new JwtSecurityTokenHandler();
            _jwtSecurityStampHandler = jwtSecurityStampHandler;
            _cacheManager = cacheManager;
            _tokenAuthConfiguration = tokenAuthConfiguration;
            _permissionChecker = permissionChecker;
            _userDelegationConfiguration = userDelegationConfiguration;
            _unitOfWorkManager = unitOfWork;
            _userManager = userManager;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token != null)
            {
                try
                {
                    var key = Encoding.ASCII.GetBytes("tmss_8CFB2EC534E14D56");

                    var principal = _tokenHandler.ValidateToken(token,
                        new TokenValidationParameters
                        {
                            // The signing key must match!
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(key),

                            // Validate the JWT Issuer (iss) claim
                            ValidateIssuer = true,
                            ValidIssuer = "tmss",

                            // Validate the JWT Audience (aud) claim
                            ValidateAudience = true,
                            ValidAudience = "tmss",

                            // Validate the token expiry
                            ValidateLifetime = true,

                            //If you want to allow a certain amount of clock drift,
                            //set that here
                            ClockSkew = TimeSpan.Zero
                        }
                        , out SecurityToken validatedToken);

                    if (!HasAccessTokenType(principal))
                    {
                        throw new SecurityTokenException("invalid token type");
                    }

                    await ValidateSecurityStampAsync(principal);

                    var tokenValidityKeyClaim = principal.Claims.First(c => c.Type == AppConsts.TokenValidityKey);
                    var caches = _cacheManager.GetAllCaches();
                    var keyCache = caches.FirstOrDefault(e => e.Name == AppConsts.TokenValidityKey);
                    if (keyCache != null)
                    {
                        var compareValue = await keyCache.GetAsync(tokenValidityKeyClaim.Value, null);
                        if (compareValue == null)
                        {
                            var userIdentifierString = principal.Claims.First(c => c.Type == AppConsts.UserIdentifier);
                            var userIdentifier = UserIdentifier.Parse(userIdentifierString.Value);

                            var validateTokenKeyAsyncResult =
                                await ValidateTokenValidityKeyAsync(tokenValidityKeyClaim, userIdentifier);
                            if (!validateTokenKeyAsyncResult)
                            {
                                throw new SecurityTokenException("invalid");
                            }

                            await _cacheManager
                                .GetCache(AppConsts.TokenValidityKey)
                                .SetAsync(tokenValidityKeyClaim.Value, "",
                                    absoluteExpireTime: _tokenAuthConfiguration.AccessTokenExpiration);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            await _next(context);
        }

        private async Task ValidateSecurityStampAsync(ClaimsPrincipal principal)
        {
            await ValidateUserDelegationAsync(principal);

            if (!await _jwtSecurityStampHandler.Validate(principal))
            {
                throw new SecurityTokenException("invalid");
            }
        }

        private static bool HasAccessTokenType(ClaimsPrincipal principal)
        {
            return principal.Claims.FirstOrDefault(x => x.Type == AppConsts.TokenType)?.Value ==
                   TokenType.AccessToken.To<int>().ToString();
        }

        private async Task ValidateUserDelegationAsync(ClaimsPrincipal principal)
        {
            if (!_userDelegationConfiguration.IsEnabled)
            {
                return;
            }

            var impersonatorTenant = principal.Claims.FirstOrDefault(c => c.Type == AbpClaimTypes.ImpersonatorTenantId);
            var user = principal.Claims.FirstOrDefault(c => c.Type == AbpClaimTypes.UserId);
            var impersonatorUser = principal.Claims.FirstOrDefault(c => c.Type == AbpClaimTypes.ImpersonatorUserId);

            if (impersonatorUser == null || user == null)
            {
                return;
            }

            var impersonatorTenantId = impersonatorTenant == null ? null : impersonatorTenant.Value.IsNullOrEmpty() ? (int?)null : Convert.ToInt32(impersonatorTenant.Value);
            var sourceUserId = Convert.ToInt64(user.Value);
            var impersonatorUserId = Convert.ToInt64(impersonatorUser.Value);

            if (await _permissionChecker.IsGrantedAsync(new UserIdentifier(impersonatorTenantId, impersonatorUserId), AppPermissions.Pages_Administration_Users_Impersonation))
            {
                return;
            }

        }

        private async Task<bool> ValidateTokenValidityKeyAsync(Claim tokenValidityKeyClaim, UserIdentifier userIdentifier)
        {
            bool isValid;

            using var uow = _unitOfWorkManager.Begin();
            using (_unitOfWorkManager.Current.SetTenantId((userIdentifier.TenantId)))
            {
                var user = await _userManager.GetUserAsync(userIdentifier);
                isValid = await _userManager.IsTokenValidityKeyValidAsync(user, tokenValidityKeyClaim.Value);
                await uow.CompleteAsync();
            }
            return isValid;
        }
    }
}
