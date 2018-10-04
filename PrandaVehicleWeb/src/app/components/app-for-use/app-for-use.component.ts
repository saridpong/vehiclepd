import { ForUseService } from './../../services/foruse.services';
import { Component, Input, OnInit, NgModule, forwardRef, OnChanges, Output, EventEmitter } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';


@Component({
  selector: 'app-for-use',
  templateUrl: './app-for-use.component.html',
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => AppForUseComponent),
      multi: true
    }
  ]
})
export class AppForUseComponent implements OnInit {
  items: any;
  @Input() selectItem: any;
  @Input() read: boolean;
  @Output() selectItemChange = new EventEmitter();
  constructor(private foruse: ForUseService) {
    this.items = {
      forUses: []
    }
  }

  ngOnInit() {
    if (this.selectItem === null || this.selectItem === undefined) {
      this.selectItem = {};
    }
    const criteria = { status: 1 };
    this.foruse.find(criteria).subscribe(result => {
      this.items = result;
    })
  }
  OnChanges($event) {
    this.selectItemChange.emit(this.selectItem);
  }
}
