import { Component } from '@angular/core';

@Component({
  selector: 'app-show',
  templateUrl: './show.component.html',
  styleUrls: ['./show.component.css']
})
export class ShowComponent {
  title:string = "Hello in Angular and Web API"
  bdate:Date = new Date(1990,1,20);
  x:number = 3;

  name:string = "";
  names:string[] = ["Ahmed","Mohamed","Aly","Sara","Alyaa","Tamer"];
  Add():void {
    this.names.push(this.name);
  }
}

