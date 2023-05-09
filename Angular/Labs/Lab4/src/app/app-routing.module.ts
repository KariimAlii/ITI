import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule,Routes} from '@angular/router';


import { HomeComponent } from './main/home/home.component';
import { AboutComponent } from './main/about/about.component';
import { ContactComponent } from './main/contact/contact.component';
import { ErrorComponent } from './main/error/error.component';



const routes:Routes = [
  {path:'home',component:HomeComponent},
  {path:'aboutus',component:AboutComponent},
  {path:'contactus',component:ContactComponent},
  //! Lazy Loaded Module  ==> https://angular.io/guide/lazy-loading-ngmodules
  {
    path: 'departments',
    loadChildren: () => import('./department/department.module').then(m => m.DepartmentModule)
  },
  // {path:'',component:HomeComponent} //! 2 Problems ==> 1- Link in UI is not Active  2- URL: '' is not compatible with Home Component Content
  {path:'',redirectTo:'home',pathMatch:'full'},
  {path:'**',component:ErrorComponent}
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes), //! ==> registers ActivatedRoute Service in dependency injection container
  ],
  exports:[
    RouterModule
  ]
})
export class AppRoutingModule { }
