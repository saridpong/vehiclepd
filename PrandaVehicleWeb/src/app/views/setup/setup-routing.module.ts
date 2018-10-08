import { RequestForSearchComponent } from './requestfor/request-for-search.component';
import { NgModule } from '@angular/core';
import {
  Routes,
  RouterModule
} from '@angular/router';
import { DriverSearchComponent } from './driver/driver-search.component';
import { UserSearchComponent } from './user/user-search.component';



const routes: Routes = [
  {
    path: 'foruse/search',
    component: RequestForSearchComponent,
    data: {
      title: 'เพื่อใช้ในการ'
    }
  },
  {
    path: 'driver/search',
    component: DriverSearchComponent,
    data: {
      title: 'พนักงานขับรถ'
    }
  },
  {
    path: 'user/search',
    component: UserSearchComponent,
    data: {
      title: 'ข้อมูลผู้ใช้งานระบบ'
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SetupRoutingModule { }
