import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



import { DepartmentListComponent } from './department-list/department-list.component';
import { DepartmentDetailsComponent } from './department-details/department-details.component';
import { DepartmentAddComponent } from './department-add/department-add.component';
import { DepartmentUpdateComponent } from './department-update/department-update.component';
import { DepartmentRoutingModule } from './department-routing';


@NgModule({
  declarations: [
    DepartmentListComponent,
    DepartmentDetailsComponent,
    DepartmentAddComponent,
    DepartmentUpdateComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    DepartmentRoutingModule
  ],
  exports: [
    DepartmentListComponent,
    DepartmentDetailsComponent,
    DepartmentAddComponent,
    DepartmentUpdateComponent,
  ],
})
export class DepartmentModule {}
