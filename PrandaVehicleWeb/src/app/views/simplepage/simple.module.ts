import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { NgxSelectModule } from 'ngx-select-ex';
import { ToastrModule } from 'ngx-toastr';
import { SimpleRoutingModule } from './simple-routing.module';
import { SimpleCriteriaComponent } from './managements/simple-criteria.component';
import { SimpleSearchComponent } from './managements/simple-search.component';
import { SimpleNewComponent } from './new/simple-new.component';
import { SimpleEditComponent } from './edit/simple-edit.component';
import { PaginationModule } from 'ngx-bootstrap';



@NgModule({
  imports: [
    SimpleRoutingModule,
    FormsModule,
    CommonModule,
    NgxSelectModule,
    FormsModule,
    PaginationModule.forRoot(),
    ToastrModule.forRoot({
      closeButton: true,
      timeOut: 2000,
      progressBar: true,
      positionClass: 'toast-bottom-right'
    })
  ],
  declarations: [
    SimpleCriteriaComponent,
    SimpleSearchComponent,
    SimpleNewComponent,
    SimpleEditComponent
  ],
  entryComponents: [

  ],
})
export class SimpleModule { }
