import { DriverSearchComponent } from './driver/driver-search.component';

import { NgModule } from '@angular/core';
import { ChartsModule } from 'ng2-charts/ng2-charts';
import { FormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { CommonModule } from '@angular/common';
import { ModalDialogModule } from 'ngx-modal-dialog';
import { TabsModule } from 'ngx-bootstrap';
import { SetupRoutingModule } from './setup-routing.module';
import { UserSearchComponent } from './user/user-search.component';
import { UserManagementComponent } from './user/user-management.component';
import { NgSelectModule } from '@ng-select/ng-select';
import { AppSectionComponent } from '../../components/app-section/app-section.component';
import { DriverManagementComponent } from './driver/driver-management.component';
import { ForUseManagementComponent } from './foruse/foruse-management.component';
import { ForUseSearchComponent } from './foruse/foruse-search.component';
import { PlaceManagementComponent } from './place/place-management.component';
import { PlaceSearchComponent } from './place/place-search.component';
import { InformationSearchComponent } from './information/information-search.component';

@NgModule({
  imports: [
    CommonModule,
    SetupRoutingModule,
    ChartsModule,
    FormsModule,
    NgSelectModule,
    ToastrModule.forRoot(),
    ModalDialogModule.forRoot(),
    TabsModule.forRoot(),
  ],
  declarations: [
    DriverSearchComponent,
    AppSectionComponent,
    UserSearchComponent,
    ForUseSearchComponent,
    PlaceSearchComponent,
    UserManagementComponent,
    DriverManagementComponent,
    ForUseManagementComponent,
    PlaceManagementComponent,
    InformationSearchComponent
  ],
  entryComponents: [
    DriverSearchComponent,
    AppSectionComponent,
    UserSearchComponent,
    ForUseSearchComponent,
    PlaceSearchComponent,
    UserManagementComponent,
    DriverManagementComponent,
    ForUseManagementComponent,
    PlaceManagementComponent,
    InformationSearchComponent
  ],
})
export class SetupModule { }
