import { AuthService } from '../../services/auth.services';
import { Component } from '@angular/core';
 import { NgModule } from '@angular/core';
 import { CommonModule } from '@angular/common';
 import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    FormsModule
  ]
})

@Component({
  selector: 'app-header-left-sidebar',
  templateUrl: './app-header-left-sidebar.component.html'
})
export class AppHeaderLeftSidebarComponent {

  myClass: string;
  mLanguage: any;
  constructor(private auth: AuthService) {

  }
  logout() {
    this.auth.logout();
  }
  changeLanguage(lang) {
    this.myClass = 'flag-icon flag-icon-' + lang;
  }
}
