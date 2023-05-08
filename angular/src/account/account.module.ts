import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { HttpClientModule, HttpClientJsonpModule } from '@angular/common/http';
import { tmssCommonModule } from '@shared/common/common.module';
import { FormsModule } from '@angular/forms';
import { ServiceProxyModule } from '@shared/service-proxies/service-proxy.module';
import { UtilsModule } from '@shared/utils/utils.module';
import { NgxCaptchaModule } from 'ngx-captcha';
import { ModalModule } from 'ngx-bootstrap/modal';
import { AccountRoutingModule } from './account-routing.module';
import { AccountComponent } from './account.component';
import { AccountRouteGuard } from './auth/account-route-guard';
import { LanguageSwitchComponent } from './language-switch.component';
import { LoginComponent } from './login/login.component';
import { LoginService } from './login/login.service';
import { SendTwoFactorCodeComponent } from './login/send-two-factor-code.component';
import { ValidateTwoFactorCodeComponent } from './login/validate-two-factor-code.component';
import { OAuthModule } from 'angular-oauth2-oidc';
import { LocaleMappingService } from '@shared/locale-mapping.service';
import { PasswordModule } from 'primeng/password';
import { SessionLockScreenComponent } from './login/session-lock-screen.component';
import { AppBsModalModule } from '@shared/common/appBsModal/app-bs-modal.module';

export function getRecaptchaLanguage(): string {
    return new LocaleMappingService().map('recaptcha', abp.localization.currentLanguage.name);
}

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        HttpClientModule,
        HttpClientJsonpModule,
        NgxCaptchaModule,
        ModalModule.forRoot(),
        tmssCommonModule,
        UtilsModule,
        ServiceProxyModule,
        AccountRoutingModule,
        OAuthModule.forRoot(),
        PasswordModule,
        AppBsModalModule
    ],
    declarations: [
        AccountComponent,
        LoginComponent,
        SendTwoFactorCodeComponent,
        ValidateTwoFactorCodeComponent,
        LanguageSwitchComponent,
        SessionLockScreenComponent
    ],
    providers: [
        LoginService,
        AccountRouteGuard
    ]
})
export class AccountModule {

}
