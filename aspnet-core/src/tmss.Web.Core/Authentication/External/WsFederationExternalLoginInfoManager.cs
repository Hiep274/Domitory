﻿using Abp.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace tmss.Web.Authentication.External
{
    public class WsFederationExternalLoginInfoManager : DefaultExternalLoginInfoManager
    {
        public override string GetUserNameFromClaims(List<Claim> claims)
        {
            var userName = claims.First(c => c.Type == ClaimTypes.WindowsAccountName)?.Value;
            if (!userName.IsNullOrEmpty())
            {
                return userName;
            }

            return base.GetUserNameFromClaims(claims);
        }
    }
}