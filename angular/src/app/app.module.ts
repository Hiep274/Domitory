import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HttpClientJsonpModule } from '@angular/common/http';
import { ServiceProxyModule } from '@shared/service-proxies/service-proxy.module';
import { UtilsModule } from '@shared/utils/utils.module';
import { FileUploadModule } from 'ng2-file-upload';
import { ModalModule } from 'ngx-bootstrap/modal';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { PopoverModule } from 'ngx-bootstrap/popover';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { FileUploadModule as PrimeNgFileUploadModule } from 'primeng/fileupload';
import { PaginatorModule } from 'primeng/paginator';
import { ProgressBarModule } from 'primeng/progressbar';
import { TableModule } from 'primeng/table';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DefaultLayoutComponent } from './shared/layout/themes/default/default-layout.component';
import { AppCommonModule } from './shared/common/app-common.module';
import { FooterComponent } from './shared/layout/footer.component';
import { StackedFooterComponent } from './shared/layout/stacked-footer.component';
import { SideBarMenuComponent } from './shared/layout/nav/side-bar-menu.component';
import { TopBarMenuComponent } from './shared/layout/nav/top-bar-menu.component';
import { TopBarComponent } from './shared/layout/topbar.component';
import { DefaultBrandComponent } from './shared/layout/themes/default/default-brand.component';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { TextMaskModule } from 'angular2-text-mask';
import { ImageCropperModule } from 'ngx-image-cropper';
// Metronic
import { PerfectScrollbarModule, PERFECT_SCROLLBAR_CONFIG, PerfectScrollbarConfigInterface } from 'ngx-perfect-scrollbar';
const DEFAULT_PERFECT_SCROLLBAR_CONFIG: PerfectScrollbarConfigInterface = {
    // suppressScrollX: true
};

import { CoreModule } from '@metronic/app/core/core.module';
import { SessionTimeoutModalComponent } from './shared/common/session-timeout/session-timeout-modal-component';
import { SessionTimeoutComponent } from './shared/common/session-timeout/session-timeout.component';
import { AutoCompleteModule } from 'primeng/autocomplete';
import { MenuSearchBarComponent } from './shared/layout/nav/menu-search-bar/menu-search-bar.component';
import { NgxSpinnerModule, NgxSpinnerComponent } from 'ngx-spinner';
import { ScrollTopComponent } from './shared/layout/scroll-top.component';
import { AppBsModalModule } from '@shared/common/appBsModal/app-bs-modal.module';
import { BrowserModule } from "@angular/platform-browser";
import { NgApexchartsModule } from "@node_modules/ng-apexcharts";
import { AdminModule } from './admin/admin.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
    declarations: [
        AppComponent,
        DefaultLayoutComponent,
        SideBarMenuComponent,
        TopBarMenuComponent,
        FooterComponent,
        ScrollTopComponent,
        StackedFooterComponent,
        TopBarComponent,
        DefaultBrandComponent,
        SessionTimeoutModalComponent,
        SessionTimeoutComponent,
        MenuSearchBarComponent,
    ],
    imports: [
        CommonModule,
        FormsModule,
        HttpClientModule,
        HttpClientJsonpModule,
        ModalModule.forRoot(),
        TooltipModule.forRoot(),
        TabsModule.forRoot(),
        BsDropdownModule.forRoot(),
        PopoverModule.forRoot(),
        BsDatepickerModule.forRoot(),
        FileUploadModule,
        AppRoutingModule,
        UtilsModule,
        AppCommonModule.forRoot(),
        ServiceProxyModule,
        TableModule,
        PaginatorModule,
        PrimeNgFileUploadModule,
        ProgressBarModule,
        PerfectScrollbarModule,
        CoreModule,
        NgxChartsModule,
        TextMaskModule,
        ImageCropperModule,
        AutoCompleteModule,
        NgxSpinnerModule,
        AppBsModalModule,
        BrowserModule,
        FormsModule,
        ReactiveFormsModule,
        NgApexchartsModule,
        BrowserAnimationsModule,
        FormsModule
    ],
    providers: [
        AdminModule,
        {
            provide: PERFECT_SCROLLBAR_CONFIG,
            useValue: DEFAULT_PERFECT_SCROLLBAR_CONFIG
        }
    ],
    entryComponents: [NgxSpinnerComponent]
})
export class AppModule {

}
