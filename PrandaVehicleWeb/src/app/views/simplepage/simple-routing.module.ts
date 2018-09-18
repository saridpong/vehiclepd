import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SimpleCriteriaComponent } from './managements/simple-criteria.component';
import { SimpleNewComponent } from './new/simple-new.component';
import { SimpleEditComponent } from './edit/simple-edit.component';



const routes: Routes = [
  {
    path: 'management',
    component: SimpleCriteriaComponent,
    data: {
      title: 'Simple Page Management'
    }
  },
  {
    path: 'add',
    component: SimpleNewComponent,
    data: {
      title: 'Add Simple Page Management'
    }
  },
  {
    path: 'edit',
    component: SimpleEditComponent,
    data: {
      title: 'Edit Simple Page Management'
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SimpleRoutingModule { }
