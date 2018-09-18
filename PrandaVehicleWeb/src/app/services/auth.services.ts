import { Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Globals, AuthenData } from '../globals/globals';
import 'rxjs/add/operator/map';

@Injectable()
export class AuthService {

    constructor(private http: HttpClient, private route: Router, private global: Globals) { }

    public getToken(): any {
        return JSON.parse(localStorage.getItem('token'));
    }

    public getRole(): string {
        const token = JSON.parse(localStorage.getItem('token'));
        return token.role;
    }

    login(username, password): Observable<AuthenData> {
        const body = new HttpParams()
            .set('username', username)
            .set('password', password)
            .set('grant_type', 'password');

        return this.http.post<AuthenData>(this.global.BaseApiUrl + 'token',
            body.toString(),
            {
                headers: new HttpHeaders()
                    .set('Content-Type', 'application/x-www-form-urlencoded')
            })
    }

    logout() {
        window.localStorage.removeItem('token');
        this.route.navigate(['/pages/login']);
    }
}




