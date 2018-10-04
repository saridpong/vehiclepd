import { CarsService } from './../../services/cars.services';
import { Component, Input, OnInit, NgModule, forwardRef, OnChanges, Output, EventEmitter } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';


@Component({
  selector: 'app-vehicle',
  templateUrl: './app-vehicle.component.html'
})
export class AppVehicleComponent implements OnInit {
  items: any;
  @Input() selectItem: any;
  @Input() read: boolean = false;
  @Output() selectItemChange = new EventEmitter();
  constructor(private vehicle: CarsService) {
    this.items = {
      vehicles: []
    }
  }

  ngOnInit() {
    if (this.selectItem === null || this.selectItem === undefined) {
    }
    const criteria = { status: 1 };
    this.vehicle.find(criteria).subscribe(result => {
      this.items = result;
    })
  }
  OnChanges($event) {
    this.selectItemChange.emit(this.selectItem);
  }
}
