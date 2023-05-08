import { forEach } from 'lodash';
import { finalize } from 'rxjs/operators';
import { StudentServiceProxy, CreateOrEditStudentDto } from './../../../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { Component, OnInit, Output, ViewChild, EventEmitter, Injector } from '@angular/core';

@Component({
  selector: 'app-create-or-edit-student',
  templateUrl: './create-or-edit-student.component.html',
  styleUrls: ['./create-or-edit-student.component.less']
})
export class CreateOrEditStudentComponent extends AppComponentBase {

    @ViewChild("createOrEditModal", { static: true }) modal: ModalDirective;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    student: CreateOrEditStudentDto = new CreateOrEditStudentDto();
    active: boolean = false;
    saving: boolean = false;
    check=false;

    listGender: { value: number, label: string }[] = [
        { value: 1, label: "Nam" },
        { value: 2, label: "Nữ" }
    ];
    listStudentNo: any[] = [];
    StdId;
    constructor(
        injector: Injector,
        private _student :StudentServiceProxy

    ) {
        super(injector);
    }

    ngOnInit() {
    }

    show(studentId?: number): void {
        this.StdId = studentId;
        if (!studentId) {
            this._student.getListStudentNo().subscribe(res => {
                this.listStudentNo = res;
            });
            this.student = new CreateOrEditStudentDto();
            this.student.id = studentId;

            this.active = true;
            this.modal.show();
        } else {
            this._student.getStudentForEdit(studentId)
                .subscribe((result) => {
                    this.student = result[0];
                    this.active = true;
                    this.modal.show();
                });
        }
    }

    save(): void {
        if (this.StdId==null) {
            this._student.getListStudentNo().subscribe(res => {
                forEach (res, (item) => {
                    if (item.studentNo === this.student.studentNo) {
                        this.notify.error("Mã sinh viên đã tồn tại");
                        this.check = true;
                        this.close();
                        return;
                    }
                    else if(item.cmnd === this.student.cmnd){
                        this.notify.error("CMND đã tồn tại");
                        this.check = true;
                        this.close();
                        return;
                    }
                })
                if (!this.check) {
                    this.saving = true;
                    this._student.createOrEdit(this.student)
                        .pipe(finalize(() => { this.saving = false; }))
                        .subscribe(() => {
                            this.notify.info(this.l('SavedSuccessfully'));
                            this.close();
                            this.modalSave.emit(null);
                });
                }
            });
        }
        else {
        this.saving = true;
        this._student
            .createOrEdit(this.student)
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
        this.check = false;
    }
}
