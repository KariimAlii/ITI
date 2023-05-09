import { Injectable } from '@angular/core';
import { Department } from '../_models/department';

@Injectable({
  providedIn: 'root' //! injectable on the root application level
})

export class DepartmentService {
  departments: Department[] = [
    new Department(1,"PWD","Alexandria"),
    new Department(2,"Open Source","Cairo"),
    new Department(3,"System Admin","Assuit"),
    new Department(4,"Data Analysis","Mansoura")
  ];
  getAll() : Department[] {
    return this.departments;
  }
  add (department:Department) : void {
    this.departments.push(JSON.parse(JSON.stringify(department)));
  }
  getDepartment(id : number) : Department|null { //* Nullable Department
    const requiredDepartment =  this.departments.find(d => d.id == id);
    if (!requiredDepartment) return null;
    return requiredDepartment;
  }
  updateDepartment(dept:Department) : void {
    const department = this.getDepartment(dept.id);
    department.deptName = dept.deptName;
    department.location = dept.location;
  }
  constructor() { }
}
