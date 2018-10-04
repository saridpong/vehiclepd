import { Component, EventEmitter, OnInit, Output, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';

@Component({
    selector: 'app-labour-cost',
    templateUrl: 'labour-cost.component.html'
})
export class LabourCostComponent implements OnInit {

    @Input() labourcost: any;
    @Input() read: boolean;
    constructor(
        private route: Router,
        private routeActive: ActivatedRoute,
        private location: Location
    ) {
        if (this.labourcost === undefined || this.labourcost === null) {
            this.labourcost = {};
        }
    }
    ngOnInit() {

    }

    onSubmit() {

    }

    onCal() {
        if (this.labourcost.totalCost === undefined || this.labourcost.totalCost === null) {
            this.labourcost.totalCost = 0;
        }
        if (this.labourcost.feeCost === undefined || this.labourcost.feeCost === null) {
            this.labourcost.feeCost = 0;
        }
        if (this.labourcost.otherCost === undefined || this.labourcost.otherCost === null) {
            this.labourcost.otherCost = 0;
        }
        if (this.labourcost.fuelCost === undefined || this.labourcost.fuelCost === null) {
            this.labourcost.fuelCost = 0;
        }
        if (this.labourcost.labourCost === undefined || this.labourcost.labourCost === null) {
            this.labourcost.labourCost = 0;
        }
        if (this.labourcost.diffCost === undefined || this.labourcost.diffCost === null) {
            this.labourcost.diffCost = 0;
        }
        if (this.labourcost.estimateCost === undefined || this.labourcost.estimateCost === null) {
            this.labourcost.estimateCost = 0;
        }
        this.labourcost.totalCost = this.labourcost.feeCost + this.labourcost.otherCost + this.labourcost.fuelCost + this.labourcost.labourCost;
        this.labourcost.diffCost = this.labourcost.estimateCost - this.labourcost.totalCost;
    }

    onBack() {
        this.location.back();
    }
}
