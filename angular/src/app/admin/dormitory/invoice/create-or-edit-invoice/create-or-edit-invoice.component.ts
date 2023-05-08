import { finalize } from 'rxjs/operators';
import { CreateOrEditInvoiceDto, InvoiceServiceProxy } from './../../../../../shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { Component, OnInit, Output, ViewChild, EventEmitter, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { forEach } from 'lodash';

@Component({
  selector: 'app-create-or-edit-invoice',
  templateUrl: './create-or-edit-invoice.component.html',
  styleUrls: ['./create-or-edit-invoice.component.less']
})
export class CreateOrEditInvoiceComponent extends AppComponentBase implements OnInit {

    @ViewChild("createOrEditModal", { static: true }) modal: ModalDirective;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    invoice: CreateOrEditInvoiceDto = new CreateOrEditInvoiceDto();

    active: boolean = false;
    saving: boolean = false;
    listRoom: { value: number, label: string }[] = [];
    invId;
    constructor(
        injector: Injector,
        private _invoice :InvoiceServiceProxy

    ) {
        super(injector);
    }

    ngOnInit() {
        }
    show(invoiceId?: number): void {
        this.invId = invoiceId;
        if (!invoiceId) {
            this._invoice.getListRoomForCreate().subscribe((result) => {
                forEach(result, (item) => {
                    this.listRoom.push({ value: item.id, label: item.roomNo });
                });
            });
            this.invoice = new CreateOrEditInvoiceDto();
            this.invoice.id = invoiceId;
            this.active = true;
            this.modal.show();
        } else {
            this._invoice.getInvoiceForEdit(invoiceId)
                .subscribe((result) => {
                    this.invoice = result[0];
                    this._invoice.getListRoom().subscribe((result) => {
                        forEach(result, (item) => {
                            this.listRoom.push({ value: item.id, label: item.roomNo });
                        });
                    });
                    this.active = true;
                    this.modal.show();
                });
        }
    }

    save(): void {
        if(this.invoice.elecNew < this.invoice.elecOld||this.invoice.warNew < this.invoice.warOld){
            this.notify.error("Số điện hoặc nước mới không được nhỏ hơn số cũ");
        }
        else
        {
        this.saving = true;
        this._invoice
            .createOrEdit(this.invoice)
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
        this.listRoom = [];

    }
    onChooseRoom(roomId) {
        this.invoice.elecOld = 0;
        this.invoice.warOld = 0;
        this._invoice.getLastMonthInvoice(roomId).subscribe((result) => {
            this.invoice.elecOld = result[0].elecNew;
            this.invoice.warOld = result[0].warNew;
        });
    }
}
