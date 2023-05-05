import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DepartmentDetailsComponent } from './department-details/department-details.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    DepartmentDetailsComponent
  ],
  imports: [
    CommonModule,FormsModule
  ],
  exports:[
    DepartmentDetailsComponent
  ]
})
export class DepartmentModule { }
