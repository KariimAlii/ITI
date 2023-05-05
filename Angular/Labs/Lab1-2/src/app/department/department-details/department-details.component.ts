import { Component } from '@angular/core';
import { Department } from 'src/app/_models/department';
@Component({
  selector: 'app-department-details',
  templateUrl: './department-details.component.html',
  styleUrls: ['./department-details.component.scss']
})
export class DepartmentDetailsComponent {
  dept: Department = new Department(1,"PWD","Alexandria");

  updateDepartment(id:number,deptName:string,location:string) : void {
    this.dept.id = id;
    this.dept.deptName = deptName;
    this.dept.location = location;
  }


}
