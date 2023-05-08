import { CreateOrEditOutBillDto, OutBillServiceProxy } from './../../../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { Component, OnInit, Output, ViewChild, EventEmitter, Injector } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-create-or-edit-out-bill',
  templateUrl: './create-or-edit-out-bill.component.html',
  styleUrls: ['./create-or-edit-out-bill.component.less']
})
export class CreateOrEditOutBillComponent extends AppComponentBase implements OnInit {

    @ViewChild("createOrEditModal", { static: true }) modal: ModalDirective;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    outbill: CreateOrEditOutBillDto = new CreateOrEditOutBillDto();

    active: boolean = false;
    saving: boolean = false;
    constructor(
        injector: Injector,
        private _outBill :OutBillServiceProxy

    ) {
        super(injector);
    }
    ngOnInit() {
        }
    show(outBillId?: number): void {
        if (!outBillId) {
            this.outbill = new CreateOrEditOutBillDto();
            this.outbill.id = outBillId;
            this.active = true;
            this.modal.show();
        } else {
            this._outBill.getOutBillForEdit(outBillId)
                .subscribe((result) => {
                    this.outbill = result[0];

                    this.active = true;
                    this.modal.show();
                });
        }
    }
    save(): void {
        this.saving = true;
        this._outBill
            .createOrEdit(this.outbill)
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
        this.modal.hide();
    }
}
