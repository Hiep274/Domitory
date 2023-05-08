import { BuildingRoomServiceProxy } from '@shared/service-proxies/service-proxies';
import { CustomColDef } from '@app/shared/common/models/base.model';
import { AppComponentBase } from '@shared/common/app-component-base';
import { Component, Output, ViewChild, EventEmitter, Injector } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-view-list-student',
  templateUrl: './view-list-student.component.html',
  styleUrls: ['./view-list-student.component.less']
})
export class ViewListStudentComponent extends AppComponentBase  {
    @ViewChild("createOrEditModal", { static: true }) modal: ModalDirective;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    rowData: any[] = [];
    roomTable: CustomColDef[];
    columnDefs: CustomColDef[];
    defaultColDef = {
        flex: 1,
        floatingFilter: true,
        filter: 'agTextColumnFilter',
        resizable: true,
        sortable: true,
        isViewSideBar: false,
        floatingFilterComponentParams: { suppressFilterButton: true },
        textFormatter: function (r) {
            if (r == null) return null;
            return r.toLowerCase();
        },
    };

    buildingId;
    active: boolean = false;
    saving: boolean = false;
    constructor(
        injector: Injector,
        private _buildingRoom :BuildingRoomServiceProxy

    ) {
        super(injector);
        this.columnDefs = [
            {
                headerName: this.l('Mã sinh viên'),
                headerTooltip: this.l('Mã sinh viên'),
                field: 'studentNo',
                flex: 1.5,
                cellClass: ["text-left"],
            },
            {
                headerName: this.l('Tên sinh viên'),
                headerTooltip: this.l('Tên sinh viên'),
                field: 'name',
                flex: 2,
                cellClass: ["text-left"],
            },
            {
                headerName: this.l('Giới tính'),
                headerTooltip: this.l('Giới tính'),
                field: 'gender',
                flex: 1,
                valueGetter: (params) => params.data.gender==1 ? "Nam" : params.data.gender==2 ? "Nữ" : "Khác",
                cellClass: ["text-left"],
            },
            {
                headerName: this.l('Số cccd'),
                headerTooltip: this.l('Số cccd'),
                field: 'cmnd',
                flex: 2,
                cellClass: ["text-left"],
            },
            {
                headerName: this.l('Số điện thoại'),
                headerTooltip: this.l('Số điện thoại'),
                field: 'phone',
                flex: 2,
                cellClass: ["text-left"],
            }
        ];
    }

    ngOnInit() {

    }
    show(roomId?: number,): void {
       this._buildingRoom.getListStudentInRoom(roomId).subscribe((result) => {
            this.rowData = result;
            this.active = true;
            this.modal.show();
        }
        );
    }

    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
