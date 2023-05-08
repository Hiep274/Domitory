import { ViewListStudentComponent } from './view-list-student/view-list-student.component';
import { DataFormatService } from '@app/shared/common/services/data-format.service';
import { CreateOrEditRoomComponent } from './create-or-edit-room/create-or-edit-room.component';
import { CreateOrEditBuildingComponent } from './create-or-edit-building/create-or-edit-building.component';
import { Component, Injector, ViewChild, ViewEncapsulation } from '@angular/core';
import { AppComponentBase } from "@shared/common/app-component-base";
import * as _ from "lodash";
import { AgCheckboxRendererComponent } from '@app/shared/common/grid/ag-checkbox-renderer/ag-checkbox-renderer.component';
import { CustomColDef, FrameworkComponent, GridParams } from '@app/shared/common/models/base.model';
import { BuildingForViewDto, BuildingRoomServiceProxy, RoomForViewDto } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-building-room',
  templateUrl: './building-room.component.html',
  styleUrls: ['./building-room.component.less'],
})
export class BuildingRoomComponent extends AppComponentBase {
    @ViewChild("createOrEditBuilding") createOrEditBuildingModal: CreateOrEditBuildingComponent;
    @ViewChild("createOrEditRoom") createOrEditRoomModal: CreateOrEditRoomComponent;
    @ViewChild("viewListStudent") viewListStudentModal: ViewListStudentComponent;

    defaultColDef = {
        flex: 1,
        floatingFilter: true,
        filter: 'agTextColumnFilter',
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

    // Province Table
    buildingTable: CustomColDef[];
    buildingData: any[] = [];
    selectBuildingId: number;
    buildingRowSelected: BuildingForViewDto = new BuildingForViewDto();



    // District Table
    roomTable: CustomColDef[];
    advancedFiltersAreShown: boolean = false;
    sorting: string = '';
    roomData: any[] = [];
    roomParams!: GridParams;
    selectedRoomId: number;
    isLoading: boolean = false;
    buildingParams!: GridParams;
    roomRowSelected: RoomForViewDto = new RoomForViewDto();



    constructor(
        injector: Injector,
        private _buildingRoomService: BuildingRoomServiceProxy,
        private dataFormatService: DataFormatService,
    ) {
        super(injector);
        this.buildingTable = [
            {
                headerName: this.l('Tên tòa nhà'),
                headerTooltip: this.l('Tên tòa nhà'),
                field: 'name',
                cellClass: ["text-left"],
                flex: 1
            },
            {
                headerName: this.l('Mô tả'),
                headerTooltip: this.l('Mô tả'),
                field: 'description',
                cellClass: ["text-left"],
                flex: 2
            }
        ];
        this.roomTable = [
            {
                headerName: this.l('Số phòng'),
                headerTooltip: this.l('Số phòng'),
                field: 'roomNo',
                flex: 2,
                cellClass: ["text-left"],
            },
            {
                headerName: this.l('Giá phòng'),
                headerTooltip: this.l('Giá phòng'),
                field: 'unitPrice',
                flex: 2,
                cellClass: ["text-left"],
                valueFormatter: (params) => this.dataFormatService.moneyFormat(params.value)
            },
            {
                headerName: this.l('Số lượng tối đa'),
                headerTooltip: this.l('Số lượng tối đa'),
                field: 'maxx',
                flex: 2,
                cellClass: ["text-left"],
            },
            {
                headerName: this.l('Số lượng hiện tại'),
                headerTooltip: this.l('Số lượng hiện tại'),
                field: 'amount',
                flex: 2,
                cellClass: ["text-left"],
            }
        ];
    }

    ngOnInit() {
        this.roomData = [];
        this.onGridReady();

    }




    onGridReady() {
        this.isLoading = true;
        this.getAllBuilding();
        if(this.selectBuildingId)
            this.getRoomByBuildingId();
    }

    onChangeBuildingSelection(params) {
        this.buildingRowSelected = params.api.getSelectedRows()[0];
        if (this.buildingRowSelected){
            this.selectBuildingId = this.buildingRowSelected.id;
            this.getRoomByBuildingId();
        }
        this.roomRowSelected = new RoomForViewDto();
        this.selectedRoomId = undefined;
    }

    onChangeDistrictSelection(params) {
        this.roomRowSelected = params.api.getSelectedRows()[0];
        if (this.roomRowSelected)
            this.selectedRoomId = this.roomRowSelected.id;
    }
    getAllBuilding() {
        this._buildingRoomService.getAllBuilding().subscribe(res => {
            this.buildingData = res;
        }
        );
    }

    getRoomByBuildingId(districtPaginationParams?) {
        this._buildingRoomService.getRoomByBuildingId(this.selectBuildingId).subscribe(res => {
            this.roomData = res;
        }
        );

    }
    callBackProvinceGrid(params) {
        this.selectBuildingId = undefined;
    }

    eventEnter(event) {
        if (event.keyCode === 13) {
            this.search();
        }
    }

    search() {
        this.roomData = [];
        this.selectedRoomId = undefined;
    }

    createBuilding(): void {
        this.createOrEditBuildingModal.show();
    }

    editBuilding(): void {
        this.createOrEditBuildingModal.show(this.selectBuildingId);
    }
    createRoom(): void {
        this.createOrEditRoomModal.show(this.selectBuildingId);
    }

    editRoom(): void {
        this.createOrEditRoomModal.show(this.selectBuildingId, this.selectedRoomId);
    }

    deleteBuilding(): void {
        this.message.confirm(
            this.l('Bạn có chắc chắc muốn xóa tòa nhà này!'),
            this.l('AreYouSure'),
            isConfirmed => {
                if (isConfirmed) {
                    this._buildingRoomService.deleteBuilding(this.selectBuildingId).subscribe(() => {
                        this.getAllBuilding();
                        this.notify.success(this.l('SuccessfullyDeleted'));
                    });
                }
            }
        );

    }
    deleteRoom(): void {
        this.message.confirm(
            this.l('Bạn có chắc chắc muốn xóa phòng này!'),
            this.l('AreYouSure'),
            isConfirmed => {
                if (isConfirmed) {
                    this._buildingRoomService.deleteRoom(this.selectedRoomId).subscribe(() => {
                        this.getAllBuilding();
                        this.getRoomByBuildingId();
                        this.notify.success(this.l('SuccessfullyDeleted'));
                    });
                }
            }
        );


    }
    listStudent(): void {
        this.viewListStudentModal.show(this.selectedRoomId);
    }


    exportToExcel(): void {

    }

    onChangeFilterShown() {
        this.advancedFiltersAreShown = !this.advancedFiltersAreShown;
        this.clearValueFilter();
    }

    clearValueFilter() {

    }
}
