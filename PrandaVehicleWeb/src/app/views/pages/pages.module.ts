
import { NgModule } from '@angular/core';

import { LoginComponent } from './login.component';
import { PagesRoutingModule } from './pages-routing.module';
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [PagesRoutingModule, FormsModule],
  declarations: [
    LoginComponent
  ]
})
export class PagesModule { }
