import { AppPlaceComponent } from './../../components/app-place/app-place.component';
import { NgSelectModule } from '@ng-select/ng-select';
import { AppForUseComponent } from './../../components/app-for-use/app-for-use.component';

import { NgModule } from '@angular/core';
import { ChartsModule } from 'ng2-charts/ng2-charts';
import { FormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { RequestsRoutingModule } from './requests-routing.module';
import { CommonModule } from '@angular/common';
import { TabsModule, ModalModule } from 'ngx-bootstrap';
import { RequestCarsComponent } from './commons/request-cars.component';
import { StaffComponent } from './commons/staff.component';
import { RequestsComponent } from './requests.component';
import { PlaceNewComponent } from './commons/dialog/place-new.component';
import { PlaceEditComponent } from './commons/dialog/place-edit.component';
import { RequestSearchComponent } from './request-search.component';
import { RequestsApproveComponent } from './requests-approve.component';
import { ApproveCarsComponent } from './commons/approve-cars.component';
import { OwlDateTimeModule, OwlNativeDateTimeModule, OWL_DATE_TIME_LOCALE } from 'ng-pick-datetime';
import { AppDriverComponent } from '../../components/app-driver';
import { AppVehicleComponent } from '../../components/app-vehicle';
import { RequestsRatingComponent } from './requests-rating.component';
import { RatingComponent } from './commons/rating.component';
import { LabourCostComponent } from './commons/labour-cost.component';
import { RequestsLabourCostComponent } from './requests-labour-cost.component';

@NgModule({
  imports: [
    CommonModule,
    RequestsRoutingModule,
    ChartsModule,
    FormsModule,
    ToastrModule.forRoot(),
    // BrowserModule,
    ModalModule.forRoot(),
    TabsModule.forRoot(),
    NgSelectModule,
    OwlDateTimeModule,
    OwlNativeDateTimeModule
  ],
  declarations: [
    RequestCarsComponent,
    StaffComponent,
    RequestsComponent,
    PlaceNewComponent,
    PlaceEditComponent,
    RequestSearchComponent,
    RequestsApproveComponent,
    ApproveCarsComponent,
    AppForUseComponent,
    AppPlaceComponent,
    AppDriverComponent,
    AppVehicleComponent,
    RequestsRatingComponent,
    RatingComponent,
    LabourCostComponent,
    RequestsLabourCostComponent
  ],
  entryComponents: [
    RequestCarsComponent,
    StaffComponent,
    PlaceNewComponent,
    PlaceEditComponent,
    RequestsApproveComponent,
    ApproveCarsComponent,
    AppForUseComponent,
    AppPlaceComponent,
    AppDriverComponent,
    AppVehicleComponent,
    RequestsRatingComponent,
    RatingComponent,
    LabourCostComponent,
    RequestsLabourCostComponent
  ],
  providers: [
    { provide: OWL_DATE_TIME_LOCALE, useValue: 'th' },
  ]
})
export class RequestsModule { }
