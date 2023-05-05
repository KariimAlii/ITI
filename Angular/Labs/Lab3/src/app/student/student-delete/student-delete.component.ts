import { Component,Input , Output , EventEmitter } from '@angular/core';
import { Student } from 'src/app/_models/student';

@Component({
  selector: 'app-student-delete',
  templateUrl: './student-delete.component.html',
  styleUrls: ['./student-delete.component.scss']
})
export class StudentDeleteComponent {
  @Input()
  studentDetails:Student = new Student();


  @Output()
  onDeleteStudent : EventEmitter<boolean> = new EventEmitter<boolean>();
  Delete():void {
    this.onDeleteStudent.emit(true);
  }
  Cancel():void {
    this.onDeleteStudent.emit(false);
  }
}
