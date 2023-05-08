import { CreateOrEditInvoiceComponent } from './create-or-edit-invoice/create-or-edit-invoice.component';
import { TABS } from '@app/shared/constants/tab-keys';
import { CommonDeclareModule } from '@app/shared/common-declare.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InvoiceComponent } from './invoice.component';

@NgModule({
  imports: [
    CommonDeclareModule
  ],
  declarations: [InvoiceComponent,
                CreateOrEditInvoiceComponent]
})
export class InvoiceModule {
}
