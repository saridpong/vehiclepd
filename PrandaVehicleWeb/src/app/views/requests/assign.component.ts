import { AssignService } from './../../services/assign.services';
import { RequestService } from './../../services/request.services';
import { AuthService } from '../../services/auth.services';
import { Component, OnInit, ViewChild, ViewContainerRef } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { ModalDialogService } from 'ngx-modal-dialog';
import { ToastrService } from 'ngx-toastr';



@Component({
  templateUrl: 'assign.component.html'
})
export class AssignComponent implements OnInit {

  public criteria: any;
  private token = this.auth.getToken();
  public read: boolean = false;
  constructor(
    private auth: AuthService,
    private assign: AssignService,
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
      assigns: {
        dueDate: new Date(),
        lines: [],
        statusDesc: 'รออนุมัติ',
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
  }

  bindData() {
    const id = this.router.snapshot.paramMap.get('id');
    const findbyid = {
      assignHeaderID: id
    }
    this.assign.findbyid(findbyid).subscribe(result => {
      this.criteria = result.assign;
    });
  }
  ngOnInit() {

  }
  onSubmit() {
    const role = this.router.snapshot.data['role'];
    if (role === undefined) {
      this.assign.new(this.criteria).subscribe(result => {
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
            assigns: {
              status: 1,
              dueDate: new Date(),
              lines: [],
              statusDesc: 'รออนุมัติ',
            }
          };
        } else {
          this.toastr.error('Create Failed.', 'New Request');
        }
      });
    } else if (role === 'update') {
      this.assign.update(this.criteria).subscribe(result => {
        if (result.responseStatus === 1) {
          this.toastr.success('Update Success.', result.description);
          this.route.navigate(['requests/assign/search']);
        } else {
          this.toastr.error('Update Failed.', 'Update Request');
        }
      });
    }

  }

}

