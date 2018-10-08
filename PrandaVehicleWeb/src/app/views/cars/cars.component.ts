import { CarsService } from './../../services/cars.services';
import { Component, OnInit, ViewChild, ViewContainerRef } from '@angular/core';
import { Router } from '@angular/router';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { ModalDialogService } from 'ngx-modal-dialog';

@Component({
  templateUrl: 'cars.component.html'
})
export class CarsComponent implements OnInit {
  public mData: any = [];
  options: any = [
    { key: -1, text: 'ทั้งหมด' },
    { key: 1, text: 'ใช้งาน' },
    { key: 2, text: 'ไม่ใช้งาน' }
  ];
  public mCriteria: any = {
    status: 1,
    docNo: '',
    docDate: ''
  };
  constructor(
    private cars: CarsService,
    private route: Router,
    private router: Router,
    private modalService: ModalDialogService,
    private viewRef: ViewContainerRef
  ) {
    if (window.localStorage.getItem('token') !== null) {
      this.cars.find(this.mCriteria).subscribe(result => {
        this.mData = result;
      });
    } else {
      this.route.navigate(['pages/login']);
    }
  }
  ngOnInit() {}

  onSearch() {
    this.cars.find(this.mCriteria).subscribe(result => {
      this.mData = result;
    });
  }

  onView(item) {
    this.router.navigate(['cars/updatecars', item.vehicleID]);
  }
  onNewDocument() {
    this.router.navigate(['cars/newdocumentcars']);
  }
}
