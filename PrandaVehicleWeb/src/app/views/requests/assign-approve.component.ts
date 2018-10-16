import { AssignService } from './../../services/assign.services';
import { RequestService } from './../../services/request.services';
import { AuthService } from '../../services/auth.services';
import { Component, OnInit, ViewChild, ViewContainerRef } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { ModalDialogService } from 'ngx-modal-dialog';
import { ToastrService } from 'ngx-toastr';



@Component({
  templateUrl: 'assign-approve.component.html'
})
export class AssignApproveComponent implements OnInit {

  public criteria: any;
  private token = this.auth.getToken();
  public read: boolean = true;
  public readApprove: boolean = false;
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
      staff: {},
      assigns: {
        dueDate: new Date(),
        driver: {},
        lines: [],
      }
    };
    if (role === 'view') {
      this.readApprove = true;
    }
    this.bindData();
  }

  bindData() {
    const id = this.router.snapshot.paramMap.get('id');
    const findbyid = {
      assignHeaderID: id
    }
    this.assign.findbyid(findbyid).subscribe(result => {
      if (result.assign.assigns.driver === undefined) {
        result.assign.assigns.driver = {};
      }
      this.criteria = result.assign;
    });
  }
  ngOnInit() {

  }
  onSaveDraft() {
    this.criteria.assigns.requestHeaderStatus = 1;
    this.assign.approve(this.criteria).subscribe(result => {
      if (result.responseStatus === 1) {
        this.toastr.success('Update Success.', 'Save Draft');
        this.route.navigate(['requests/assign/search']);
      } else {
        this.toastr.error('Update Failed.', 'Update Request');
      }
    });
  }

  onSubmit() {
    this.criteria.assigns.requestHeaderStatus = 2;
    this.assign.approve(this.criteria).subscribe(result => {
      if (result.responseStatus === 1) {
        this.toastr.success('Approve Success.', result.description);
        this.route.navigate(['requests/assign/search']);
      } else {
        this.toastr.error('Approve Failed.', 'New Request');
      }
    });
  }

}

