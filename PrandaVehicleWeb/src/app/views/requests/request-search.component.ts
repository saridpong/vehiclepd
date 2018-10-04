import { RequestService } from './../../services/request.services';
import { CoursesService } from '../../services/courses.services';
import { Component, OnInit, ViewChild, ViewContainerRef } from '@angular/core';
import { Router } from '@angular/router';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { ModalDialogService } from 'ngx-modal-dialog';
import { AuthService } from '../../services/auth.services';



@Component({
  templateUrl: 'request-search.component.html'
})
export class RequestSearchComponent implements OnInit {

  public criteria: any;
  mSearch: any;
  mStatus = status;
  mRole: any = 'REQUEST';
  mView: any;
  constructor(
    private route: Router,
    private auth: AuthService,
    private request: RequestService,
    private viewRef: ViewContainerRef) {
    this.criteria = {
      status: -1
    };
    this.mSearch = {};
    this.onSearch();
    this.mRole = auth.getRole();
    if (this.mRole === 'ADMIN') {
      this.mView = {
        approve: true,
        rating: true,
        labour: true
      }
    } else if (this.mRole === 'REQUEST') {
      this.mView = {
        approve: false,
        rating: true,
        labour: false
      }
    }
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
  onView(item) {
    if (item.status === 1) {
      this.route.navigate(['requests/view/' + item.requestHeaderID]);
    } else if (item.status === 2 || item.status === 3) {
      this.route.navigate(['requests/approve/view/' + item.requestHeaderID]);
    } else if (item.status === 4) {
      this.route.navigate(['requests/rating/view/' + item.requestHeaderID]);
    } else if (item.status === 5 || item.status === 6) {
      this.route.navigate(['requests/labourcost/view/' + item.requestHeaderID]);
    }
  }
  onEdit(item) {
    this.route.navigate(['requests/update/' + item.requestHeaderID]);
  }
  onApprove(item) {
    this.route.navigate(['requests/approve/' + item.requestHeaderID]);
  }
  onRating(item) {
    this.route.navigate(['requests/rating/' + item.requestHeaderID]);
  }
  onLabourCost(item) {
    this.route.navigate(['requests/labourcost/' + item.requestHeaderID]);
  }
  onSearch() {
    this.request.find(this.criteria).subscribe(result => {
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
    text: 'รออนุมัติ',
    value: 1
  },
  {
    text: 'อนุมัติ',
    value: 2
  },
  {
    text: 'รถออก',
    value: 3
  },
  {
    text: 'รอให้คะแนน',
    value: 4
  },
  {
    text: 'รอบันทึกค่าแรง',
    value: 5
  },
  {
    text: 'ปิดงาน',
    value: 6
  },
  {
    text: 'ยกเลิก',
    value: 7
  },
  {
    text: 'รออนุมัติและอนุมัติ',
    value: 8
  }
]
