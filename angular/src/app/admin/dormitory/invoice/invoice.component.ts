import { forEach } from 'lodash';
import { CreateOrEditInvoiceComponent } from './create-or-edit-invoice/create-or-edit-invoice.component';
import { DataFormatService } from '@app/shared/common/services/data-format.service';
import { InvoiceForViewDto, InvoiceServiceProxy } from './../../../../shared/service-proxies/service-proxies';
import { AgCheckboxRendererComponent } from '@app/shared/common/grid/ag-checkbox-renderer/ag-checkbox-renderer.component';
import { FrameworkComponent, CustomColDef, GridParams, PaginationParamsModel } from '@app/shared/common/models/base.model';
import { AppComponentBase } from '@shared/common/app-component-base';
import { Component, OnInit, Injector, ViewChild } from '@angular/core';
import * as moment from 'moment';

@Component({
  selector: 'app-invoice',
  templateUrl: './invoice.component.html',
  styleUrls: ['./invoice.component.less']
})
export class InvoiceComponent extends AppComponentBase implements OnInit {
    @ViewChild("createOrEditInvoice") createOrEditInvoiceModal: CreateOrEditInvoiceComponent;

    defaultColDef = {
        floatingFilter: true,
        flex:2,
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


    advancedFiltersAreShown: boolean = false;
    columnDefs: CustomColDef[];
    params: GridParams;
    paginationParams: PaginationParamsModel;
    selectedRow: InvoiceForViewDto = new InvoiceForViewDto();

    isLoading: boolean = false;
    rowData: any[] = [];
    selectInvoiceId: number;
    skipCount: number = 0;

    listStatus: { value: boolean, label: string }[] = [
        { value: true, label: "Đã thanh toán" },
        { value: false, label: "Chưa thanh toán" }
    ];
    listRoom: { value: number, label: string  }[] = [];

    constructor(
        injector: Injector,
        private _invoice :InvoiceServiceProxy,
        private dataFormatService: DataFormatService,
    ) {
        super(injector);
        this.columnDefs = [
            {
                headerName: this.l("Số phòng"),
                headerTooltip: this.l("Số phòng"),
                field: "roomNo",
                cellClass: ["text-left"],
                width: 120,
            },
            {
                headerName: this.l("Số điện cũ"),
                headerTooltip: this.l("Số điện cũ"),
                field: "elecOld",
                cellClass: ["text-right"],
                valueFormatter: (params) => this.dataFormatService.moneyFormat(params.value),
                width: 100,
            },

            {
                headerName: this.l("Số điện mới"),
                headerTooltip: this.l("Số điện mới"),
                field: "elecNew",
                cellClass: ["text-right"],
                valueFormatter: (params) => this.dataFormatService.moneyFormat(params.value),
                width: 100,
            },
            {
                headerName: this.l("Số nước cũ"),
                headerTooltip: this.l("Số nước mới"),
                field: "warOld",
                cellClass: ["text-right"],
                valueFormatter: (params) => this.dataFormatService.moneyFormat(params.value),
                width: 100,
            },
            {
                headerName: this.l("Số nước mới"),
                headerTooltip: this.l("Số nước mới"),
                field: "warNew",
                cellClass: ["text-right"],
                valueFormatter: (params) => this.dataFormatService.moneyFormat(params.value),
                width: 100,
            },
            {
                headerName: this.l("Đơn giá điện"),
                headerTooltip: this.l("Đơn giá điện"),
                field: "elecUnit",
                cellClass: ["text-right"],
                valueFormatter: (params) => this.dataFormatService.moneyFormat(params.value),
                width: 100,
            },
            {
                headerName: this.l("Đơn giá nước"),
                headerTooltip: this.l("Đơn giá nước"),
                field: "warUnit",
                cellClass: ["text-right"],
                valueFormatter: (params) => this.dataFormatService.moneyFormat(params.value),
                width: 100,
            },
            {
                headerName: this.l("Tháng"),
                headerTooltip: this.l("Tháng"),
                field: "month",
                cellClass: ["text-center"],
                width: 70,
                valueFormatter: (params) => this.dataFormatService.monthFormat(params.value),
            },
            {
                headerName: this.l("TT thanh toán"),
                headerTooltip: this.l("TT thanh toán"),
                field: "isPaid",
                valueGetter: (params) => params.data.isPaid ? "Đã thanh toán" : "Chưa thanh toán",
                cellClass: ["text-left"],
                width: 110,
            },
           ];
    }

    ngOnInit() {
        this.paginationParams = { pageNum: 1, pageSize: 20, totalCount: 0 };
        this._invoice.getListRoom().subscribe(res => {
            forEach(res, (item) => {
                this.listRoom.push({ value: item.id, label: item.roomNo });
            }
            );
        })
        this.onGridReady(this.paginationParams);
    }



    onGridReady(paginationParams) {
        this._invoice.getAll(
            this.filterRoom,
            this.startDate,
            this.endDate,
            this.filterIsPaid,
        ).subscribe((res) => {
            this.rowData = res;
        });
        this.selectInvoiceId = undefined;
    }
    onChangeSelection(params) {
        this.selectedRow = params.api.getSelectedRows()[0];
        if (this.selectedRow)
            this.selectInvoiceId = this.selectedRow.id;
    }

    callBackProvinceGrid(params) {
        this.params = params;
        this.params.api.paginationSetPageSize(
            this.paginationParams.pageSize
        );
        this.onGridReady(this.paginationParams);
        this.selectInvoiceId = undefined;
    }

    changePage(paginationParams: PaginationParamsModel) {

    }

    eventEnter(event) {
        if (event.keyCode === 13) {
            this.search();
        }
    }

    search() {
        this.onGridReady(this.paginationParams);
        this.selectInvoiceId = undefined;
    }

    createMstGenProvinces(): void {
         this.createOrEditInvoiceModal.show();
    }

    editMstGenProvinces(): void {
         this.createOrEditInvoiceModal.show(this.selectInvoiceId);
    }

    deleteMstGenProvinces(): void {
        this.message.confirm(
            this.l('Bạn có chắc chắc muốn xóa hóa đơn này!'),
            this.l('AreYouSure'),
            isConfirmed => {
                if (isConfirmed) {
                    this._invoice.delete(this.selectInvoiceId).subscribe(() => {
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
