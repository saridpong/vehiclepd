
import { NgModule } from '@angular/core';
import { ChartsModule } from 'ng2-charts/ng2-charts';

import { AssignComponent } from './assign.component';
import { AssignRoutingModule } from './assign-routing.module';
import { CommonModule } from '@angular/common';
import { AssignApproveComponent } from './approve/assign-approve.component';
import { FormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { AssignNewComponent } from './manage/assign-new.component';

@NgModule({
  imports: [
    CommonModule,
    AssignRoutingModule,
    ChartsModule,
    FormsModule,
    ToastrModule.forRoot(),
  ],
  declarations: [
    AssignComponent,
    AssignNewComponent,
    AssignApproveComponent
  ],
  entryComponents: [
    AssignNewComponent
  ],
})
export class AssignModule { }
