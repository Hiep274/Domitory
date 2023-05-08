import { ViewListStudentComponent } from './view-list-student/view-list-student.component';
import { CreateOrEditRoomComponent } from './create-or-edit-room/create-or-edit-room.component';
import { CreateOrEditBuildingComponent } from './create-or-edit-building/create-or-edit-building.component';
import { TABS } from '@app/shared/constants/tab-keys';
import { NgModule } from '@angular/core';
import { BuildingRoomComponent } from './building-room.component';
import { CommonDeclareModule } from '@app/shared/common-declare.module';

@NgModule({
  imports: [
    CommonDeclareModule
  ],
  declarations: [BuildingRoomComponent,
                CreateOrEditBuildingComponent,
                CreateOrEditRoomComponent,
                ViewListStudentComponent],
})
export class BuildingRoomModule {
}
