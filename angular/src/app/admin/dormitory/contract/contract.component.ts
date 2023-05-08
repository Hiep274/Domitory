import { forEach } from 'lodash';
import { DataFormatService } from '@app/shared/common/services/data-format.service';
import { ContractForViewDto, ContractServiceProxy } from './../../../../shared/service-proxies/service-proxies';
import { AgCheckboxRendererComponent } from '@app/shared/common/grid/ag-checkbox-renderer/ag-checkbox-renderer.component';
import { FrameworkComponent, CustomColDef, GridParams, PaginationParamsModel } from '@app/shared/common/models/base.model';
import { CreateOrEditContractComponent } from './create-or-edit-contract/create-or-edit-contract.component';
import { AppComponentBase } from '@shared/common/app-component-base';
import { Component, OnInit, ViewChild, Injector } from '@angular/core';
import * as moment from 'moment';

@Component({
  selector: 'app-contract',
  templateUrl: './contract.component.html',
  styleUrls: ['./contract.component.less']
})
export class ContractComponent extends AppComponentBase implements OnInit {
    @ViewChild("createOrEditContract") createOrEditContractModal: CreateOrEditContractComponent;

    defaultColDef = {
        floatingFilter: true,
        flex:false,
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
    listRoom: { value: number, label: string  }[] = [];

    sorting: string = "";
    advancedFiltersAreShown: boolean = false;
    columnDefs: CustomColDef[];
    params: GridParams;
    paginationParams: PaginationParamsModel;
    selectedRow: ContractForViewDto = new ContractForViewDto();

    isLoading: boolean = false;
    totalPages: number = 0;
    maxResultCount: number = 20;
    rowData: any[] = [];
    selectContractId: number;
    skipCount: number = 0;
    listGender: { id: number; name: string }[] = [
        { id: 1, name: "Nam" },
        { id: 2, name: "Nữ" },
        { id: 3, name: "Khác" }
    ];

    listStatus: { value: boolean, label: string }[] = [
        { value: true, label: "Đã thanh toán" },
        { value: false, label: "Chưa thanh toán" }
    ];

    constructor(
        injector: Injector,
        private _contract :ContractServiceProxy,
        private dataFormatService: DataFormatService,
    ) {
        super(injector);

        this.columnDefs = [
            {
                headerName: this.l("Số hợp đồng"),
                headerTooltip: this.l("Số hợp đồng"),
                field: "contractNo",
                cellClass: ["text-left"],
                width: 170,
            },
            {
                headerName: this.l("Mã sinh viên"),
                headerTooltip: this.l("Mã sinh viên"),
                field: "studentNo",
                cellClass: ["text-left"],
                width: 110,
            },
            {
                headerName: this.l("Tên sinh viên"),
                headerTooltip: this.l("Tên sinh viên"),
                field: "studentName",
                cellClass: ["text-left"],
                width: 160,
            },
            {
                headerName: this.l("Giới tính"),
                headerTooltip: this.l("Giới tính"),
                field: "gender",
                cellClass: ["text-left"],
                valueGetter: (params) => params.data.gender == 1 ? "Nam" : params.data.gender == 2 ? "Nữ" : "Khác",
                width: 80,
            },
            {
                headerName: this.l("Số điện thoại"),
                headerTooltip: this.l("Số điện thoại"),
                field: "phone",
                cellClass: ["text-left"],
                width: 150,
            },
            {
                headerName: this.l("Tên phòng"),
                headerTooltip: this.l("Tên phòng"),
                field: "roomNo",
                cellClass: ["text-left"],
                width: 120,
            },
            {
                headerName: this.l("Giá phòng"),
                headerTooltip: this.l("Giá phòng"),
                field: "unitPrice",
                cellClass: ["text-left"],
                width: 100,
            },
            {
                headerName: this.l("Ngày lập hợp đồng"),
                headerTooltip: this.l("Ngay lập hợp đồng"),
                field: "contractDate",
                cellClass: ["text-left"],
                width: 120,
                valueFormatter: (params) => this.dataFormatService.dateFormat(params.value),
            },
            {
                headerName: this.l("Ngày bắt đầu"),
                headerTooltip: this.l("Ngày bắt đầu"),
                field: "startDate",
                cellClass: ["text-left"],
                valueFormatter: (params) => this.dataFormatService.dateFormat(params.value),
                width: 110,
            },
            {
                headerName: this.l("Ngày kết thúc"),
                headerTooltip: this.l("Ngày kết thúc"),
                field: "endDate",
                cellClass: ["text-left"],
                valueFormatter: (params) => this.dataFormatService.dateFormat(params.value),
                width: 110,
            },
           ];
    }

    ngOnInit() {
        this.paginationParams = { pageNum: 1, pageSize: 20, totalCount: 0 };
        this._contract.getListRoom().subscribe(res => {
            forEach(res, (item) => {
                this.listRoom.push({ value: item.id, label: item.roomNo });
            });
        });
        this.onGridReady(this.paginationParams);
    }



    onGridReady(paginationParams) {
        this._contract.getAll(
            this.filterRoom,
            this.startDate,
            this.endDate,
        ).subscribe((res) => {
            this.rowData = res;
        });
        this.selectContractId = undefined;
    }
    onChangeSelection(params) {
        this.selectedRow = params.api.getSelectedRows()[0];
        if (this.selectedRow)
            this.selectContractId = this.selectedRow.id;
    }

    callBackProvinceGrid(params) {
        this.params = params;
        this.params.api.paginationSetPageSize(
            this.paginationParams.pageSize
        );
        this.onGridReady(this.paginationParams);
        this.selectContractId = undefined;
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
        this.selectContractId = undefined;
    }

    createMstGenProvinces(): void {
         this.createOrEditContractModal.show();
    }

    editMstGenProvinces(): void {
         this.createOrEditContractModal.show(this.selectContractId);
    }

    deleteMstGenProvinces(): void {
        this.message.confirm(
            this.l('Bạn có chắc chắc muốn xóa hợp đồng này!'),
            this.l('AreYouSure'),
            isConfirmed => {
                if (isConfirmed) {
                    this._contract.delete(this.selectContractId).subscribe(() => {
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
        this.startDate= moment().add(-1, 'year').startOf('month');
        this.endDate= moment();
        this.onGridReady(this.paginationParams);

    }


}
