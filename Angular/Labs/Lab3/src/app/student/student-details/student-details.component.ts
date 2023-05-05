import { Component, EventEmitter, Input , Output } from '@angular/core';
import { Student } from 'src/app/_models/student';

@Component({
  selector: 'app-student-details',
  templateUrl: './student-details.component.html',
  styleUrls: ['./student-details.component.scss']
})
export class StudentDetailsComponent {
  hideDetails():void {
    this.onHideDetails.emit(false);
  }
  @Input()
  studentDetails : Student = new Student();

  @Output()
  onHideDetails : EventEmitter<boolean> = new EventEmitter<boolean>();
}
