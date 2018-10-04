import { NgModule } from '@angular/core';
import {
  Routes,
  RouterModule
} from '@angular/router';
import { RequestsComponent } from './requests.component';
import { RequestSearchComponent } from './request-search.component';
import { RequestsApproveComponent } from './requests-approve.component';



const routes: Routes = [
  {
    path: '',
    component: RequestsComponent,
    data: {
      title: 'บันทึกข้อมูลขอใช้รถยนต์'
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
    path: 'approve/view/:id',
    component: RequestsApproveComponent,
    data: {
      title: 'อนุมัติการขอใช้รถยนต์',
      role: 'view'
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RequestsRoutingModule { }
