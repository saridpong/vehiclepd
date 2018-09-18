import { NgModule } from '@angular/core';
import {
  Routes,
  RouterModule
} from '@angular/router';

import { RequestComponent } from './request.component';
import { RequestApproveComponent } from './approve/approve-view.component';
import { RequestNewComponent } from './manage/request-new.component';
import { RequestViewComponent } from './manage/request-view.component';
import { ApproveNewComponent } from './approve/approve-new.component';
import { PayNewComponent } from './pay/pay-new.component';
import { RequestPayComponent } from './pay/pay-view.component';
import { RequestRateComponent } from './rate/rate-view.component';

const routes: Routes = [
  {
    path: 'searchrequest',
    component: RequestComponent,
    data: {
      title: 'Search Request'
    }
  },
  {
    path: 'addrequest',
    component: RequestNewComponent,
    data: {
      title: 'Add Request'
    }
  },
  {
    path: 'viewrequest',
    component: RequestViewComponent,
    data: {
      title: 'View Request'
    }
  },
  {
    path: 'searchapprove',
    component: RequestApproveComponent,
    data: {
      title: 'Search Aapprove Request'
    }
  },
  {
    path: 'newapprove',
    component: ApproveNewComponent,
    data: {
      title: 'New Aapprove Request'
    }
  },
  {
    path: 'pay',
    component: RequestPayComponent,
    data: {
      title: 'Pay Cost Management'
    }
  },
  {
    path: 'newpay',
    component: PayNewComponent,
    data: {
      title: 'New Pay Cost'
    }
  },
  {
    path: 'rate',
    component: RequestRateComponent,
    data: {
      title: 'Request Rate Management'
    }
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RequestRoutingModule { }
