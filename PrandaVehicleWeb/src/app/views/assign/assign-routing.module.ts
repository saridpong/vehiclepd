import { NgModule } from '@angular/core';
import {
  Routes,
  RouterModule
} from '@angular/router';

import { AssignComponent } from './assign.component';
import { AssignApproveComponent } from './approve/assign-approve.component';
import { AssignNewComponent } from './manage/assign-new.component';

const routes: Routes = [
  {
    path: 'view',
    component: AssignComponent,
    data: {
      title: 'View Assign'
    }
  },
  {
    path: 'approve',
    component: AssignApproveComponent,
    data: {
      title: 'Approve Assign'
    }
  },
  {
    path: 'add',
    component: AssignNewComponent,
    data: {
      title: 'Add Assign Management'
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AssignRoutingModule { }
