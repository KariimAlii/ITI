import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DepartmentService } from 'src/app/Services/department.service';
import { Department } from 'src/app/_models/department';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-department-update',
  templateUrl: './department-update.component.html',
  styleUrls: ['./department-update.component.css']
})
export class DepartmentUpdateComponent implements OnInit{
  department: Department|null = null;

  constructor(public ac : ActivatedRoute ,public departmentService : DepartmentService) {

  }
  ngOnInit(): void {
    const id = this.ac.snapshot.params["id"];
    const requiredDept = this.departmentService.getDepartment(id);
    this.department = JSON.parse(JSON.stringify(requiredDept));
  }
  Update(department:Department) {
    this.departmentService.updateDepartment(department);
  }
}
