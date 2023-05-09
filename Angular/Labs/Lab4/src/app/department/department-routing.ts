import { RouterModule,Routes,Router } from '@angular/router';
import { DepartmentAddComponent } from './department-add/department-add.component';
import { DepartmentDetailsComponent } from './department-details/department-details.component';
import { DepartmentListComponent } from './department-list/department-list.component';
import { DepartmentUpdateComponent } from './department-update/department-update.component';
import { NgModule } from '@angular/core';

const routes:Routes = [
  {path:'',component:DepartmentListComponent},
  // ,children:[
  //     {path:'add',component:DepartmentAddComponent},
  //     {path:'details/:id',component:DepartmentDetailsComponent}
  // ]},
  {path:'details/:id',component:DepartmentDetailsComponent},
  {path:'add',component:DepartmentAddComponent},
  {path:'edit/:id',component:DepartmentUpdateComponent},
]

@NgModule({
  declarations:[],
  imports:[
    RouterModule.forChild(routes)
  ],
  exports:[RouterModule]
})
export class DepartmentRoutingModule {

}
