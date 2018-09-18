import { MenuEditComponent } from './managements/menu-edit.component';
import { CommonModule } from '@angular/common';
import { DndModule } from 'ng2-dnd';
import { MenuManagementComponent } from './menu-management.component';
import { FormsModule } from '@angular/forms';
import { MenuRoutingModule } from './menu-routing.module';
import { NgModule } from '@angular/core';
import { MenuNewComponent } from './managements/menu-new.component';
import { NgxSelectModule } from 'ngx-select-ex';
import { ToastrModule } from 'ngx-toastr';
import { MenuGroupComponent } from './menugroupmanagements/menu-group.component';
import { MenuNewGroupComponent } from './menugroupmanagements/menu-group-new.component';
import { MenuEditGroupComponent } from './menugroupmanagements/menu-group-edit.component';
import { SettingRoleComponent } from './menugroupmanagements/setting-role.component';


@NgModule({
  imports: [
    MenuRoutingModule,
    FormsModule,
    DndModule.forRoot(),
    CommonModule,
    NgxSelectModule,
    FormsModule,
    ToastrModule.forRoot({
      closeButton: true,
      timeOut: 2000,
      progressBar: true,
      positionClass: 'toast-bottom-right'
    })
  ],
  declarations: [
    MenuManagementComponent,
    MenuGroupComponent,
    MenuNewComponent,
    MenuEditComponent,
    MenuNewGroupComponent,
    MenuEditGroupComponent,
    SettingRoleComponent,
  ],
  entryComponents: [
    MenuNewComponent,
    MenuEditComponent,
    MenuNewGroupComponent,
    MenuEditGroupComponent,
    SettingRoleComponent,
  ],
})
export class MenuModule { }
