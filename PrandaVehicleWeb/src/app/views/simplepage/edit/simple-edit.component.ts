import { Component, EventEmitter, OnInit, Output, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Location } from '@angular/common';
// import { SimpleService } from '../../../services/simple.services';



@Component({
    selector: 'app-edit-simple',
    templateUrl: 'simple-edit.component.html'
})
export class SimpleEditComponent implements OnInit {
    mCriteria: any;
    dataSelect: any = null;
    constructor(
        private route: Router,
        private routeActive: ActivatedRoute,
        private toastr: ToastrService,
        private location: Location,
        // private simplepage: SimpleService
    ) {
        // this.simplepage.currentMessage.subscribe(message => this.dataSelect = message);
        if (this.dataSelect === null) {
            this.route.navigate(['/simple/management']);
        } else {
            this.mCriteria = this.dataSelect;

        }
    }
    ngOnInit() {

    }
    onBinding() {

    }

    onSubmit() {

    }
    onBack() {
        this.location.back();
    }
}
