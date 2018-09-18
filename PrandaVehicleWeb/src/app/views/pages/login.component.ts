import { AuthenData, Globals } from '../../globals/globals';
import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.services';
import { Router } from '@angular/router';
import { UserService } from '../../services/user.services';

@Component({
  templateUrl: 'login.component.html'
})
export class LoginComponent {
  mUsername: string = '';
  mPassword: string = '';
  role: string = '';
  constructor(
    private auth: AuthService,
    private route: Router,
    private global: Globals,
    private userService: UserService
  ) {}
  onSubmit() {
    // this.route.navigate(['/Request']);

    /*if (this.mUsername === 'admin') {
      this.role = 'ADM'
    } else if (this.mUsername === 'security') {
      this.role = 'SCU'
    } else if (this.mUsername === 'request') {
      this.role = 'REQ'
    }*/

    this.auth.login(this.mUsername, this.mPassword).subscribe(
      result => {
        window.localStorage.setItem('token', JSON.stringify(result));
        window.localStorage.setItem('role', result.role);
        if (result.role === 'ADMIN') {
          this.route.navigate(['/cars/searchcars']);
        } else if (result.role === 'SECURITY') {
          this.route.navigate(['/security']);
        } else if (result.role === 'REQUEST') {
          this.route.navigate(['/request/searchrequest']);
        } else {
          window.alert('Login again');
        }
      },
      error => {
        window.alert(error);
      }
    );
  }
}
