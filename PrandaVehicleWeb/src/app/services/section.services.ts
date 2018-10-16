import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Globals, AuthenData } from '../globals/globals';
import 'rxjs/add/operator/map';

@Injectable()
export class SectionService {
  constructor(private http: HttpClient, private global: Globals) {}

  find(criteria): Observable<any> {
    return this.http.post<any>(
      this.global.BaseApiUrl + 'api/Section/Find',
      criteria
    );
  }
}
