import { RequestService } from './../../services/request.services';
import { AuthService } from '../../services/auth.services';
import { Component, OnInit, ViewChild, ViewContainerRef } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { ModalDialogService } from 'ngx-modal-dialog';
import { ToastrService } from 'ngx-toastr';



@Component({
  templateUrl: 'requests.component.html'
})
export class RequestsComponent implements OnInit {

  public criteria: any;
  private token = this.auth.getToken();
  public read: boolean = false;
  constructor(
    private auth: AuthService,
    private request: RequestService,
    private toastr: ToastrService,
    private route: Router,
    private router: ActivatedRoute,
    private modalService: ModalDialogService,
    private viewRef: ViewContainerRef) {


    const role = this.router.snapshot.data['role'];
    this.criteria = {
      staff: {
        employeeName: this.token.fullName,
        departmentName: this.token.department,
        groupName: this.token.section,
        approver: this.token.approver,
        position: this.token.position,
        employeeTel: this.token.tel,
        employeeMobile: this.token.mobile
      },
      requests: {
        forUse: {},
        endDate: new Date(),
        startDate: new Date(),
        status: 1,
        statusDesc: 'รออนุมัติ',
        places: []
      }
    };
    if (role === undefined) {

    } else if (role === 'view') {
      this.read = true;
      this.bindData();

    } else if (role === 'update') {
      this.read = false;
      this.bindData();
    }
    // if (window.localStorage.getItem('token') !== null) {
    //   this.courses.find({ courseItems: { courseID: 0, companyID: 0, courseName: '', useFlag: 1, startDate: '', endDate: '' } }).subscribe(result => {
    //     this.mCourse = result;
    //   });
    // } else {
    //   this.route.navigate(['pages/login']);
    // }
  }

  bindData() {
    const id = this.router.snapshot.paramMap.get('id');
    const findbyid = {
      requestHeaderID: id
    }
    this.request.findbyid(findbyid).subscribe(result => {
      if (result.carRequest.requests.forUse === undefined || result.carRequest.requests.forUse === null) {
        result.carRequest.requests.forUse = {};
      }
      this.criteria = result.carRequest;
    });
  }
  ngOnInit() {

  }
  onSubmit() {
    const role = this.router.snapshot.data['role'];
    if (role === undefined) {
      this.request.new(this.criteria).subscribe(result => {
        if (result.responseStatus === 1) {
          this.toastr.success('Create Success.', result.description);
          this.criteria = {
            staff: {
              employeeName: this.token.fullName,
              departmentName: this.token.department,
              groupName: this.token.section,
              approver: this.token.approver,
              position: this.token.position,
              employeeTel: this.token.tel,
              employeeMobile: this.token.mobile
            },
            requests: {
              status: 1,
              forUse: {},
              statusDesc: 'รออนุมัติ',
              places: []
            }
          };
        } else {
          this.toastr.error('Create Failed.', 'New Request');
        }
      });
    } else if (role === 'update') {
      this.request.update(this.criteria).subscribe(result => {
        if (result.responseStatus === 1) {
          this.toastr.success('Update Success.', result.description);
          this.route.navigate(['requests/search']);
        } else {
          this.toastr.error('Update Failed.', 'Update Request');
        }
      });
    }
  }

}

