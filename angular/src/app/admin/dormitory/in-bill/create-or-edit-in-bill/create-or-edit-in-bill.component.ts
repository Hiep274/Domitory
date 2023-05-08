import { CreateOrEditInBillDto, InBillServiceProxy } from './../../../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { Component, OnInit, Output, ViewChild, EventEmitter, Injector } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { forEach } from 'lodash';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-create-or-edit-in-bill',
  templateUrl: './create-or-edit-in-bill.component.html',
  styleUrls: ['./create-or-edit-in-bill.component.less']
})
export class CreateOrEditInBillComponent extends AppComponentBase implements OnInit {

    @ViewChild("createOrEditModal", { static: true }) modal: ModalDirective;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    inbill: CreateOrEditInBillDto = new CreateOrEditInBillDto();

    active: boolean = false;
    saving: boolean = false;
    listRoom: { value: number, label: string }[] = [];
    constructor(
        injector: Injector,
        private _inBill :InBillServiceProxy

    ) {
        super(injector);
    }

    ngOnInit() {

        }
    show(inBillId?: number): void {
        this._inBill.getListRoom().subscribe((result) => {
            forEach(result, (item) => {
                this.listRoom.push({ value: item.id, label: item.roomNo });
            });
        });
        if (!inBillId) {
            this.inbill = new CreateOrEditInBillDto();
            this.inbill.id = inBillId;
            this.active = true;
            this.modal.show();
        } else {
            this._inBill.getInBillForEdit(inBillId)
                .subscribe((result) => {
                    this.inbill = result[0];
                    this.active = true;
                    this.modal.show();
                });
        }
    }

    save(): void {
        this.saving = true;
        this._inBill
            .createOrEdit(this.inbill)
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

    close(): void {
        this.active = false;
        this.listRoom = [];
        this.modal.hide();
    }
}
