import { AuthService } from './auth.services';
import { CanActivate, Router } from '@angular/router';
import { Injectable } from '@angular/core';

@Injectable()
export class RedirectService implements CanActivate {
  constructor(private router: Router, private auth: AuthService) {}

  canActivate(): boolean {
    const user = this.auth.getToken();
    if (user !== null) {
      if (user.role === 'ADMIN') {
        this.router.navigate(['/cars/searchcars']);
      } else if (user.role === 'SECURITY') {
        this.router.navigate(['/security']);
      } else if (user.role === 'REQUEST') {
        this.router.navigate(['/requests/search']);
      } else {
        this.router.navigate(['/pages/login']);
      }
    } else {
      this.router.navigate(['/pages/login']);
    }
    return true;
  }
}
