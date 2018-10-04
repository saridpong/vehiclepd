import { PlaceService } from './../../services/place.services';
import { Component, Input, OnInit, NgModule, Output, EventEmitter, OnChanges } from '@angular/core';


@Component({
  selector: 'app-place',
  templateUrl: './app-place.component.html'
})
export class AppPlaceComponent implements OnInit {

  items: any;
  @Input() selectItem: any = {};
  @Output() selectItemChange = new EventEmitter();
  constructor(private place: PlaceService) {
    this.items = {
      places: []
    }
  }

  ngOnInit() {
    if (this.selectItem === null || this.selectItem === undefined) {
      this.selectItem = {};
    }
    const criteria = { status: 1 };
    this.place.find(criteria).subscribe(result => {
      this.items = result;
    })
  }
  OnChanges($event) {
    this.selectItemChange.emit(this.selectItem);
  }
}
