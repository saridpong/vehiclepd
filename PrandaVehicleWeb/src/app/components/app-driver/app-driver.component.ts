import { DriverService } from './../../services/driver.services';
import { ForUseService } from './../../services/foruse.services';
import { Component, Input, OnInit, NgModule, forwardRef, OnChanges, Output, EventEmitter } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';


@Component({
  selector: 'app-driver',
  templateUrl: './app-driver.component.html'
})
export class AppDriverComponent implements OnInit {
  items: any;
  @Input() selectItem: any;
  @Input() read: boolean = false;
  @Output() selectItemChange = new EventEmitter();
  constructor(private driver: DriverService) {
    this.items = {
      drivers: []
    }
  }

  ngOnInit() {
    if (this.selectItem === null || this.selectItem === undefined) {
    }
    const criteria = { status: 1 };
    this.driver.find(criteria).subscribe(result => {
      this.items = result;
    })
  }
  OnChanges($event) {
    this.selectItemChange.emit(this.selectItem);
  }
}
