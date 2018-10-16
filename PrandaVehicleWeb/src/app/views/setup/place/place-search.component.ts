import { Component, OnInit, ViewChild, ViewContainerRef } from '@angular/core';
import { Router } from '@angular/router';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { ModalDialogService } from 'ngx-modal-dialog';
import { AuthService } from '../../../services/auth.services';
import { PlaceService } from '../../../services/place.services';



@Component({
  templateUrl: 'place-search.component.html'
})
export class PlaceSearchComponent implements OnInit {

  public criteria: any;
  mSearch: any;
  mStatus = status;
  mRole: any = 'REQUEST';
  mView: any;
  constructor(
    private route: Router,
    private auth: AuthService,
    private place: PlaceService,
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
    this.place.find(this.criteria).subscribe(result => {
      this.mSearch = result;
    });
  }
  onNew() {
    this.route.navigate(['/setup/place/new']);
  }
  onEdit(item) {
    this.route.navigate(['/setup/place/edit/' + item.placeID]);
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
