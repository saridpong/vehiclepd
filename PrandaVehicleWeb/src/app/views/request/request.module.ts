
import { NgModule } from '@angular/core';
import { ChartsModule } from 'ng2-charts/ng2-charts';
import { FormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { RequestComponent } from './request.component';
import { RequestRoutingModule } from './request-routing.module';
import { CommonModule } from '@angular/common';
import { RequestApproveComponent } from './approve/approve-view.component';
import { ApproveNewComponent } from './approve/approve-new.component';
import { BrowserModule } from '@angular/platform-browser';
import { ModalDialogModule } from 'ngx-modal-dialog';
import { RequestNewComponent } from './manage/request-new.component';
import { RequestViewComponent } from './manage/request-view.component';
import { TabsModule } from 'ngx-bootstrap';
import { PayNewComponent } from './pay/pay-new.component';
import { RequestPayComponent } from './pay/pay-view.component';
import { RequestRateComponent } from './rate/rate-view.component';
import { RateNewComponent } from './rate/rate-new.component';

@NgModule({
  imports: [
    CommonModule,
    RequestRoutingModule,
    ChartsModule,
    FormsModule,
    ToastrModule.forRoot(),
    // BrowserModule,
    ModalDialogModule.forRoot(),
    TabsModule.forRoot(),
  ],
  declarations: [
    RequestComponent,
    RequestNewComponent,
    RequestApproveComponent,
    ApproveNewComponent,
    RequestViewComponent,
    RequestPayComponent,
    PayNewComponent,
    RequestRateComponent,
    RateNewComponent
  ],
  entryComponents: [
    RequestNewComponent,
    ApproveNewComponent,
    PayNewComponent,
    RateNewComponent
  ],
})
export class RequestModule { }
