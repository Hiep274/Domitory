import { Component, Injector, OnInit, ViewChild } from '@angular/core';
import { AppConsts } from '@shared/AppConsts';
import { UrlHelper } from '@shared/helpers/UrlHelper';
import * as moment from 'moment';
import { AppComponentBase } from 'shared/common/app-component-base';
@Component({
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.less']
})
export class AppComponent extends AppComponentBase implements OnInit {

    theme: string;
    installationMode = true;


    @ViewChild('chatBarComponent') chatBarComponent;
    isQuickThemeSelectEnabled: boolean = this.setting.getBoolean('App.UserManagement.IsQuickThemeSelectEnabled');
    IsSessionTimeOutEnabled: boolean = this.setting.getBoolean('App.UserManagement.SessionTimeOut.IsEnabled') && this.appSession.userId != null;

    public constructor(
        injector: Injector,
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this.theme = abp.setting.get('App.UiManagement.Theme').toLocaleLowerCase();
        this.installationMode = UrlHelper.isInstallUrl(location.href);

        this.registerModalOpenEvents();


    }

    subscriptionStatusBarVisible(): boolean {
        return this.appSession.tenantId > 0 &&
            (this.appSession.tenant.isInTrialPeriod ||
                this.subscriptionIsExpiringSoon());
    }

    subscriptionIsExpiringSoon(): boolean {
        if (this.appSession.tenant.subscriptionEndDateUtc) {
            return moment().utc().add(AppConsts.subscriptionExpireNootifyDayCount, 'days') >= moment(this.appSession.tenant.subscriptionEndDateUtc);
        }

        return false;
    }

    registerModalOpenEvents(): void {

    }

    getRecentlyLinkedUsers(): void {
        abp.event.trigger('app.getRecentlyLinkedUsers');
    }

    onMySettingsModalSaved(): void {
        abp.event.trigger('app.onMySettingsModalSaved');
    }
}
