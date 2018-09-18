import { AuthService } from '../../services/auth.services';
import { Component } from '@angular/core';

@Component({
  selector: 'app-header-no-sidebar',
  templateUrl: './app-header-no-sidebar.component.html'
})
export class AppHeaderNoSidebarComponent {

  constructor(private auth: AuthService) { }
  logout() {
    this.auth.logout();
  }
}
