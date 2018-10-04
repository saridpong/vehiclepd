import { Component, EventEmitter, OnInit, Output, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';

@Component({
    selector: 'app-rating',
    templateUrl: 'rating.component.html'
})
export class RatingComponent implements OnInit {

    @Input() rating: any;
    @Input() read: boolean;
    constructor(
        private route: Router,
        private routeActive: ActivatedRoute,
        private location: Location
    ) {
        if (this.rating === undefined || this.rating === null) {
            this.rating = {};
        }
    }
    ngOnInit() {

    }

    onSubmit() {

    }

    onBack() {
        this.location.back();
    }
}


