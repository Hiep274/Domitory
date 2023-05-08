import { forEach } from 'lodash';
import { DataFormatService } from '@app/shared/common/services/data-format.service';
import { InBillForViewDto, InBillServiceProxy } from './../../../../shared/service-proxies/service-proxies';
import { AgCheckboxRendererComponent } from '@app/shared/common/grid/ag-checkbox-renderer/ag-checkbox-renderer.component';
import { FrameworkComponent, CustomColDef, GridParams, PaginationParamsModel } from '@app/shared/common/models/base.model';
import { CreateOrEditInBillComponent } from './create-or-edit-in-bill/create-or-edit-in-bill.component';
import { AppComponentBase } from '@shared/common/app-component-base';
import { Component, OnInit, ViewChild, Injector } from '@angular/core';
import * as moment from 'moment';

@Component({
  selector: 'app-in-bill',
  templateUrl: './in-bill.component.html',
  styleUrls: ['./in-bill.component.less']
})
export class InBillComponent extends AppComponentBase implements OnInit {
    @ViewChild("createOrEditInBill") createOrEditInBillModal: CreateOrEditInBillComponent;

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

    filterRoom: number;
    startDate= moment().add(-1, 'year').startOf('month');
    endDate= moment();
    filterIsPaid: boolean = undefined;

    sorting: string = "";
    advancedFiltersAreShown: boolean = false;
    columnDefs: CustomColDef[];
    params: GridParams;
    paginationParams: PaginationParamsModel;
    selectedRow: InBillForViewDto = new InBillForViewDto();

    isLoading: boolean = false;
    totalPages: number = 0;
    maxResultCount: number = 20;
    rowData: any[] = [];
    selectInBillId: number;
    listInsurance = [];
    listServiceLocation= [];
    skipCount: number = 0;

    listStatus: { value: boolean, label: string }[] = [
        { value: true, label: "Đã thanh toán" },
        { value: false, label: "Chưa thanh toán" }
    ];
    listRoom: { value: number, label: string  }[] = [];
    constructor(
        injector: Injector,
        private _inBill :InBillServiceProxy,
        private dataFormatService: DataFormatService,
    ) {
        super(injector);
        this.columnDefs = [
            {
                headerName: this.l("Số phòng"),
                headerTooltip: this.l("Số phòng"),
                field: "roomNo",
                cellClass: ["text-left"],
                flex: 2,
            },
            {
                headerName: this.l("Lý do thu"),
                headerTooltip: this.l("Lý do thu"),
                field: "reason",
                cellClass: ["text-left"],
                flex: 3,
            },

            {
                headerName: this.l("Ngày lập hóa đơn"),
                headerTooltip: this.l("Ngày lập hoá đơn"),
                field: "date",
                cellClass: ["text-center"],
                valueFormatter: (params) => this.dataFormatService.dateFormat(params.value),
                flex: 2,
            },
            {
                headerName: this.l("Số tiền thu"),
                headerTooltip: this.l("Số tiền thu"),
                field: "cost",
                cellClass: ["text-right"],
                valueFormatter: (params) => this.dataFormatService.moneyFormat(params.value),
                flex: 2,
            },
            {
                headerName: this.l("Trạng thái thanh toán"),
                headerTooltip: this.l("Trạng thái thanh toán"),
                field: "isPaid",
                cellClass: ["text-left"],
                valueGetter: (params) => params.data.isPaid ? "Đã thanh toán" : "Chưa thanh toán",
                flex: 2,
            }
           ];
    }

    ngOnInit() {
        this.paginationParams = { pageNum: 1, pageSize: 20, totalCount: 0 };
        this._inBill.getListRoom().subscribe(res => {
            forEach(res, (item) => {
                this.listRoom.push({ value: item.id, label: item.roomNo });
            }
            );
        })
        this.onGridReady(this.paginationParams);
    }



    onGridReady(paginationParams) {
        this._inBill.getAll(
            this.filterRoom,
            this.startDate,
            this.endDate,
            this.filterIsPaid,
        ).subscribe((res) => {
            this.rowData = res;
        });
        this.selectInBillId = undefined;
    }
    onChangeSelection(params) {
        this.selectedRow = params.api.getSelectedRows()[0];
        if (this.selectedRow)
            this.selectInBillId = this.selectedRow.id;
    }

    callBackProvinceGrid(params) {
        this.params = params;
        this.params.api.paginationSetPageSize(
            this.paginationParams.pageSize
        );
        this.onGridReady(this.paginationParams);
        this.selectInBillId = undefined;
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
        this.selectInBillId = undefined;
    }

    createMstGenProvinces(): void {
         this.createOrEditInBillModal.show();
    }

    editMstGenProvinces(): void {
         this.createOrEditInBillModal.show(this.selectInBillId);
    }

    deleteMstGenProvinces(): void {
        this.message.confirm(
            this.l('Bạn có chắc chắc muốn xóa phiếu thu này!'),
            this.l('AreYouSure'),
            isConfirmed => {
                if (isConfirmed) {
                    this._inBill.delete(this.selectInBillId).subscribe(() => {
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
        this.filterRoom = undefined;
        this.startDate= moment().add(-1,'year').startOf('month');
        this.endDate= moment().endOf('month');
        this.filterIsPaid = undefined;
        this.onGridReady(this.paginationParams);

    }
}
