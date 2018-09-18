import { Component, OnInit, Input, ViewChild, ViewContainerRef, ComponentFactoryResolver, Output, EventEmitter } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
// import { SimpleService } from '../../../services/simple.services';


@Component({
    selector: 'app-simple-search',
    templateUrl: 'simple-search.component.html'
})
export class SimpleSearchComponent implements OnInit {
    displayState: any = 0;
    mCriteria: any;
    loadSuccess: boolean = false;
    @Input() mResults: any;
    currentPage: number = 4;
    page: number;
    showBoundaryLinks = true;
    constructor(
        private route: Router,
        private routeActive: ActivatedRoute,
        // private simplepage: SimpleService

    ) {

    }
    ngOnInit() {

    }

    pageChanged(event: any): void {
        this.page = event.page;
    }

    onEdit(item) {
        // this.simplepage.changeMessage(item);
        this.route.navigate(['/simple/edit']);
    }
}
