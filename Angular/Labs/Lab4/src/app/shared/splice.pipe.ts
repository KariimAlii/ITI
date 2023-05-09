import { Pipe, PipeTransform } from '@angular/core';


//! Impure Pipe
//!======================
//* for dealing with reference types ==> pipe works with changing (data)

@Pipe({
  name: 'splice',
  pure:false
})
export class SplicePipe implements PipeTransform {

  transform(value: string[], character:string): string[] {
    let result:string[] = [];
    for (let index = 0; index < value.length; index++) {
      if (value[index].startsWith(character)) {
        result.push(value[index]); //* change in internal data of array ==> you need your pipe to be impure
      }
    }
    return result;
  }

}
