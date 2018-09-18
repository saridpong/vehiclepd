
import { NgModule } from '@angular/core';
import { ChartsModule } from 'ng2-charts/ng2-charts';
import { FormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { UsedComponent } from './used.component';
import { UsedRoutingModule } from './used-routing.module';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { ModalDialogModule } from 'ngx-modal-dialog';
import { UsedNewComponent } from './manage/used-new.component';
import { UsedViewComponent } from './manage/used-view.component';
import { TabsModule } from 'ngx-bootstrap';

@NgModule({
  imports: [
    CommonModule,
    UsedRoutingModule,
    ChartsModule,
    FormsModule,
    ToastrModule.forRoot(),
    // BrowserModule,
    ModalDialogModule.forRoot(),
    TabsModule.forRoot(),
  ],
  declarations: [
    UsedComponent,
    UsedNewComponent,
    UsedViewComponent
  ],
  entryComponents: [
    UsedNewComponent,
  ],
})
export class UsedModule { }
