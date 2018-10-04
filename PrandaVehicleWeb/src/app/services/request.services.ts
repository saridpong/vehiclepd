import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Globals, AuthenData } from '../globals/globals';
import 'rxjs/add/operator/map';

@Injectable()
export class RequestService {
  constructor(private http: HttpClient, private global: Globals) {}

  new(criteria): Observable<any> {
    return this.http.post<any>(
      this.global.BaseApiUrl + 'api/Request/New',
      criteria
    );
  }
  update(criteria): Observable<any> {
    return this.http.post<any>(
      this.global.BaseApiUrl + 'api/Request/Update',
      criteria
    );
  }
  approve(criteria): Observable<any> {
    return this.http.post<any>(
      this.global.BaseApiUrl + 'api/Request/Approve',
      criteria
    );
  }

  find(criteria): Observable<any> {
    return this.http.post<any>(
      this.global.BaseApiUrl + 'api/Request/Find',
      criteria
    );
  }
  findbyid(criteria): Observable<any> {
    return this.http.post<any>(
      this.global.BaseApiUrl + 'api/Request/FindByID',
      criteria
    );
  }
  vehicleout(criteria): Observable<any> {
    return this.http.post<any>(
      this.global.BaseApiUrl + 'api/Request/VehicleOut',
      criteria
    );
  }
  vehiclein(criteria): Observable<any> {
    return this.http.post<any>(
      this.global.BaseApiUrl + 'api/Request/VehicleIn',
      criteria
    );
  }
}
