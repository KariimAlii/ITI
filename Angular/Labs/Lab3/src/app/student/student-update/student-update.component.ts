import { Component,Input,Output,EventEmitter } from '@angular/core';
import { Student } from 'src/app/_models/student';

@Component({
  selector: 'app-student-update',
  templateUrl: './student-update.component.html',
  styleUrls: ['./student-update.component.scss']
})
export class StudentUpdateComponent {
  @Input()
  studentDetails : Student = new Student();

  @Output()
  onStudentUpdate:EventEmitter<Student> = new EventEmitter<Student>();
  Save():void {
    this.onStudentUpdate.emit(this.studentDetails);

  }

  @Output()
  onHideUpdateStudent:EventEmitter<boolean> = new EventEmitter<boolean>();
  hideUpdate():void {
    this.onHideUpdateStudent.emit(false);
  }
}
