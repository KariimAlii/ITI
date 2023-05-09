
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';


import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
import { ShowComponent } from './show/show.component';
import { DepartmentModule } from './department/department.module';
import { MainModule } from './main/main.module';
import { CoreModule } from './core/core.module';
import { AppRoutingModule } from './app-routing.module';







@NgModule({
  declarations: [
    AppComponent,
    ShowComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    SharedModule,
    CoreModule,
    MainModule,
    AppRoutingModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

//!    Notes
//!==============
//* RouterModule.forRoot(routes)  ==> used to configure routes for the Root module (App Module)
//* RouterModule.forChild(routes)  ==> used to configure routes for the Feature modules
