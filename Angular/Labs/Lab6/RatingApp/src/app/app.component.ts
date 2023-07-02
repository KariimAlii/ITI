import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  // title = 'RatingApp';
  // value:number = 3;

  id:number=10;
  Name:string="";
  Age:number=20;

  show(d:any) {
    console.log(d);
  }
}
