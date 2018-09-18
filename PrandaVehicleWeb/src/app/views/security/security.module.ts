import { FormsModule } from '@angular/forms';

import { NgModule } from '@angular/core';
import { ChartsModule } from 'ng2-charts/ng2-charts';

import { SecurityComponent } from './security.component';
import { SecurityRoutingModule } from './security-routing.module';
import { CommonModule } from '@angular/common';
import { ModalModule, TimepickerModule } from 'ngx-bootstrap';
import { CarsInComponent } from './management/cars-in.component';
import { CarsOutComponent } from './management/cars-out.component';

@NgModule({
  imports: [
    CommonModule,
    SecurityRoutingModule,
    FormsModule,
    ChartsModule,
    ModalModule.forRoot(),
    TimepickerModule.forRoot()
  ],
  declarations: [SecurityComponent, CarsInComponent, CarsOutComponent],
  entryComponents: [CarsInComponent, CarsOutComponent]
})
export class SecurityModule { }
