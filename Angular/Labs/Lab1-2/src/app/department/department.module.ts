import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DepartmentDetailsComponent } from './department-details/department-details.component';



@NgModule({
  declarations: [
    DepartmentDetailsComponent
  ],
  imports: [
    CommonModule
  ],
  exports:[
    DepartmentDetailsComponent
  ]
})
export class DepartmentModule { }
