using Abp;
using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.IdentityFramework;
using Abp.Localization;
using Abp.MultiTenancy;
using Abp.Notifications;
using Abp.Runtime.Security;
using Abp.Runtime.Session;
using Abp.UI;
using Microsoft.AspNetCore.Identity;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using tmss.Authorization.Users;
using tmss.Editions;
using tmss.MultiTenancy.Demo;
using tmss.MultiTenancy.Payments;

namespace tmss.MultiTenancy
{
    /// <summary>
    /// Tenant manager.
    /// </summary>
    public class TenantManager : AbpTenantManager<Tenant, User>
    {
        public IAbpSession AbpSession { get; set; }

        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly UserManager _userManager;
        private readonly TenantDemoDataBuilder _demoDataBuilder;
        private readonly IAbpZeroDbMigrator _abpZeroDbMigrator;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IRepository<SubscribableEdition> _subscribableEditionRepository;

        public TenantManager(
            IRepository<Tenant> tenantRepository,
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository,
            EditionManager editionManager,
            IUnitOfWorkManager unitOfWorkManager,
            TenantDemoDataBuilder demoDataBuilder,
            UserManager userManager,
            INotificationSubscriptionManager notificationSubscriptionManager,
            IAbpZeroFeatureValueStore featureValueStore,
            IAbpZeroDbMigrator abpZeroDbMigrator,
            IPasswordHasher<User> passwordHasher,
            IRepository<SubscribableEdition> subscribableEditionRepository) : base(
                tenantRepository,
                tenantFeatureRepository,
                editionManager,
                featureValueStore
            )
        {
            AbpSession = NullAbpSession.Instance;

            _unitOfWorkManager = unitOfWorkManager;
            _demoDataBuilder = demoDataBuilder;
            _userManager = userManager;
            _abpZeroDbMigrator = abpZeroDbMigrator;
            _passwordHasher = passwordHasher;
            _subscribableEditionRepository = subscribableEditionRepository;
        }

      

        public async Task CheckEditionAsync(int? editionId, bool isInTrialPeriod)
        {
            if (!editionId.HasValue || !isInTrialPeriod)
            {
                return;
            }

            var edition = await _subscribableEditionRepository.GetAsync(editionId.Value);
            if (!edition.IsFree)
            {
                return;
            }

            var error = LocalizationManager.GetSource(tmssConsts.LocalizationSourceName).GetString("FreeEditionsCannotHaveTrialVersions");
            throw new UserFriendlyException(error);
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }

        public decimal GetUpgradePrice(SubscribableEdition currentEdition, SubscribableEdition targetEdition, int totalRemainingHourCount, PaymentPeriodType paymentPeriodType)
        {
            int numberOfHoursPerDay = 24;

            var totalRemainingDayCount = totalRemainingHourCount / numberOfHoursPerDay;
            var unusedPeriodCount = totalRemainingDayCount / (int)paymentPeriodType;
            var unusedHoursCount = totalRemainingHourCount % ((int)paymentPeriodType * numberOfHoursPerDay);

            decimal currentEditionPriceForUnusedPeriod = 0;
            decimal targetEditionPriceForUnusedPeriod = 0;

            var currentEditionPrice = currentEdition.GetPaymentAmount(paymentPeriodType);
            var targetEditionPrice = targetEdition.GetPaymentAmount(paymentPeriodType);

            if (currentEditionPrice > 0)
            {
                currentEditionPriceForUnusedPeriod = currentEditionPrice * unusedPeriodCount;
                currentEditionPriceForUnusedPeriod += (currentEditionPrice / (int)paymentPeriodType) / numberOfHoursPerDay * unusedHoursCount;
            }

            if (targetEditionPrice > 0)
            {
                targetEditionPriceForUnusedPeriod = targetEditionPrice * unusedPeriodCount;
                targetEditionPriceForUnusedPeriod += (targetEditionPrice / (int)paymentPeriodType) / numberOfHoursPerDay * unusedHoursCount;
            }

            return targetEditionPriceForUnusedPeriod - currentEditionPriceForUnusedPeriod;
        }

        public async Task<Tenant> UpdateTenantAsync(int tenantId, bool isActive, bool? isInTrialPeriod, PaymentPeriodType? paymentPeriodType, int editionId, EditionPaymentType editionPaymentType)
        {
            var tenant = await FindByIdAsync(tenantId);

            tenant.IsActive = isActive;

            if (isInTrialPeriod.HasValue)
            {
                tenant.IsInTrialPeriod = isInTrialPeriod.Value;
            }

            tenant.EditionId = editionId;

            if (paymentPeriodType.HasValue)
            {
                tenant.UpdateSubscriptionDateForPayment(paymentPeriodType.Value, editionPaymentType);
            }

            return tenant;
        }

        public async Task<EndSubscriptionResult> EndSubscriptionAsync(Tenant tenant, SubscribableEdition edition, DateTime nowUtc)
        {
            if (tenant.EditionId == null || tenant.HasUnlimitedTimeSubscription())
            {
                throw new Exception($"Can not end tenant {tenant.TenancyName} subscription for {edition.DisplayName} tenant has unlimited time subscription!");
            }

            Debug.Assert(tenant.SubscriptionEndDateUtc != null, "tenant.SubscriptionEndDateUtc != null");

            var subscriptionEndDateUtc = tenant.SubscriptionEndDateUtc.Value;
            if (!tenant.IsInTrialPeriod)
            {
                subscriptionEndDateUtc = tenant.SubscriptionEndDateUtc.Value.AddDays(edition.WaitingDayAfterExpire ?? 0);
            }

            if (subscriptionEndDateUtc >= nowUtc)
            {
                throw new Exception($"Can not end tenant {tenant.TenancyName} subscription for {edition.DisplayName} since subscription has not expired yet!");
            }

            if (!tenant.IsInTrialPeriod && edition.ExpiringEditionId.HasValue)
            {
                tenant.EditionId = edition.ExpiringEditionId.Value;
                tenant.SubscriptionEndDateUtc = null;

                await UpdateAsync(tenant);

                return EndSubscriptionResult.AssignedToAnotherEdition;
            }

            tenant.IsActive = false;
            tenant.IsInTrialPeriod = false;

            await UpdateAsync(tenant);

            return EndSubscriptionResult.TenantSetInActive;
        }

        public override Task UpdateAsync(Tenant tenant)
        {
            if (tenant.IsInTrialPeriod && !tenant.SubscriptionEndDateUtc.HasValue)
            {
                throw new UserFriendlyException(LocalizationManager.GetString(tmssConsts.LocalizationSourceName, "TrialWithoutEndDateErrorMessage"));
            }

            return base.UpdateAsync(tenant);
        }
    }
}
