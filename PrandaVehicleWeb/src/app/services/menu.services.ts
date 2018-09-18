import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Globals, AuthenData } from '../globals/globals';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import 'rxjs/add/operator/map';

@Injectable()
export class MenuService {
    constructor(private http: HttpClient, private global: Globals) { }

    NewMenu(criteria): Observable<any> {
        return this.http.post<any>(this.global.BaseApiUrl + 'api/menu/newmenu', criteria)
    }
    UpdateMenu(criteria): Observable<any> {
        return this.http.post<any>(this.global.BaseApiUrl + 'api/menu/updatemenu', criteria)
    }
    GetAllMenu(): Observable<any> {
        return this.http.post<any>(this.global.BaseApiUrl + 'api/menu/collection', null)
    }
    GetRoots(): Observable<any> {
        return this.http.get<any>(this.global.BaseApiUrl + 'api/menu/root')
    }
    GetByID(id: any): Observable<any> {
        return this.http.get<any>(this.global.BaseApiUrl + 'api/menu/getbyid/' + id)
    }
    SortMenu(criteria): Observable<any> {
        return this.http.post<any>(this.global.BaseApiUrl + 'api/menu/sort', criteria)
    }
    GetRoles(): Observable<any> {
        return this.http.get<any>(this.global.BaseApiUrl + 'api/menu/roles')
    }
    NewRoles(criteria): Observable<any> {
        return this.http.post<any>(this.global.BaseApiUrl + 'api/menu/newrole', criteria)
    }
    UpdateRole(criteria): Observable<any> {
        return this.http.post<any>(this.global.BaseApiUrl + 'api/menu/updaterole', criteria)
    }
    GetRoleByID(id: any): Observable<any> {
        return this.http.get<any>(this.global.BaseApiUrl + 'api/menu/getrolebyid/' + id)
    }
    GetRoleDetail(id: any): Observable<any> {
        return this.http.get<any>(this.global.BaseApiUrl + 'api/menu/roledetail/' + id)
    }
    SettingRole(criteria): Observable<any> {
        return this.http.post<any>(this.global.BaseApiUrl + 'api/menu/permission_update', criteria)
    }
}

