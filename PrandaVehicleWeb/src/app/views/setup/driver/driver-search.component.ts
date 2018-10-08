import { DriverService } from './../../../services/driver.services';
import { Component, OnInit, ViewChild, ViewContainerRef } from '@angular/core';
import { Router } from '@angular/router';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { ModalDialogService } from 'ngx-modal-dialog';
import { AuthService } from '../../../services/auth.services';



@Component({
  templateUrl: 'driver-search.component.html'
})
export class DriverSearchComponent implements OnInit {

  public criteria: any;
  mSearch: any;
  mStatus = status;
  mRole: any = 'REQUEST';
  mView: any;
  constructor(
    private route: Router,
    private auth: AuthService,
    private driver: DriverService,
    private viewRef: ViewContainerRef) {
    this.criteria = {
      status: -1
    };
    this.mSearch = {};
    this.onSearch();
    this.mRole = auth.getRole();
    // if (window.localStorage.getItem('token') !== null) {
    //   this.courses.find({ courseItems: { courseID: 0, companyID: 0, courseName: '', useFlag: 1, startDate: '', endDate: '' } }).subscribe(result => {
    //     this.mCourse = result;
    //   });
    // } else {
    //   this.route.navigate(['pages/login']);
    // }
  }
  ngOnInit() {

  }
  onSearch() {
    this.driver.find(this.criteria).subscribe(result => {
      this.mSearch = result;
    });
  }
}

const status = [
  {
    text: 'ทั้งหมด',
    value: -1
  },
  {
    text: 'ใช้งาน',
    value: 1
  },
  {
    text: 'ไม่ใช้งาน',
    value: 2
  }
]
