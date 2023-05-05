import { Component , EventEmitter, Output } from '@angular/core';
import { Student } from 'src/app/_models/student';
@Component({
  selector: 'app-student-add',
  templateUrl: './student-add.component.html',
  styleUrls: ['./student-add.component.scss']
})
export class StudentAddComponent {
  addFlag : boolean = false;
  newStudent : Student = new Student();
  Save(): void {
    this.onStudentAdd.emit(this.newStudent);
    this.addFlag = false;
  }
  showAdd() : void {
    this.addFlag = true;
  }
  hideAdd() : void {
    this.addFlag = false;
  }

  @Output()
  onStudentAdd : EventEmitter<Student> = new EventEmitter<Student>();

}

// CLoning Object in Javascript
// ================================
// Save(): void {
//   Shallow CLoning
//   =================
//   const newStudent = Object.assign({},this.newStudent);
//   const newStudent = {...this.newStudent}

//   Deep CLoning
//   =================
//   const newStudent = JSON.parse(JSON.stringify(this.newStudent)) ;
//   this.students.push(newStudent);

//   Copying Reference
//   =======================
//   this.students.push(this.newStudent); ===> references the original object
// }
// https://www.freecodecamp.org/news/clone-an-object-in-javascript/
// https://lodash.com/docs/4.17.15#cloneDeep
