import { Injector } from '@angular/core';
import { AppConsts } from '@shared/AppConsts';
import { AppComponentBase } from '@shared/common/app-component-base';
import { TenantLoginInfoDto } from '@shared/service-proxies/service-proxies';
import * as moment from 'moment';
import { ToggleOptions } from '@metronic/app/core/_base/layout/directives/toggle.directive';

export class ThemesLayoutBaseComponent extends AppComponentBase {

    tenant: TenantLoginInfoDto = new TenantLoginInfoDto();
    installationMode = true;

    defaultLogo = AppConsts.appBaseUrl + '/assets/common/images/HUCE.png';

    userMenuToggleOptions: ToggleOptions = {
        target: 'body',
        targetState: 'kt-header__topbar--mobile-on',
        togglerState: 'kt-header-mobile__toolbar-topbar-toggler--active'
    };

    constructor(
        injector: Injector
    ) {
        super(injector);
    }

    subscriptionStatusBarVisible(): boolean {
        return this.appSession.tenantId > 0 && (this.appSession.tenant.isInTrialPeriod || this.subscriptionIsExpiringSoon());
    }

    subscriptionIsExpiringSoon(): boolean {
        if (this.appSession.tenant.subscriptionEndDateUtc) {
            return moment().utc().add(AppConsts.subscriptionExpireNootifyDayCount, 'days') >= moment(this.appSession.tenant.subscriptionEndDateUtc);
        }

        return false;
    }

    getSubscriptionExpiringDayCount(): number {
        if (!this.appSession.tenant.subscriptionEndDateUtc) {
            return 0;
        }

        return Math.round(moment.utc(this.appSession.tenant.subscriptionEndDateUtc).diff(moment().utc(), 'days', true));
    }



    getExpireNotification(localizationKey: string): string {
        return this.l(localizationKey, this.getSubscriptionExpiringDayCount());
    }
}
