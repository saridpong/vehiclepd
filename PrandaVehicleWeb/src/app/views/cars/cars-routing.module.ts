import { NgModule } from '@angular/core';
import {
  Routes,
  RouterModule
} from '@angular/router';

import { CarsComponent } from './cars.component';
import { CarsNewComponent } from './manage/cars-new.component';
import { CarsViewComponent } from './manage/cars-view.component';
import { CarsMaintenanceComponent } from './maintenance/maintenance-view.component';
import { CarsMaintenanceNewComponent } from './maintenance/maintenance-new.component';
import { CarsDocumentNewComponent } from './document/document-new.component';
import { CarsDocumentComponent } from './document/document-view.component';
import { CarsUpdateComponent } from './manage/cars-update.component';

const routes: Routes = [
  {
    path: 'searchcars',
    component: CarsComponent,
    data: {
      title: 'Search Cars'
    }
  },
  {
    path: 'newcars',
    component: CarsNewComponent,
    data: {
      title: 'Add New Cars'
    }
  },
  {
    path: 'updatecars/:id',
    component: CarsUpdateComponent,
    data: {
      title: 'Update Cars'
    }
  },
  {
    path: 'viewcars',
    component: CarsViewComponent,
    data: {
      title: 'View Cars'
    }
  },
  {
    path: 'searchdocumentcars',
    component: CarsDocumentComponent,
    data: {
      title: 'View Document Cars'
    }
  },
  {
    path: 'newdocumentcars',
    component: CarsDocumentNewComponent,
    data: {
      title: 'New Document Cars'
    }
  },
  {
    path: 'searchmaintenance',
    component: CarsMaintenanceComponent,
    data: {
      title: 'View Cars Maintenance'
    }
  },
  {
    path: 'newmaintenance',
    component: CarsMaintenanceNewComponent,
    data: {
      title: 'New Cars Maintenance'
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CarsRoutingModule { }
