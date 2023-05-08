import { DataFormatService } from '@app/shared/common/services/data-format.service';
import { CustomColDef } from '@app/shared/common/models/base.model';
import { CreateOrEditContractDto, ContractServiceProxy, ListRoomDto, ListStudentDto } from './../../../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { Component, OnInit, Output, ViewChild, EventEmitter, Injector } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { forEach } from 'lodash';
import { finalize } from 'rxjs/operators';
import * as moment from 'moment';

@Component({
  selector: 'app-create-or-edit-contract',
  templateUrl: './create-or-edit-contract.component.html',
  styleUrls: ['./create-or-edit-contract.component.less']
})
export class CreateOrEditContractComponent extends AppComponentBase implements OnInit {

    @ViewChild("createOrEditModal", { static: true }) modal: ModalDirective;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    contract: CreateOrEditContractDto = new CreateOrEditContractDto();
    newDate;
    active: boolean = false;
    contractColdef: CustomColDef[];
    roomColdef: CustomColDef[];
    saving: boolean = false;
    choseStudent : string = 'Chọn sinh viên';
    choseRoom : string = 'Chọn phòng';
    defaultColDef = {
        floatingFilter: true,
        flex:false,
        filter: "agTextColumnFilter",
        resizable: false,
        sortable: true,
        isViewSideBar: false,
        floatingFilterComponentParams: { suppressFilterButton: true },
        textFormatter: function (r) {
            if (r == null) return null;
            return r.toLowerCase();
        },
    };
    listRoom: { value: number, label: string ,price: number }[] = [];
    listStudent:ListStudentDto[] = [];
    listRoomCreate:ListRoomDto[] = [];
    listStudentEdit:{ value: number, label: string }[] = [];
    constructor(
        injector: Injector,
        private dataFormatService: DataFormatService,
        private _contract :ContractServiceProxy,

    ) {
        super(injector);
        this.contractColdef = [
            {
                headerName: 'Tên sinh viên',
                headerTooltip: 'Tên sinh viên',
                field: 'name',
                cellClass: ['text-left'],
                flex: 1
            },
            {
                headerName: 'Mã sinh viên',
                headerTooltip: 'Mã sinh viên',
                field: 'studentNo',
                cellClass: ['text-left'],
                flex: 1
            },
        ];
        this.roomColdef = [
            {
                headerName: 'Tên phòng',
                headerTooltip: 'Tên phòng',
                field: 'roomNo',
                cellClass: ['text-left'],
                flex: 2
            },
            {
                headerName: 'Chỗ trống',
                headerTooltip: 'Số chỗ trống',
                field: 'empty',
                cellClass: ['text-left'],
                flex: 1
            },
            {
                headerName: 'Giá',
                headerTooltip: 'Giá',
                field: 'unitPrice',
                valueFormatter: (params) => this.dataFormatService.moneyFormat(params.value),
                cellClass: ['text-left'],
                flex: 2
            },
        ];
    }

    ngOnInit() {
        }
    show(invoiceId?: number): void {

        if (!invoiceId) {
            this.contract = new CreateOrEditContractDto();
            this.listRoom = [];
            this._contract.getListStudentForCreate().subscribe((result) => {
               this.listStudent = result;
            });
            this.contract.id = invoiceId;
            this.contract.contractDate = moment();
            this.contract.startDate = moment();
            this.contract.endDate = moment().add(1, 'year');
            this.active = true;
            this.modal.show();
        } else {
            this._contract.getContractForEdit(invoiceId)
                .subscribe((result) => {
                    this.listRoom = [];
                    this._contract.getListRoom().subscribe((result) => {
                        forEach(result, (item) => {
                            this.listRoom.push({ value: item.id, label: item.roomNo ,price: item.unitPrice});
                        });
                    });
                    this._contract.getListStudent().subscribe((result) => {
                            forEach(result, (item) => {
                                this.listStudentEdit.push({ value: item.id, label: item.name });
                            });
                    });
                    this.contract = result[0];
                    this.active = true;
                    this.modal.show();
                });
        }
    }

    save(): void {
        // check start date < end date
        if (this.contract.startDate.valueOf() > this.contract.endDate.valueOf()) {
            //open infomation modal
            this.notify.error(this.l('Ngày bắt đầu phải nhỏ hơn ngày kết thúc'));
            return;
        }
        else{
        this.saving = true;
        this._contract
            .createOrEdit(this.contract)
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
        this.listRoomCreate = [];
        this.listStudent = [];
    }
    onChangeSelection(event){
        this.listRoomCreate = [];
        this._contract.getListRoomForCreate(event).subscribe((result) => {
            this.listRoomCreate = result;
        });
    }
    onChangeStartDate() {
        this.newDate = new Date(this.contract.startDate.toString());
        this.contract.endDate = this.newDate.setFullYear(this.newDate.getFullYear() + 1);
    }
}
