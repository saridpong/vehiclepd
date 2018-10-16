import { Component, OnInit, ViewChild, ViewContainerRef } from '@angular/core';
import { Router } from '@angular/router';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { ModalDialogService } from 'ngx-modal-dialog';
import { AuthService } from '../../../services/auth.services';
import { ToastrService } from 'ngx-toastr';
import { InformationService } from '../../../services/information.services';


@Component({
  templateUrl: 'information-search.component.html'
})
export class InformationSearchComponent implements OnInit {

  public criteria: any;
  mSearch: any;
  mStatus = status;
  mRole: any = 'REQUEST';
  mView: any;
  constructor(
    private toastr: ToastrService,
    private route: Router,
    private auth: AuthService,
    private information: InformationService,
    private viewRef: ViewContainerRef) {
    this.criteria = {
      status: -1
    };
    this.mSearch = {};
    this.onSearch();
    this.mRole = auth.getRole();

  }
  ngOnInit() {

  }
  onSearch() {
    this.information.find(this.criteria).subscribe(result => {
      this.criteria = result.informationLoginData;
    });
  }

  onSubmit() {
    this.information.update(this.criteria).subscribe(result => {
      if (result.responseStatus === 1) {
        this.toastr.success('Update Success.', result.description);
        this.onSearch();
      } else {
        this.toastr.error('Update Failed.', result.description);
      }
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
