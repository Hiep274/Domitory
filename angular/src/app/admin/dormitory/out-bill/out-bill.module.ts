import { CreateOrEditOutBillComponent } from './create-or-edit-out-bill/create-or-edit-out-bill.component';
import { CommonDeclareModule } from '@app/shared/common-declare.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OutBillComponent } from './out-bill.component';
import { TABS } from '@app/shared/constants/tab-keys';

@NgModule({
  imports: [
    CommonDeclareModule
  ],
  declarations: [OutBillComponent,
                CreateOrEditOutBillComponent],
})
export class OutBillModule {
 }
