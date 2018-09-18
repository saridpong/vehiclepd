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
  constructor(/*private auth: AuthService,*/ private route: Router, private global: Globals, private userService: UserService) { }
  onSubmit() {
    // this.route.navigate(['/Request']);

    if (this.mUsername === 'admin') {
      this.role = 'ADM'
    } else if (this.mUsername === 'security') {
      this.role = 'SCU'
    } else if (this.mUsername === 'request') {
      this.role = 'REQ'
    }
    window.localStorage.setItem('role', this.role)
    if (this.role === 'ADM') {
      this.route.navigate(['/admin']);
       this.route.navigate(['/cars/searchcars'])
    } else if (this.role === 'SCU') {
      this.route.navigate(['/security']);
    } else if (this.role === 'REQ') {
      this.route.navigate(['/request/searchrequest']);
    } else {
      window.alert('Login again');
    }


    // this.auth.login(this.mUsername, this.mPassword).subscribe(result => {
    //   window.localStorage.setItem('token', JSON.stringify(result));
    //   if (result.role === 'FRONT') {
    //     this.route.navigate(['/dashboard']);
    //   } else {
    //     this.userService.Intitial().subscribe(init => {
    //       this.global.setCookie('sidebar', init);
    //       // this.route.navigate(['/menu/management']);
    //       this.route.navigate(['/dashboard']);
    //     });
    //   }
    // }, error => {
    //   window.alert(error);
    // });
  }

}
