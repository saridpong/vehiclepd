import { Component, OnInit, ViewChild, ViewContainerRef } from '@angular/core';
import { Router } from '@angular/router';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { ModalDialogService } from 'ngx-modal-dialog';
import { AuthService } from '../../../services/auth.services';
import { ForUseService } from '../../../services/foruse.services';



@Component({
  templateUrl: 'foruse-search.component.html'
})
export class ForUseSearchComponent implements OnInit {

  public criteria: any;
  mSearch: any;
  mStatus = status;
  mRole: any = 'REQUEST';
  mView: any;
  constructor(
    private route: Router,
    private auth: AuthService,
    private foruse: ForUseService,
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
    this.foruse.find(this.criteria).subscribe(result => {
      this.mSearch = result;
    });
  }
  onNew() {
    this.route.navigate(['/setup/foruse/new']);
  }
  onEdit(item) {
    this.route.navigate(['/setup/foruse/edit/' + item.forUseID]);
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
