import { Component } from '@angular/core';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  // providers:[DepartmentService] //! provides this dependency for all its children modules
})
export class AppComponent {
  title = 'Lab4';
}
