import { NgModule } from '@angular/core';
import { NavigationEnd, RouteConfigLoadEnd, RouteConfigLoadStart, Router, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { AppRouteGuard } from './shared/common/auth/auth-route-guard';
import { NgxSpinnerService } from 'ngx-spinner';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: 'app',
                component: AppComponent,
                canActivate: [AppRouteGuard],
                canActivateChild: [AppRouteGuard],
                children: [
                    {
                        path: '',
                        children: [
                            { path: '', redirectTo: '/app/admin/hostDashboard', pathMatch: 'full' }
                        ]
                    },
                    {
                        path: 'admin/student',redirectTo: '/app/admin/student', pathMatch: 'full'

                    },
                    {
                        path: 'admin/building',redirectTo: '/app/admin/building', pathMatch: 'full'
                    },
                    {
                        path: 'admin/invoice',redirectTo: '/app/admin/invoice', pathMatch: 'full'
                    },
                    {
                        path: 'admin/inbill', redirectTo: '/app/admin/inbill', pathMatch: 'full'
                    },
                    {
                        path: 'admin/outbill', redirectTo: '/app/admin/outbill', pathMatch: 'full'
                    },
                    {
                        path: 'admin/contract',redirectTo: '/app/admin/contract', pathMatch: 'full'
                    },

                    {
                        path: 'admin',
                        loadChildren: () => import('app/admin/admin.module').then(m => m.AdminModule), //Lazy load admin module
                        data: { preload: true },
                        canLoad: [AppRouteGuard]
                    },
                    {
                        path:'**',
                        redirectTo: '/app/admin/hostDashboard'
                    }
                ]
            }
        ])
    ],
    exports: [RouterModule]
})

export class AppRoutingModule {
    constructor(
        private router: Router,
        private spinnerService: NgxSpinnerService
    ) {
        router.events.subscribe((event) => {

            if (event instanceof RouteConfigLoadStart) {
                spinnerService.show();
            }

            if (event instanceof RouteConfigLoadEnd) {
                spinnerService.hide();
            }

            if (event instanceof NavigationEnd) {
                document.querySelector('meta[property=og\\:url').setAttribute('content', window.location.href);
            }
        });
    }
}
