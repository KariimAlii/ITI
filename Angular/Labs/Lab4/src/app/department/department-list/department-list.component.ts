import { Component, OnInit} from '@angular/core';

import { DepartmentService } from 'src/app/Services/department.service';
import { Department } from 'src/app/_models/department';


@Component({
  selector: 'app-department-list',
  templateUrl: './department-list.component.html',
  styleUrls: ['./department-list.component.css'],
  // providers:[DepartmentService] //! Note : DepartmentService class has default constructor , Note : Token = value = DepartmentService
  // providers:[{provide:DepartmentService,useValue:DepartmentService}] //! Note : {provide:Token , useValue:Value} ==> Token = value = DepartmentService

})
export class DepartmentListComponent implements OnInit{

  constructor(public departmentService : DepartmentService) {

  }

  Departments : Department[] = [];

  ngOnInit(): void {
    this.Departments = this.departmentService.getAll();
  }


}

  // departmentService : DepartmentService;
  // constructor(departmentService : DepartmentService) {
  //   this.departmentService = departmentService;
  // }
