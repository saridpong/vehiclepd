import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Globals, AuthenData } from '../globals/globals';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import 'rxjs/add/operator/map';

@Injectable()
export class LanguageService {

    private messageSource = new BehaviorSubject<any>(null);
    currentMessage = this.messageSource.asObservable();
    constructor(private http: HttpClient, private global: Globals) { }

    GetLanguages(criteria): Observable<any> {
        return this.http.post<any>(this.global.BaseApiUrl  + 'api/Languages/Management/Find', criteria)
    }

    AddLanguages(criteria): Observable<any> {
        return this.http.post<any>(this.global.BaseApiUrl  + 'api/Languages/Management/add', criteria)
    }

    UpdateLanguages(criteria): Observable<any> {
        return this.http.post<any>(this.global.BaseApiUrl  + 'api/Languages/Management/update', criteria)
    }

find(criteria): Observable<any> {
        return this.http.post<any>(this.global.BaseApiUrl + 'api/languages/management/find', criteria)
    }

}


