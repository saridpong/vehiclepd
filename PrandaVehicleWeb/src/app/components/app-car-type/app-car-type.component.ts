import { CarTypeService } from './../../services/cartype.services';
import { ForUseService } from './../../services/foruse.services';
import { Component, Input, OnInit, NgModule, forwardRef, OnChanges, Output, EventEmitter } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';


@Component({
  selector: 'app-car-type',
  templateUrl: './app-car-type.component.html'
})
export class AppCarTypeComponent implements OnInit {
  items: any;
  @Input() selectItem: any;
  @Input() read: boolean;
  @Output() selectItemChange = new EventEmitter();
  constructor(private cartype: CarTypeService) {
    this.items = {
      carTypes: []
    }
  }

  ngOnInit() {
    if (this.selectItem === null || this.selectItem === undefined) {
      this.selectItem = {};
    }
    const criteria = { status: 1 };
    this.cartype.find(criteria).subscribe(result => {
      this.items = result;
    })
  }
  OnChanges($event) {
    this.selectItemChange.emit(this.selectItem);
  }
}
