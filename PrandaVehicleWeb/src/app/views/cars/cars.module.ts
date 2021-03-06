import { OwlDateTimeModule, OwlNativeDateTimeModule } from 'ng-pick-datetime';

import { NgModule } from '@angular/core';
import { ChartsModule } from 'ng2-charts/ng2-charts';
import { FormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { CarsComponent } from './cars.component';
import { CarsRoutingModule } from './cars-routing.module';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { ModalDialogModule } from 'ngx-modal-dialog';
import { CarsNewComponent } from './manage/cars-new.component';
import { CarsViewComponent } from './manage/cars-view.component';
import { TabsModule } from 'ngx-bootstrap';
import { CarsMaintenanceNewComponent } from './maintenance/maintenance-new.component';
import { CarsMaintenanceComponent } from './maintenance/maintenance-view.component';
import { CarsDocumentNewComponent } from './document/document-new.component';
import { CarsDocumentComponent } from './document/document-view.component';
import { CarsUpdateComponent } from './manage/cars-update.component';
import { AppCarTypeComponent } from '../../components/app-car-type';
import { NgSelectModule } from '@ng-select/ng-select';

@NgModule({
  imports: [
    CommonModule,
    CarsRoutingModule,
    ChartsModule,
    FormsModule,
    ToastrModule.forRoot(),
    // BrowserModule,
    ModalDialogModule.forRoot(),
    TabsModule.forRoot(),
    NgSelectModule,
    OwlDateTimeModule,
    OwlNativeDateTimeModule
  ],
  declarations: [
    CarsComponent,
    CarsNewComponent,
    CarsViewComponent,
    CarsMaintenanceComponent,
    CarsMaintenanceNewComponent,
    CarsDocumentComponent,
    CarsDocumentNewComponent,
    CarsUpdateComponent,
    AppCarTypeComponent
  ],
  entryComponents: [
    CarsNewComponent,
    CarsMaintenanceNewComponent,
    CarsDocumentNewComponent,
    AppCarTypeComponent
  ],
})
export class CarsModule { }
