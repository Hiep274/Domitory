import { forEach } from 'lodash';
import { finalize } from 'rxjs/operators';
import { BuildingRoomServiceProxy } from './../../../../../shared/service-proxies/service-proxies';
import { Component, OnInit, Output, ViewChild, EventEmitter, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { CreateOrEditBuildingDto } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-create-or-edit-building',
  templateUrl: './create-or-edit-building.component.html',
  styleUrls: ['./create-or-edit-building.component.less']
})
export class CreateOrEditBuildingComponent extends AppComponentBase {

    @ViewChild("createOrEditModal", { static: true }) modal: ModalDirective;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    building: CreateOrEditBuildingDto = new CreateOrEditBuildingDto();
    listBuidlingName = [];
    bldId;

    active: boolean = false;
    saving: boolean = false;
    constructor(
        injector: Injector,
        private _buildingRoom :BuildingRoomServiceProxy

    ) {
        super(injector);
    }

    ngOnInit() {
    }

    show(buildingId?: number): void {
        this.bldId = buildingId;
        if (!buildingId) {
            this.building = new CreateOrEditBuildingDto();
            this.building.id = buildingId;
            this.active = true;
            this.modal.show();
        } else {
            this._buildingRoom.getBuildingForEdit(buildingId)
                .subscribe((result) => {
                    this.building = result[0];
                    this.active = true;
                    this.modal.show();
                });
        }
    }

    save(): void {
        if(this.bldId==null){
            this._buildingRoom.getBuildingName().subscribe(res => {
                forEach(res, (item) => {
                    if(item.name === this.building.name){
                        this.notify.error("Tên tòa nhà đã tồn tại");
                        return;
                    }
                });
            });
        }else{
        this.saving = true;
        this._buildingRoom
            .createOrEditBuilding(this.building)
            .pipe(
                finalize(() => {
                    this.saving = false;
                })
            )
            .subscribe(() => {
                this.notify.info(this.l("SavedSuccessfully"));
                this.close();
                this.modalSave.emit(null);
            });
        }
    }

    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
