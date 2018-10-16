import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Globals, AuthenData } from '../globals/globals';
import 'rxjs/add/operator/map';

@Injectable()
export class AssignService {
  constructor(private http: HttpClient, private global: Globals) { }

  new(criteria): Observable<any> {
    return this.http.post<any>(
      this.global.BaseApiUrl + 'api/Assign/New',
      criteria
    );
  }
  update(criteria): Observable<any> {
    return this.http.post<any>(
      this.global.BaseApiUrl + 'api/Assign/Update',
      criteria
    );
  }
  approve(criteria): Observable<any> {
    return this.http.post<any>(
      this.global.BaseApiUrl + 'api/Assign/Approve',
      criteria
    );
  }

  find(criteria): Observable<any> {
    return this.http.post<any>(
      this.global.BaseApiUrl + 'api/Assign/Find',
      criteria
    );
  }
  findbyid(criteria): Observable<any> {
    return this.http.post<any>(
      this.global.BaseApiUrl + 'api/Assign/FindByID',
      criteria
    );
  }

}
