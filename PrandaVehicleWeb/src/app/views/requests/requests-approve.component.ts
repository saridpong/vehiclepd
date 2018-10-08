import { CoursesService } from '../../services/courses.services';
import { Component, OnInit, ViewChild, ViewContainerRef } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { ModalDialogService } from 'ngx-modal-dialog';
import { RequestService } from '../../services/request.services';
import { ToastrService } from 'ngx-toastr';



@Component({
  templateUrl: 'requests-approve.component.html'
})
export class RequestsApproveComponent implements OnInit {

  public criteria: any;
  public read: boolean = true;
  public readApprove: boolean = false;
  constructor(
    private request: RequestService,
    private toastr: ToastrService,
    private route: Router,
    private router: ActivatedRoute,
    private modalService: ModalDialogService,
    private viewRef: ViewContainerRef) {
    const role = this.router.snapshot.data['role'];
    this.criteria = {
      staff: {},
      requests: {
        forUse: {},
        driver: {},
        vehicle: {},
        places: []
      },
      approve: {}
    };
    if (role === 'view') {
      this.readApprove = true;
    }
    this.bindData();

  }
  ngOnInit() {

  }
  bindData() {
    const id = this.router.snapshot.paramMap.get('id');
    const findbyid = {
      requestHeaderID: id
    }
    this.request.findbyid(findbyid).subscribe(result => {
      if (result.carRequest.requests.driver === undefined) {
        result.carRequest.requests.driver = {};
      }
      if (result.carRequest.requests.vehicle === undefined) {
        result.carRequest.requests.vehicle = {};
      }
      if (result.carRequest.requests.forUse === undefined || result.carRequest.requests.forUse === null) {
        result.carRequest.requests.forUse = {};
      }
      this.criteria = result.carRequest;
    });
  }
  onSaveDraft() {
    this.criteria.requests.requestHeaderStatus = 1;
    this.request.approve(this.criteria).subscribe(result => {
      if (result.responseStatus === 1) {
        this.toastr.success('Update Success.', 'Save Draft');
        this.route.navigate(['requests/search']);
      } else {
        this.toastr.error('Update Failed.', 'Update Request');
      }
    });
  }

  onSubmit() {
    this.criteria.requests.requestHeaderStatus = 2;
    this.request.approve(this.criteria).subscribe(result => {
      if (result.responseStatus === 1) {
        this.toastr.success('Approve Success.', result.description);
        this.route.navigate(['requests/search']);
      } else {
        this.toastr.error('Approve Failed.', 'Approve Request');
      }
    });
  }
}
