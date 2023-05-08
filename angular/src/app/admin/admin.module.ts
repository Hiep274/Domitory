import {CommonModule} from '@angular/common';
import {NgModule} from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {AppCommonModule} from '@app/shared/common/app-common.module';
import {UtilsModule} from '@shared/utils/utils.module';
import {FileUploadModule} from 'ng2-file-upload';
import {ModalModule} from 'ngx-bootstrap/modal';
import {PopoverModule} from 'ngx-bootstrap/popover';
import {TabsModule} from 'ngx-bootstrap/tabs';
import {TooltipModule} from 'ngx-bootstrap/tooltip';
import {BsDropdownModule} from 'ngx-bootstrap/dropdown';
import {
    BsDatepickerConfig,
    BsDaterangepickerConfig,
    BsLocaleService,
} from 'ngx-bootstrap/datepicker';
import {BsDatepickerModule} from 'ngx-bootstrap/datepicker';
import {AutoCompleteModule} from 'primeng/autocomplete';
import {EditorModule} from 'primeng/editor';
import {FileUploadModule as PrimeNgFileUploadModule} from 'primeng/fileupload';
import {InputMaskModule} from 'primeng/inputmask';
import {PaginatorModule} from 'primeng/paginator';
import {TableModule} from 'primeng/table';
import {TreeModule} from 'primeng/tree';
import {DragDropModule} from 'primeng/dragdrop';
import {TreeDragDropService} from 'primeng/api';
import {ContextMenuModule} from 'primeng/contextmenu';
import {AdminRoutingModule} from './admin-routing.module';
import {HostDashboardComponent} from './dashboard/host-dashboard.component';
import {NgxChartsModule} from '@swimlane/ngx-charts';
import {CountoModule} from 'angular2-counto';
import {TextMaskModule} from 'angular2-text-mask';
import {ImageCropperModule} from 'ngx-image-cropper';
import {NgxBootstrapDatePickerConfigService} from 'assets/ngx-bootstrap/ngx-bootstrap-datepicker-config.service';
import {DropdownModule} from 'primeng/dropdown';

// Metronic
import {
    PerfectScrollbarModule,
    PERFECT_SCROLLBAR_CONFIG,
    PerfectScrollbarConfigInterface,
} from 'ngx-perfect-scrollbar';
import {AppBsModalModule} from '@shared/common/appBsModal/app-bs-modal.module';
import {PaginationModule} from '@node_modules/ngx-bootstrap/pagination';
import {MatTabsModule} from '@angular/material/tabs';
import {MatIconModule} from '@angular/material/icon';
import {MatCardModule} from '@angular/material/card';
import {NgApexchartsModule} from '@node_modules/ng-apexcharts';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatTableModule} from '@angular/material/table';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatSelectModule} from '@angular/material/select';
import { DataFormatService } from '@app/shared/common/services/data-format.service';

const DEFAULT_PERFECT_SCROLLBAR_CONFIG: PerfectScrollbarConfigInterface = {
    // suppressScrollX: true
};

@NgModule({
    imports: [
        FormsModule,
        ReactiveFormsModule,
        CommonModule,
        FileUploadModule,
        ModalModule.forRoot(),
        TabsModule.forRoot(),
        TooltipModule.forRoot(),
        PopoverModule.forRoot(),
        BsDropdownModule.forRoot(),
        BsDatepickerModule.forRoot(),
        AdminRoutingModule,
        UtilsModule,
        AppCommonModule,
        TableModule,
        TreeModule,
        DragDropModule,
        ContextMenuModule,
        PaginatorModule,
        PrimeNgFileUploadModule,
        AutoCompleteModule,
        EditorModule,
        InputMaskModule,
        NgxChartsModule,
        CountoModule,
        TextMaskModule,
        ImageCropperModule,
        PerfectScrollbarModule,
        DropdownModule,
        AppBsModalModule,
        PaginationModule,
        PaginationModule.forRoot(),
        MatTabsModule,
        MatIconModule,
        MatCardModule,
        NgApexchartsModule,
        MatPaginatorModule,
        MatTableModule,
        MatCheckboxModule,
        MatFormFieldModule,
        MatInputModule,
        MatSelectModule
    ],
    declarations: [
        HostDashboardComponent,
    ],
    exports: [],
    providers: [
        DataFormatService,
        TreeDragDropService,
        {
            provide: BsDatepickerConfig,
            useFactory: NgxBootstrapDatePickerConfigService.getDatepickerConfig,
        },
        {
            provide: BsDaterangepickerConfig,
            useFactory:
            NgxBootstrapDatePickerConfigService.getDaterangepickerConfig,
        },
        {
            provide: BsLocaleService,
            useFactory: NgxBootstrapDatePickerConfigService.getDatepickerLocale,
        },
        {
            provide: PERFECT_SCROLLBAR_CONFIG,
            useValue: DEFAULT_PERFECT_SCROLLBAR_CONFIG,
        },
    ],
})
export class AdminModule {
}
