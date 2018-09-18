
import { Component, OnInit, ViewChild, ViewContainerRef, ComponentFactoryResolver } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { SimpleSearchComponent } from './simple-search.component';


@Component({
    templateUrl: 'simple-criteria.component.html'
})
export class SimpleCriteriaComponent implements OnInit {
    @ViewChild('search') search: SimpleSearchComponent;
    mCriteria: any;
    mResponse: any;
    constructor(
        private route: Router,
        private routeActive: ActivatedRoute,
        private _cfr: ComponentFactoryResolver,
        private toastr: ToastrService
    ) {
        this.mCriteria = {
            simpleName: '',
            useFlag: -1
        }
    }
    ngOnInit() {

    }
    onSearch() {
        this.mResponse = [
            {
                simpleName: 'Menu',
                useFlag: true
            }, {
                simpleName: 'Setting',
                useFlag: true
            }, {
                simpleName: 'Employee',
                useFlag: true
            }
        ];
    }
    onNew() {
        this.route.navigate(['/simple/add']);
    }

}
