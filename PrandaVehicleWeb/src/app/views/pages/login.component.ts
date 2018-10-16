import { AuthenData, Globals } from '../../globals/globals';
import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.services';
import { Router } from '@angular/router';
import { UserService } from '../../services/user.services';
import { InformationService } from '../../services/information.services';

@Component({
  templateUrl: 'login.component.html'
})
export class LoginComponent {
  public criteria: any;
  mUsername: string = '';
  mPassword: string = '';
  role: string = '';
  informationdata: any;
  constructor(
    private auth: AuthService,
    private route: Router,
    private global: Globals,
    private userService: UserService,
    private information: InformationService
  ) {
    this.criteria = {
      status: -1
    };
    this.onSearch();
   }
  onSubmit() {
    // this.route.navigate(['/Request']);
    /*
    if (this.mUsername === 'admin') {
      this.role = 'ADMIN'
      this.route.navigate(['/cars/searchcars']);
    } else if (this.mUsername === 'security') {
      this.role = 'SECURITY'
      this.route.navigate(['/security']);
    } else if (this.mUsername === 'request') {
      this.role = 'REQUEST'
      this.route.navigate(['/request/searchrequest']);
    }
    window.localStorage.setItem('role', this.role);
    */

    this.auth.login(this.mUsername, this.mPassword).subscribe(
      result => {
        window.localStorage.setItem('token', JSON.stringify(result));
        window.localStorage.setItem('role', result.role);
        if (result.role === 'ADMIN') {
          this.route.navigate(['/requests/search']);
        } else if (result.role === 'SECURITY') {
          this.route.navigate(['/security']);
        } else if (result.role === 'REQUEST') {
          this.route.navigate(['/requests/search']);
        } else {
          window.alert('Login again');
        }
      },
      error => {
        window.alert(error);
      }
    );

  }
  onSearch() {
    this.information.find(this.criteria).subscribe(result => {
      this.informationdata = result.informationLoginData.informationLoginData;
    });
  }
}
