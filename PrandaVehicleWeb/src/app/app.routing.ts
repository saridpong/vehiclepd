import { RedirectService } from './services/redirect.services';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


// Import Containers
import {
  FullLayoutComponent, SimpleLayoutComponent, NoSidebarLayoutComponent
} from './containers';
import {
  LeftSidebarLayoutComponent
} from './containers/left-sidebar-layout/left-sidebar-layout.component';

export const routes: Routes = [
  {
    path: '',
    component: NoSidebarLayoutComponent,
    canActivate: [RedirectService],
    pathMatch: 'full',
  },
  {
    path: '',
    component: NoSidebarLayoutComponent,
    data: {
      title: 'Home'
    },
    children: [
      {
        path: 'dashboard',
        loadChildren: './views/dashboard/dashboard.module#DashboardModule'
      }
    ]
  },
  {
    path: 'pages',
    component: SimpleLayoutComponent,
    data: {
      title: 'Pages'
    },
    children: [
      {
        path: '',
        loadChildren: './views/pages/pages.module#PagesModule',
      }
    ]
  },
  {
    path: 'menu',
    component: LeftSidebarLayoutComponent,
    data: {
      title: 'Menu'
    },
    children: [
      {
        path: '',
        loadChildren: './views/menus/menu.module#MenuModule',
      }
    ]
  },
  {
    path: 'request',
    component: LeftSidebarLayoutComponent,
    data: {
      title: 'Request'
    },
    children: [
      {
        path: '',
        loadChildren: './views/request/request.module#RequestModule'
      }
    ]
  },
  {
    path: 'requests',
    component: LeftSidebarLayoutComponent,
    data: {
      title: 'Requests'
    },
    children: [
      {
        path: '',
        loadChildren: './views/requests/requests.module#RequestsModule'
      }
    ]
  },
  {
    path: 'assign',
    component: LeftSidebarLayoutComponent,
    data: {
      title: 'Assign'
    },
    children: [
      {
        path: '',
        loadChildren: './views/assign/assign.module#AssignModule'
      }
    ]
  },
  {
    path: 'used',
    component: LeftSidebarLayoutComponent,
    data: {
      title: 'Used'
    },
    children: [
      {
        path: '',
        loadChildren: './views/used/used.module#UsedModule'
      }
    ]
  },
  {
    path: 'cars',
    component: LeftSidebarLayoutComponent,
    data: {
      title: 'Cars'
    },
    children: [
      {
        path: '',
        loadChildren: './views/cars/cars.module#CarsModule'
      }
    ]
  },
  {
    path: 'security',
    component: LeftSidebarLayoutComponent,
    data: {
      title: 'Security'
    },
    children: [
      {
        path: '',
        loadChildren: './views/security/security.module#SecurityModule'
      }
    ]
  },
  {
    path: 'setup',
    component: LeftSidebarLayoutComponent,
    data: {
      title: 'Setup'
    },
    children: [
      {
        path: '',
        loadChildren: './views/setup/setup.module#SetupModule'
      }
    ]
  },
  {
    path: 'Admin',
    component: LeftSidebarLayoutComponent,
    data: {
      title: 'Admin'
    },
    children: [
      {
        path: '',
        loadChildren: './views/admin/admin.module#AdminModule'
      }
    ]
  },
  {
    path: 'simple',
    component: LeftSidebarLayoutComponent,
    data: {
      title: 'Simple Page'
    },
    children: [
      {
        path: '',
        loadChildren: './views/simplepage/simple.module#SimpleModule',
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: false })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
