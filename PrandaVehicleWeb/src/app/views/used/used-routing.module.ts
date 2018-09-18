import { NgModule } from '@angular/core';
import {
  Routes,
  RouterModule
} from '@angular/router';

import { UsedComponent } from './used.component';
import { UsedNewComponent } from './manage/used-new.component';
import { UsedViewComponent } from './manage/used-view.component';

const routes: Routes = [
  {
    path: 'searchused',
    component: UsedComponent,
    data: {
      title: 'Search Used'
    }
  },
  {
    path: 'addused',
    component: UsedNewComponent,
    data: {
      title: 'Add Used'
    }
  },
  {
    path: 'viewused',
    component: UsedViewComponent,
    data: {
      title: 'View Used'
    }
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsedRoutingModule { }
