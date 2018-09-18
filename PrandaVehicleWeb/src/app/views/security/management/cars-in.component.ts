import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalService } from 'ngx-bootstrap/modal';
import { BsModalRef } from 'ngx-bootstrap';


@Component({
  templateUrl: 'cars-in.component.html'
})
export class CarsInComponent implements OnInit {
  item: any = {};
  constructor(public bsModalRef: BsModalRef) { }
  ngOnInit() {

  }
}
/*
export const carsinout = [

  {
    no: '1',
    operationDate: '22/03/2018',
    carPic: '../../../assets/img/carinout/Screen Shot 2561-08-16 at 17.50.58.png',
    regCar: 'กก-1234',
    driverPic: '../../../assets/img/carinout/Screen Shot 2561-08-16 at 17.51.06.png',
    driverName: 'ชื่อ นามสกุล',
    milesOut: '0',
    dateOut: '08:24',
    milesIn: '100',
    dateIn: '17:22'
  },
  {
    no: '2',
    operationDate: '22/03/2018',
    carPic: '../../../assets/img/carinout/Screen Shot 2561-08-16 at 17.51.02.png',
    regCar: 'กก-5678',
    driverPic: '../../../assets/img/carinout/Screen Shot 2561-08-16 at 17.51.10.png',
    driverName: 'ชื่อ2 นามสกุล2',
    milesOut: '32423',
    dateOut: '08:24',
    milesIn: '124211',
    dateIn: '17:22'
  }
]
*/
