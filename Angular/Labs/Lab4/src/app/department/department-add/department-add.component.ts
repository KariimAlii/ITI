import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { DepartmentService } from 'src/app/Services/department.service';
import { Department } from 'src/app/_models/department';

@Component({
  selector: 'app-department-add',
  templateUrl: './department-add.component.html',
  styleUrls: ['./department-add.component.css'],
  // providers:[DepartmentService]

})
export class DepartmentAddComponent {

  newDepartment: Department = new Department();
  Add():void {
    this.departmentService.add(this.newDepartment);
    this.router.navigateByUrl("/departments");
  }
  constructor(public departmentService : DepartmentService , private router : Router) {

  }
}
