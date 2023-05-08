import { Injector, Component, OnInit, ViewEncapsulation } from '@angular/core';
import { AbpMultiTenancyService, AbpSessionService } from 'abp-ng2-module';
import { AppAuthService } from '@app/shared/common/auth/app-auth.service';
import { AppConsts } from '@shared/AppConsts';
import { ThemesLayoutBaseComponent } from '@app/shared/layout/themes/themes-layout-base.component';
import * as _ from 'lodash';
import { IpServiceService } from '@app/shared/common/services/ip-service.service';
import { forkJoin } from 'rxjs';
import { LocalStorageService } from '@shared/utils/local-storage.service';
@Component({
    templateUrl: './topbar.component.html',
    selector: 'topbar',
    encapsulation: ViewEncapsulation.None
})
export class TopBarComponent extends ThemesLayoutBaseComponent implements OnInit {

    isHost = false;
    languages: abp.localization.ILanguageInfo[];
    currentLanguage: abp.localization.ILanguageInfo;
    isImpersonatedLogin = false;
    isMultiTenancyEnabled = false;
    shownLoginName = '';
    tenancyName = '';
    userName = '';
    profilePicture = AppConsts.appBaseUrl + '/assets/common/images/default-profile-picture.png';
    defaultLogo = AppConsts.appBaseUrl + '/assets/common/images/app-logo-on-' + this.currentTheme.baseSettings.menu.asideSkin + '.svg';
    unreadChatMessageCount = 0;
    remoteServiceBaseUrl: string = AppConsts.remoteServiceBaseUrl;
    chatConnected = false;
    isQuickThemeSelectEnabled: boolean = this.setting.getBoolean('App.UserManagement.IsQuickThemeSelectEnabled');

    constructor(
        injector: Injector,
        private _abpSessionService: AbpSessionService,
        private _abpMultiTenancyService: AbpMultiTenancyService,
        private _authService: AppAuthService,
        private _ipServiceService: IpServiceService,
        private _localStorageService: LocalStorageService,
    ) {
        super(injector);
    }

    ngOnInit() {

        this.isHost = !this._abpSessionService.tenantId;
        this.isMultiTenancyEnabled = this._abpMultiTenancyService.isEnabled;
        this.languages = _.filter(this.localization.languages, l => (l).isDisabled === false);
        this.currentLanguage = this.localization.currentLanguage;
        this.isImpersonatedLogin = this._abpSessionService.impersonatorUserId > 0;
        this.setCurrentLoginInformations();

        this.registerToEvents();
        console.log("Đã nhảy vào Topbar");

    }



    registerToEvents() {


        abp.event.on('app.chat.unreadMessageCountChanged', messageCount => {
            this.unreadChatMessageCount = messageCount;
        });

        abp.event.on('app.chat.connected', () => {
            this.chatConnected = true;
        });


        abp.event.on('app.onMySettingsModalSaved', () => {
            this.onMySettingsModalSaved();
        });
    }



    setCurrentLoginInformations(): void {
        this.shownLoginName = this.appSession.getShownLoginName();
        this.tenancyName = this.appSession.tenancyName;
        this.userName = this.appSession.user.userName;
    }








    showLoginAttempts(): void {
        abp.event.trigger('app.show.loginAttemptsModal');
    }



    showUserDelegations(): void {
        abp.event.trigger('app.show.userDelegationsModal');
    }

    changePassword(): void {
        abp.event.trigger('app.show.changePasswordModal');
    }

    changeProfilePicture(): void {
        abp.event.trigger('app.show.changeProfilePictureModal');
    }

    changeMySettings(): void {
        abp.event.trigger('app.show.mySettingsModal');
    }

    logout(): void {
        this._authService.logout();
    }

    onMySettingsModalSaved(): void {
        this.shownLoginName = this.appSession.getShownLoginName();
    }



}
