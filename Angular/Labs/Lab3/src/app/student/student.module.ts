import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StudentDetailsComponent } from './student-details/student-details.component';
import { StudentCrudComponent } from './student-crud/student-crud.component';
import {FormsModule} from '@angular/forms';
import { StudentListComponent } from './student-list/student-list.component';
import { StudentUpdateComponent } from './student-update/student-update.component';
import { StudentAddComponent } from './student-add/student-add.component';
import { StudentDeleteComponent } from './student-delete/student-delete.component'


@NgModule({
  declarations: [
    StudentDetailsComponent,
    StudentCrudComponent,
    StudentListComponent,
    StudentUpdateComponent,
    StudentAddComponent,
    StudentDeleteComponent
  ],
  imports: [
    CommonModule,
    FormsModule
  ],
  exports:[
    StudentListComponent
  ]
})
export class StudentModule { }
