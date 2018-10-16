import { Component, Input, OnInit, NgModule, Output, EventEmitter, OnChanges } from '@angular/core';
import { SectionService } from '../../services/section.services';


@Component({
  selector: 'app-section',
  templateUrl: './app-section.component.html'
})
export class AppSectionComponent implements OnInit {

  items: any;
  @Input() selectItem: any = {};
  @Output() selectItemChange = new EventEmitter();
  constructor(private section: SectionService) {
    this.items = {
      section: []
    }
  }

  ngOnInit() {
    if (this.selectItem === null || this.selectItem === undefined) {
      this.selectItem = {};
    }
    const criteria = { status: 1 };
    this.section.find(criteria).subscribe(result => {
      this.items = result;
    })
  }
  OnChanges($event) {
    this.selectItemChange.emit(this.selectItem);
  }
}
