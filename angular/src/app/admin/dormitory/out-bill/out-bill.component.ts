import { DataFormatService } from '@app/shared/common/services/data-format.service';
import { OutBillForViewDto, OutBillServiceProxy } from './../../../../shared/service-proxies/service-proxies';
import { AgCheckboxRendererComponent } from '@app/shared/common/grid/ag-checkbox-renderer/ag-checkbox-renderer.component';
import { FrameworkComponent, CustomColDef, GridParams, PaginationParamsModel } from '@app/shared/common/models/base.model';
import { CreateOrEditOutBillComponent } from './create-or-edit-out-bill/create-or-edit-out-bill.component';
import { AppComponentBase } from '@shared/common/app-component-base';
import { Component, OnInit, ViewChild, Injector } from '@angular/core';
import * as moment from 'moment';

@Component({
  selector: 'app-out-bill',
  templateUrl: './out-bill.component.html',
  styleUrls: ['./out-bill.component.less']
})
export class OutBillComponent extends AppComponentBase implements OnInit {
    @ViewChild("createOrEditOutBill") createOrEditOutBillModal: CreateOrEditOutBillComponent;

    defaultColDef = {
        floatingFilter: true,
        filter: "agTextColumnFilter",
        resizable: true,
        sortable: true,
        isViewSideBar: true,
        floatingFilterComponentParams: { suppressFilterButton: true },
        textFormatter: function (r) {
            if (r == null) return null;
            return r.toLowerCase();
        },
    };

    frameworkComponents: FrameworkComponent = {
        agCheckboxRendererComponent: AgCheckboxRendererComponent
    };

    startDate= moment().add(-1, 'year').startOf('month');
    endDate= moment();

    sorting: string = "";
    advancedFiltersAreShown: boolean = false;
    columnDefs: CustomColDef[];
    params: GridParams;
    paginationParams: PaginationParamsModel;
    selectedRow: OutBillForViewDto = new OutBillForViewDto();

    isLoading: boolean = false;
    totalPages: number = 0;
    maxResultCount: number = 20;
    rowData: any[] = [];
    selectOutBillId: number;
    listInsurance = [];
    listServiceLocation= [];
    skipCount: number = 0;

    listStatus: { value: boolean, label: string }[] = [
        { value: true, label: "Đã thanh toán" },
        { value: false, label: "Chưa thanh toán" }
    ];
    constructor(
        injector: Injector,
        private _outBill :OutBillServiceProxy,
        private dataFormatService: DataFormatService,
    ) {
        super(injector);
        this.columnDefs = [
            {
                headerName: this.l("Số tiền chi tiêu"),
                headerTooltip: this.l("Số tiền chi tiêu"),
                field: "cost",
                cellClass: ["text-right"],
                valueFormatter: (params) => this.dataFormatService.moneyFormat(params.value),
                flex: 1,
            },

            {
                headerName: this.l("Ngày chi tiêu"),
                headerTooltip: this.l("Ngày chi tiêu"),
                field: "date",
                cellClass: ["text-left"],
                valueFormatter: (params) => this.dataFormatService.dateFormat(params.value),
                flex: 1,
            },
            {
                headerName: this.l("Mô tả mục đích/ lý do chi tiêu"),
                headerTooltip: this.l("Mô tả mục đích/ lý do chi tiêu"),
                field: "description",
                cellClass: ["text-left"],
                flex: 4,
            }
           ];
    }

    ngOnInit() {
        this.paginationParams = { pageNum: 1, pageSize: 20, totalCount: 0 };
        this.onGridReady(this.paginationParams);
    }



    onGridReady(paginationParams) {
        this._outBill.getAll(
            this.startDate,
            this.endDate,
        ).subscribe((res) => {
            this.rowData = res;
        });
        this.selectOutBillId = undefined;
    }
    onChangeSelection(params) {
        this.selectedRow = params.api.getSelectedRows()[0];
        if (this.selectedRow)
            this.selectOutBillId = this.selectedRow.id;
    }

    callBackProvinceGrid(params) {
        this.params = params;
        this.params.api.paginationSetPageSize(
            this.paginationParams.pageSize
        );
        this.onGridReady(this.paginationParams);
        this.selectOutBillId = undefined;
    }

    changePage(paginationParams: PaginationParamsModel) {
        this.paginationParams = paginationParams;
        this.paginationParams.skipCount =
            (paginationParams.pageNum - 1) * paginationParams.pageSize;
        this.maxResultCount = paginationParams.pageSize;


    }

    eventEnter(event) {
        if (event.keyCode === 13) {
            this.search();
        }
    }

    search() {
        this.onGridReady(this.paginationParams);
        this.selectOutBillId = undefined;
    }

    createMstGenProvinces(): void {
         this.createOrEditOutBillModal.show();
    }

    editMstGenProvinces(): void {
         this.createOrEditOutBillModal.show(this.selectOutBillId);
    }

    deleteMstGenProvinces(): void {
        this.message.confirm(
            this.l('Bạn có chắc chắc muốn xóa phiếu thu này!'),
            this.l('AreYouSure'),
            isConfirmed => {
                if (isConfirmed) {
                    this._outBill.delete(this.selectOutBillId).subscribe(() => {
                        this.onGridReady(this.paginationParams);
                        this.notify.success(this.l('SuccessfullyDeleted'));
                    });
                }
            }
        );


    }


    onChangeFilterShown() {
        this.advancedFiltersAreShown = !this.advancedFiltersAreShown;
        this.clearValueFilter();
    }

    clearValueFilter() {
        this.startDate= moment().add(-1,'year').startOf('month');
        this.endDate= moment().endOf('month');
        this.onGridReady(this.paginationParams);

    }
}
