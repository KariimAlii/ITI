import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PowerPipe } from './power.pipe';
import { SplicePipe } from './splice.pipe';
import { splitNsName } from '@angular/compiler';


@NgModule({
  declarations: [
    PowerPipe,
    SplicePipe
  ],
  imports: [
    CommonModule
  ],
  exports:[
    PowerPipe,
    SplicePipe
  ]
})
export class SharedModule { }
