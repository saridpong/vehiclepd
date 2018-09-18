import { NgModule } from '@angular/core';
import { Routes,
     RouterModule } from '@angular/router';

import { SecurityComponent } from './security.component';

const routes: Routes = [
  {
    path: '',
    component: SecurityComponent,
    data: {
      title: 'Security'
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SecurityRoutingModule {}
