import { MenuManagementComponent } from './menu-management.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MenuGroupComponent } from './menugroupmanagements/menu-group.component';

const routes: Routes = [
  {
    path: 'management',
    component: MenuManagementComponent,
    data: {
      title: 'Menu Management'
    }
  }, {
    path: 'groupmanagement',
    component: MenuGroupComponent,
    data: {
      title: 'Menu Group Management'
    }
  }
];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MenuRoutingModule { }
