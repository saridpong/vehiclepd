

import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { CarsInComponent } from './management/cars-in.component';
import { CarsOutComponent } from './management/cars-out.component';
import { AuthService } from '../../services/auth.services';
import { RequestService } from '../../services/request.services';

@Component({
  templateUrl: 'security.component.html'
})
export class SecurityComponent implements OnInit {

  public datenow: Date = new Date();
  criteria: any;
  mSearch: any;
  bsModalRef: BsModalRef;
  constructor(private modalService: BsModalService,
    private auth: AuthService,
    private request: RequestService) {
    this.criteria = {
      status : -1
    };
    this.mSearch = [];
    this.onSearch();
  }
  onSearch() {
    this.request.find(this.criteria).subscribe(result => {
      this.mSearch = result;
    });
  }
  CarsInOpen(data) {
    const initialState = {
      item: data
    };
    this.bsModalRef = this.modalService.show(CarsInComponent, { initialState });
    this.bsModalRef.content.closeBtnName = 'Close';
  }
  CarsOutOpen(data) {
    const initialState = {
      item: data
    };
    this.bsModalRef = this.modalService.show(CarsOutComponent, { initialState });
    this.bsModalRef.content.closeBtnName = 'Close';
  }
  ngOnInit() {

  }
}

export const carsinout = [

  {
    no: '1',
    operationDate: '22/03/2018',
    carPic: 'assets/img/carinout/Screen Shot 2561-08-16 at 17.50.58.png',
    regCar: 'กก-1234',
    driverPic: 'assets/img/carinout/Screen Shot 2561-08-16 at 17.51.06.png',
    driverName: 'ชื่อ นามสกุล',
    milesOut: '0',
    dateOut: new Date(),
    milesIn: '100',
    dateIn: new Date(),
    employeeId: '00543'
  },
  {
    no: '2',
    operationDate: '22/03/2018',
    carPic: 'assets/img/carinout/Screen Shot 2561-08-16 at 17.51.02.png',
    regCar: 'กก-5678',
    driverPic: 'assets/img/carinout/Screen Shot 2561-08-16 at 17.51.10.png',
    driverName: 'ชื่อ2 นามสกุล2',
    milesOut: '32423',
    dateOut: new Date(),
    milesIn: '124211',
    dateIn: new Date(),
    employeeId: '00544'
  }
]
