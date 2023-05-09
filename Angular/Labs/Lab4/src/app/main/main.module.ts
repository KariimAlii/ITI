import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { ContactComponent } from './contact/contact.component';
import { AboutComponent } from './about/about.component';
import { ErrorComponent } from './error/error.component';



@NgModule({
  declarations: [
    HomeComponent,
    ContactComponent,
    AboutComponent,
    ErrorComponent
  ],
  imports: [
    CommonModule
  ],
  exports:[
    HomeComponent,
    ContactComponent,
    AboutComponent,
    ErrorComponent
  ]
})
export class MainModule { }
