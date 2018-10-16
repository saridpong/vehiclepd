
import { AssignSearchComponent } from './assign-search.component';

import { NgModule } from '@angular/core';
import {
  Routes,
  RouterModule
} from '@angular/router';
import { RequestsComponent } from './requests.component';
import { RequestSearchComponent } from './request-search.component';
import { RequestsApproveComponent } from './requests-approve.component';
import { RequestsRatingComponent } from './requests-rating.component';
import { RequestsLabourCostComponent } from './requests-labour-cost.component';
import { AssignComponent } from './assign.component';
import { AssignApproveComponent } from './assign-approve.component';



const routes: Routes = [
  {
    path: '',
    component: RequestsComponent,
    data: {
      title: 'บันทึกข้อมูลขอใช้รถยนต์'
    }
  },
  {
    path: 'assign',
    component: AssignComponent,
    data: {
      title: 'บันทึกข้อมูลใบมอบหมายงาน'
    }
  },
  {
    path: 'assign/search',
    component: AssignSearchComponent,
    data: {
      title: 'ข้อมูลใบมอบหมายงาน'
    }
  },
  {
    path: 'assign/view/:id',
    component: AssignComponent,
    data: {
      title: 'บันทึกข้อมูลใบมอบหมายงาน',
      role: 'view'
    }
  },
  {
    path: 'assign/update/:id',
    component: AssignComponent,
    data: {
      title: 'บันทึกข้อมูลใบมอบหมายงาน',
      role: 'update'
    }
  },
  {
    path: 'assign/approve/:id',
    component: AssignApproveComponent,
    data: {
      title: 'บันทึกข้อมูลใบมอบหมายงาน'
    }
  },
  {
    path: 'assign/approve/view/:id',
    component: AssignApproveComponent,
    data: {
      title: 'บันทึกข้อมูลใบมอบหมายงาน',
      role: 'view'
    }
  },
  {
    path: 'search',
    component: RequestSearchComponent,
    data: {
      title: 'ข้อมูลขอใช้รถยนต์'
    }
  },
  {
    path: 'view/:id',
    component: RequestsComponent,
    data: {
      title: 'อนุมัติการขอใช้รถยนต์',
      role: 'view'
    }
  },
  {
    path: 'update/:id',
    component: RequestsComponent,
    data: {
      title: 'อนุมัติการขอใช้รถยนต์',
      role: 'update'
    }
  },
  {
    path: 'approve/:id',
    component: RequestsApproveComponent,
    data: {
      title: 'อนุมัติการขอใช้รถยนต์'
    }
  },
  {
    path: 'rating/:id',
    component: RequestsRatingComponent,
    data: {
      title: 'ให้คะแนนความพึงพอใจ'
    }
  },
  {
    path: 'rating/view/:id',
    component: RequestsRatingComponent,
    data: {
      title: 'ให้คะแนนความพึงพอใจ',
      role: 'view'
    }
  },
  {
    path: 'approve/view/:id',
    component: RequestsApproveComponent,
    data: {
      title: 'อนุมัติการขอใช้รถยนต์',
      role: 'view'
    }
  },
  {
    path: 'labourcost/:id',
    component: RequestsLabourCostComponent,
    data: {
      title: 'บันทึกค่าแรง'
    }
  },
  {
    path: 'labourcost/view/:id',
    component: RequestsLabourCostComponent,
    data: {
      title: 'บันทึกค่าแรง',
      role: 'view'
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RequestsRoutingModule { }
