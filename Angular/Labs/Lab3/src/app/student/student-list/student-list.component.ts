import { Component } from '@angular/core';
import { Student } from 'src/app/_models/student';
@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.scss']
})
export class StudentListComponent {
  students : Student[]  = [
    new Student(1,'karim',15,4),
    new Student(2,'mohamed',17,3),
    new Student(3,'ahmed',20,5),
    new Student(4,'rana',14,1)
  ]

  // degree : number = 50;

  // Details (Child)
  //=================
  _detailsFlag : boolean = false;
  _studentDetails : Student = new Student();
  showDetails(id :number) :void {
    this._studentDetails = this.students.find(a => a.id === id);
    this._detailsFlag = true;
  }
  hideDetails(flag:boolean) {
    this._detailsFlag = flag;
  }

  // Add (Child)
  //=================
  AddStudent(newStudent:Student) : void {
    const _newStudent = JSON.parse(JSON.stringify(newStudent)) ; // Deep Cloning
    this.students.push(_newStudent);
  }
}
