import { DriverSearchComponent } from './driver/driver-search.component';

import { NgModule } from '@angular/core';
import { ChartsModule } from 'ng2-charts/ng2-charts';
import { FormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { CommonModule } from '@angular/common';
import { ModalDialogModule } from 'ngx-modal-dialog';
import { TabsModule } from 'ngx-bootstrap';
import { SetupRoutingModule } from './setup-routing.module';
import { RequestForSearchComponent } from './requestfor/request-for-search.component';
import { UserSearchComponent } from './user/user-search.component';

@NgModule({
  imports: [
    CommonModule,
    SetupRoutingModule,
    ChartsModule,
    FormsModule,
    ToastrModule.forRoot(),
    ModalDialogModule.forRoot(),
    TabsModule.forRoot(),
  ],
  declarations: [
    RequestForSearchComponent,
    DriverSearchComponent,
    UserSearchComponent
  ],
  entryComponents: [
    RequestForSearchComponent,
    DriverSearchComponent,
    UserSearchComponent
  ],
})
export class SetupModule { }
