import { Component } from '@angular/core';
import { Student } from 'src/app/_models/student';

@Component({
  selector: 'app-student-details',
  templateUrl: './student-details.component.html',
  styleUrls: ['./student-details.component.scss']
})
export class StudentDetailsComponent {
  std: Student = new Student(1,"Karim Ali",26,1);

  updateStudent(id:number,name:string,age:number,deptNo:number) : void {
    this.std.id = id;
    this.std.name = name;
    this.std.age = age;
    this.std.deptNo = deptNo;
  }
}
