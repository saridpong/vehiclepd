import { NgModule } from '@angular/core';
import {
  Routes,
  RouterModule
} from '@angular/router';
import { DriverSearchComponent } from './driver/driver-search.component';
import { UserSearchComponent } from './user/user-search.component';
import { UserManagementComponent } from './user/user-management.component';
import { DriverManagementComponent } from './driver/driver-management.component';
import { ForUseSearchComponent } from './foruse/foruse-search.component';
import { ForUseManagementComponent } from './foruse/foruse-management.component';
import { PlaceManagementComponent } from './place/place-management.component';
import { PlaceSearchComponent } from './place/place-search.component';
import { InformationSearchComponent } from './information/information-search.component';




const routes: Routes = [
  {
    path: 'information/search',
    component: InformationSearchComponent,
    data: {
      title: 'บันทึกข้อมูล Information'
    }
  },
  {
    path: 'foruse/search',
    component: ForUseSearchComponent,
    data: {
      title: 'ข้อมูลการใช้รถ'
    }
  },
  {
    path: 'foruse/new',
    component: ForUseManagementComponent,
    data: {
      title: 'บันทึกข้อมูลการใช้รถ'
    }
  },
  {
    path: 'foruse/edit/:id',
    component: ForUseManagementComponent,
    data: {
      title: 'แก้ไขข้อมูลการใช้รถ',
      role: 'update'
    }
  },
  {
    path: 'place/search',
    component: PlaceSearchComponent,
    data: {
      title: 'ข้อมูลสถานที่'
    }
  },
  {
    path: 'place/new',
    component: PlaceManagementComponent,
    data: {
      title: 'บันทึกข้อมูลสถานที่'
    }
  },
  {
    path: 'place/edit/:id',
    component: PlaceManagementComponent,
    data: {
      title: 'แก้ไขข้อมูลสถานที่',
      role: 'update'
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
    path: 'driver/new',
    component: DriverManagementComponent,
    data: {
      title: 'บันทึกข้อมูลพนักงานขับรถ'
    }
  },
  {
    path: 'driver/edit/:id',
    component: DriverManagementComponent,
    data: {
      title: 'แก้ไขข้อมูลพนักงานขับรถ',
      role: 'update'
    }
  },
  {
    path: 'driver/view/:id',
    component: DriverManagementComponent,
    data: {
      title: 'ข้อมูลพนักงานขับรถ',
      role: 'view'
    }
  },
  {
    path: 'user/search',
    component: UserSearchComponent,
    data: {
      title: 'ข้อมูลผู้ใช้งานระบบ'
    }
  },
  {
    path: 'user/new',
    component: UserManagementComponent,
    data: {
      title: 'บันทึกข้อมูลผู้ใช้งานระบบ'
    }
  },
  {
    path: 'user/edit/:id',
    component: UserManagementComponent,
    data: {
      title: 'แก้ไขข้อมูลผู้ใช้งานระบบ',
      role: 'update'
    }
  },
  {
    path: 'user/view/:id',
    component: UserManagementComponent,
    data: {
      title: 'ข้อมูลผู้ใช้งานระบบ',
      role: 'view'
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SetupRoutingModule { }
