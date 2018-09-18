import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Globals, AuthenData } from '../globals/globals';
import 'rxjs/add/operator/map';

@Injectable()
export class CoursesService {

    constructor(private http: HttpClient) { }


    find(criteria): Observable<any> {
        return this.http.post<any>('https://elearningapidev.azurewebsites.net/api/course/management/find', criteria)
    }
}


