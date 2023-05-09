import { Component, OnInit,Input , OnChanges, SimpleChanges, OnDestroy} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { DepartmentService } from 'src/app/Services/department.service';
import { Department } from 'src/app/_models/department';

@Component({
  selector: 'app-department-details',
  templateUrl: './department-details.component.html',
  styleUrls: ['./department-details.component.css']
})
export class DepartmentDetailsComponent implements OnInit,OnDestroy {
  // id : number;
  sub : Subscription | null = null;
  department : Department|null = null;
  constructor(private departmentService : DepartmentService , private ac :ActivatedRoute) {}
  ngOnDestroy(): void {
    this.sub?.unsubscribe();
  }
  ngOnInit(): void {
    // this.id = this.ac.snapshot.params["id"];
    // this.department = this.departmentService.getDepartment(this.id);
    this.sub = this.ac.params.subscribe(data => {
      this.department = this.departmentService.getDepartment(data["id"]);
    })
  }

}
