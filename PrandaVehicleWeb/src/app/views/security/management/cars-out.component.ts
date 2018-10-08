import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { BsModalService } from 'ngx-bootstrap/modal';
import { BsModalRef } from 'ngx-bootstrap';
import { AuthService } from '../../../services/auth.services';
import { RequestService } from '../../../services/request.services';
import { ToastrService } from 'ngx-toastr';
import { Subject } from 'rxjs/Subject';


@Component({
  templateUrl: 'cars-out.component.html'
})
export class CarsOutComponent implements OnInit {
  item: any = {};
  public onClose: Subject<any>;
  constructor(public bsModalRef: BsModalRef,
    private auth: AuthService,
    private request: RequestService,
    private toastr: ToastrService,
    private route: Router,
    private router: ActivatedRoute) {
    this.onClose = new Subject();
  }
  ngOnInit() {

  }
  onSubmit() {
    this.item.vehicleTimeOut = new Date();
    this.request.vehicleout(this.item).subscribe(result => {
      if (result.responseStatus === 1) {
        this.route.navigate(['/security']);
        this.toastr.success('Vehicle Out Success.', result.description);
      } else {
        this.toastr.error('Vehicle Out Failed.', 'Vehicle Out Save');
      }
    });
    this.onClose.next({});
    this.bsModalRef.hide()
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
