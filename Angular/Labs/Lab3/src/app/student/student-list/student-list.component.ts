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

    // Update (Child)
  //=================
  _updateFlag : boolean = false;
  _studentUpdate : Student = new Student();
  _exportStudentUpdate : Student = new Student();
  showUpdateStudent(id:number) :void {
    this._studentUpdate = this.students.find(a => a.id === id);
    this._exportStudentUpdate =JSON.parse(JSON.stringify(this._studentUpdate)) ; // Deep Cloning
    this._updateFlag = true;
  }
  hideUpdateStudent(flag : boolean):void {
    this._updateFlag = flag;
  }
  updateStudent(student:Student) :void {
    this._studentUpdate.age = student.age;
    this._studentUpdate.name = student.name;
    this._studentUpdate.deptNo = student.deptNo;
  }
  // Delete (Child)
  //=================
  deleteFlag : boolean = false;
  studentDeleteDetails : Student = new Student();
  showDeleteStudent(id : number):void {
    this.studentDeleteDetails = this.students.find(a => a.id === id);
    this.deleteFlag = true;
  }
  DeleteOrHide(flag : boolean) {
    if (flag) {
      const index = this.students.indexOf(this.studentDeleteDetails);
      this.students.splice(index,1);
    }
    this.deleteFlag = false;
  }
}

// Removing array item by value ===> https://sentry.io/answers/remove-specific-item-from-array/#:~:text=If%20you%20want%20to%20remove,to%20remove%20the%20first%20element.
