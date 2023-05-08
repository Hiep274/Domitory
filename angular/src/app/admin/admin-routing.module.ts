import { ContractComponent } from './dormitory/contract/contract.component';
import { OutBillComponent } from './dormitory/out-bill/out-bill.component';
import { InBillComponent } from './dormitory/in-bill/in-bill.component';
import { InvoiceComponent } from './dormitory/invoice/invoice.component';
import { BuildingRoomComponent } from './dormitory/building-room/building-room.component';
import { StudentComponent } from './dormitory/student/student.component';
import {NgModule} from '@angular/core';
import {NavigationEnd, Router, RouterModule} from '@angular/router';
import {HostDashboardComponent} from './dashboard/host-dashboard.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                children: [
                    {
                        path: 'hostDashboard',
                        component: HostDashboardComponent,
                        data: {
                            permission: 'Pages.Administration.Host.Dashboard',
                        },
                    },
                    {path: '**', redirectTo: 'hostDashboard'},
                ],
            },
            {
                path: 'student',
                component: StudentComponent,
                loadChildren: () => import('app/admin/dormitory/student/student.module').then(m => m.StudentModule), //Lazy load admin module
            },
            {
                path: 'building',
                component: BuildingRoomComponent,
                loadChildren: () => import('app/admin/dormitory/building-room/building-room.module').then(m => m.BuildingRoomModule), //Lazy load admin module
            },
            {
                path: 'invoice',
                component: InvoiceComponent,
                loadChildren: () => import('app/admin/dormitory/invoice/invoice.module').then(m => m.InvoiceModule), //Lazy load admin module
            },
            {
                path: 'inbill',
                component: InBillComponent,
                loadChildren: () => import('app/admin/dormitory/in-bill/in-bill.module').then(m => m.InBillModule), //Lazy load admin module
            },
            {
                path: 'outbill',
                component: OutBillComponent,
                loadChildren: () => import('app/admin/dormitory/out-bill/out-bill.module').then(m => m.OutBillModule), //Lazy load admin module
            },
            {
                path: 'contract',
                component: ContractComponent,
                loadChildren: () => import('app/admin/dormitory/contract/contract.module').then(m => m.ContractModule), //Lazy load admin module
            },
        ]),
    ],
    exports: [RouterModule],
})
export class AdminRoutingModule {
    constructor(private router: Router) {
        router.events.subscribe((event) => {
            if (event instanceof NavigationEnd) {
                window.scroll(0, 0);
            }
        });
    }
}
