import { Component, Injector, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { accountModuleAnimation } from '@shared/animations/routerTransition';
import { LoginService } from './login.service';
import { ReCaptchaV3Service } from 'ngx-captcha';
import { AppConsts } from '@shared/AppConsts';

@Component({
  selector: 'app-session-lock-screen',
  templateUrl: './session-lock-screen.component.html',
  animations: [accountModuleAnimation()]
})
export class SessionLockScreenComponent extends AppComponentBase {
  recaptchaSiteKey: string = AppConsts.recaptchaSiteKey;

  userInfo: any;
  captchaResponse?: string;
  submitting = false;

  constructor(
    injector: Injector,
    private _reCaptchaV3Service: ReCaptchaV3Service,
    public loginService: LoginService) {
    super(injector);
    this.getLastUserInfo();
  }

  getLastUserInfo(): void {
    let cookie = abp.utils.getCookieValue('userInfo');
    if (!cookie) {
      location.href = '';
    }

    let userInfo = JSON.parse(cookie);
    if (!userInfo) {
      location.href = '';
    }
    this.loginService.authenticateModel.userNameOrEmailAddress = userInfo.userName;
    this.userInfo = {
      userName: userInfo.userName,
      tenant: userInfo.tenant,
      profilePicture: ''
    };
  }

  login(): void {
    let recaptchaCallback = () => {
      this.showMainSpinner();

      this.submitting = true;
      this.loginService.authenticate(
        () => {
          this.submitting = false;
          this.hideMainSpinner();
        },
        null,
        this.captchaResponse
      );

    };

    if (this.useCaptcha) {
      this._reCaptchaV3Service.execute(this.recaptchaSiteKey, 'login', (token) => {
        this.captchaResponse = token;
        recaptchaCallback();
      });
    } else {
      recaptchaCallback();
    }
  }

  get useCaptcha(): boolean {
    return this.setting.getBoolean('App.UserManagement.UseCaptchaOnLogin');
  }
}
