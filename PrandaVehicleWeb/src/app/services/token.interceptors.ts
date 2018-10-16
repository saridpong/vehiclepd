
import { Injectable } from '@angular/core';
import {
    HttpRequest,
    HttpHandler,
    HttpEvent,
    HttpInterceptor
} from '@angular/common/http';
import { AuthService } from './auth.services';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw'
import 'rxjs/add/operator/catch';
@Injectable()
export class TokenInterceptor implements HttpInterceptor {
    constructor(public auth: AuthService) { }
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if (request.headers.get('content-type') !== 'application/x-www-form-urlencoded') {
            const token = this.auth.getToken();
            if (token != null) {
                const authReq = request.clone({
                    headers: request.headers.set('Authorization', 'Bearer ' + token.access_token)
                });
                return next.handle(authReq);
            } else {
                return next.handle(request)
            }
        } else {
            return next.handle(request)
        }

    }
}
