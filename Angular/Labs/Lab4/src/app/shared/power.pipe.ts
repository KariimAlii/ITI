import { Pipe, PipeTransform } from '@angular/core';


//! Pure Pipe
//*======================
//* for dealing with reference types ==> pipe works with changing (reference of data) not changing (data)

@Pipe({
  name: 'power'
})
export class PowerPipe implements PipeTransform {

  transform(value: number, y : number = 1): number {
    return Math.pow(value,y);
  }

}
