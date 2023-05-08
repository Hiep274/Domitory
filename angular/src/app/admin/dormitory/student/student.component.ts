import { CreateOrEditStudentComponent } from './create-or-edit-student/create-or-edit-student.component';
import { AppComponentBase } from '@shared/common/app-component-base';
import { CustomColDef, PaginationParamsModel, GridParams } from './../../../shared/common/models/base.model';
import { StudentServiceProxy, StudentForViewDto } from './../../../../shared/service-proxies/service-proxies';
import { Component, Injector, OnInit, ViewChild } from '@angular/core';
import { AgCheckboxRendererComponent } from '@app/shared/common/grid/ag-checkbox-renderer/ag-checkbox-renderer.component';
import { FrameworkComponent } from '@app/shared/common/models/base.model';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.less']
})
export class StudentComponent extends AppComponentBase implements OnInit {
    @ViewChild("createOrEditStudent") createOrEditStudentModal: CreateOrEditStudentComponent;

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

    filterText: string = "";
    nameFilter: string = "";
    noFilter: string = "";
    statusFilter: boolean;
    phoneFilter: string = "";
    genderFilter: number;
    cmndFilter: string = "";

    sorting: string = "";
    advancedFiltersAreShown: boolean = false;
    columnDefs: CustomColDef[];
    params: GridParams;
    paginationParams: PaginationParamsModel;
    selectedRow: StudentForViewDto = new StudentForViewDto();

    isLoading: boolean = false;
    totalPages: number = 0;
    maxResultCount: number = 20;
    rowData: any[] = [];
    selectStudentId: number;
    listInsurance = [];
    listServiceLocation= [];
    skipCount: number = 0;
    listGender: { value: number, label: string }[] = [
        { value: 1, label: "Nam" },
        { value: 2, label: "Nữ" },
        { value: 3, label: "Khác"}
    ];
    listStatus: { value: boolean, label: string }[] = [
        { value: true, label: "Đã có phòng" },
        { value: false, label: "Chưa có phòng" }
    ];
    constructor(
        injector: Injector,
        private _student :StudentServiceProxy
    ) {
        super(injector);
        this.columnDefs = [
            {
                headerName: this.l("Tên"),
                headerTooltip: this.l("Tên"),
                field: "name",
                cellClass: ["text-left"],
                flex: 3,
            },
            {
                headerName: this.l("Mã sinh viên"),
                headerTooltip: this.l("Mã sinh viên"),
                field: "studentNo",
                cellClass: ["text-right"],
                flex: 2,
            },

            {
                headerName: this.l("Giới tính"),
                headerTooltip: this.l("Giới tính"),
                field: "gender",
                cellClass: ["text-right"],
                valueGetter: (params) => params.data.gender==1 ? "Nam" : params.data.gender==2 ? "Nữ" : "Khác",
                flex: 1.5,
            },
            {
                headerName: this.l("Số điện thoại"),
                headerTooltip: this.l("Số điện thoại"),
                field: "phone",
                cellClass: ["text-right"],
                flex: 2.5,
            },
            {
                headerName: this.l("Số CMND"),
                headerTooltip: this.l("Số CMND"),
                field: "cmnd",
                cellClass: ["text-right"],
                flex:3 ,

            },
            {
                headerName: this.l("Trạng thái"),
                headerTooltip: this.l("Trạng thái"),
                field: "isRoom",
                cellClass: ["text-left"],
                valueGetter: (params) => params.data.isRoom ? "Đã có phòng" : "Chưa có phòng",
                flex: 2.5,
            },
           ];
    }

    ngOnInit() {
        this.paginationParams = { pageNum: 1, pageSize: 20, totalCount: 0 };
        this.onGridReady(this.paginationParams);
    }



    onGridReady(paginationParams) {
        this._student.getAll(
            this.nameFilter,
            this.noFilter,
            this.genderFilter,
            this.cmndFilter,
            this.phoneFilter,
            this.statusFilter,

        ).subscribe((res) => {
            this.rowData = res;
        });
        this.selectStudentId = undefined;
    }
    onChangeSelection(params) {
        this.selectedRow = params.api.getSelectedRows()[0];
        if (this.selectedRow)
            this.selectStudentId = this.selectedRow.id;
    }

    callBackProvinceGrid(params) {
        this.params = params;
        this.params.api.paginationSetPageSize(
            this.paginationParams.pageSize
        );
        this.onGridReady(this.paginationParams);
        this.selectStudentId = undefined;
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
        this.selectStudentId = undefined;
    }

    createMstGenProvinces(): void {
        this.createOrEditStudentModal.show();
    }

    editMstGenProvinces(): void {
        this.createOrEditStudentModal.show(this.selectStudentId);
    }

    deleteMstGenProvinces(): void {
        this.message.confirm(
            this.l('Bạn có chắc chắc muốn xóa sinh viên này!'),
            this.l('AreYouSure'),
            isConfirmed => {
                if (isConfirmed) {
                    this._student.delete(this.selectStudentId).subscribe(() => {
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
        this.filterText = "";
        this.nameFilter = "";
        this.statusFilter = undefined;
        this.phoneFilter = "";
        this.genderFilter = undefined;
        this.noFilter = undefined;
        this.cmndFilter = "";
        this.onGridReady(this.paginationParams);

    }
}

