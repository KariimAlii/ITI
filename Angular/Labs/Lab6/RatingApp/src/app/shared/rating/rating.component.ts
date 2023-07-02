
import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';


@Component({
  selector: 'app-rating',
  templateUrl: './rating.component.html',
  styleUrls: ['./rating.component.css']
})
export class RatingComponent implements OnChanges  {
  ngOnChanges(changes: SimpleChanges): void {
    this.divWidth = this.rateValue * 75 / 5;
  }
  @Input() rateValue = 1;
  divWidth = 40;
}
