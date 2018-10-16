import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Globals, AuthenData } from '../globals/globals';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import 'rxjs/add/operator/map';

@Injectable()
export class UserService {

    constructor(private http: HttpClient, private global: Globals) { }

    forgetPassword(criteria): Observable<any> {
        return this.http.post<any>(this.global.BaseApiUrl + 'api/user/forgetpassword', criteria)
    }
    Intitial(): Observable<any> {
        return this.http.post<any>(this.global.BaseApiUrl + 'api/user/initial', null)
    }
    find(criteria): Observable<any> {
        return this.http.post<any>(
            this.global.BaseApiUrl + 'api/User/Find', criteria);
    }
    findbyid(criteria): Observable<any> {
        return this.http.post<any>(
            this.global.BaseApiUrl + 'api/User/FindByID', criteria);
    }
    newUser(criteria): Observable<any> {
        return this.http.post<any>(this.global.BaseApiUrl + 'api/User/NewUser', criteria)
    }
    updateUser(criteria): Observable<any> {
        return this.http.post<any>(this.global.BaseApiUrl + 'api/User/Update', criteria)
    }

}


