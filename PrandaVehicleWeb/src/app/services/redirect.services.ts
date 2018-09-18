import { AuthService } from './auth.services';
import { CanActivate, Router } from '@angular/router';
import { Injectable } from '@angular/core';

@Injectable()
export class RedirectService implements CanActivate {
    constructor(private router: Router,
        private auth: AuthService) { }

    canActivate(): boolean {
        const user = this.auth.getToken();
        if (user !== null) {
            if (user.role === 'FRONT') {
                this.router.navigate(['/dashboard']);
                // } else if (user.role === 'ADMIN') {
                //     this.router.navigate(['/menu/management']);
                // } else if (user.role === 'SCURITY') {
                //     this.router.navigate(['/menu/management']);
            } else {
                this.router.navigate(['/pages/login']);
            }
        } else {
            this.router.navigate(['/pages/login']);
        }
        return true;
    }
}
