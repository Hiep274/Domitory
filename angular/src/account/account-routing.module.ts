import { NgModule } from '@angular/core';
import { NavigationEnd, Router, RouterModule } from '@angular/router';
import { AppUiCustomizationService } from '@shared/common/ui/app-ui-customization.service';
import { AccountComponent } from './account.component';
import { AccountRouteGuard } from './auth/account-route-guard';
import { LoginComponent } from './login/login.component';
import { SendTwoFactorCodeComponent } from './login/send-two-factor-code.component';
import { ValidateTwoFactorCodeComponent } from './login/validate-two-factor-code.component';
import { SessionLockScreenComponent } from './login/session-lock-screen.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                component: AccountComponent,
                children: [
                    { path: '', redirectTo: 'login' },
                    { path: 'login', component: LoginComponent, canActivate: [AccountRouteGuard] },
                    { path: 'send-code', component: SendTwoFactorCodeComponent, canActivate: [AccountRouteGuard] },
                    { path: 'verify-code', component: ValidateTwoFactorCodeComponent, canActivate: [AccountRouteGuard] },

                    { path: 'session-locked', component: SessionLockScreenComponent },

                    { path: '**', redirectTo: 'login' }
                ]
            }
        ])
    ],
    exports: [
        RouterModule
    ]
})
export class AccountRoutingModule {
    constructor(
        private router: Router,
        private _uiCustomizationService: AppUiCustomizationService
    ) {
        router.events.subscribe((event: NavigationEnd) => {
            setTimeout(() => {
                this.toggleBodyCssClass(event.url);
            }, 0);
        });
    }

    toggleBodyCssClass(url: string): void {
        if (!url) {
            this.setAccountModuleBodyClassInternal();
            return;
        }

        if (url.indexOf('/account/') >= 0) {
            this.setAccountModuleBodyClassInternal();
        } else {
            document.body.className = this._uiCustomizationService.getAppModuleBodyClass();
        }
    }

    setAccountModuleBodyClassInternal(): void {
        let currentBodyClass = document.body.className;

        let classesToRemember = '';

        if (currentBodyClass.indexOf('swal2-toast-shown') >= 0) {
            classesToRemember += ' swal2-toast-shown';
        }

        document.body.className = this._uiCustomizationService.getAccountModuleBodyClass() + ' ' + classesToRemember;
    }
}
