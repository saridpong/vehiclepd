import { MenuEditComponent } from './managements/menu-edit.component';
import { MenuService } from '../../services/menu.services';
import { CoursesService } from '../../services/courses.services';
import { Component, OnInit, ViewChild, ComponentFactoryResolver, ViewContainerRef } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { MenuNewComponent } from './managements/menu-new.component';
import { ToastrService } from 'ngx-toastr';


@Component({
    templateUrl: 'menu-management.component.html'
})
export class MenuManagementComponent implements OnInit {
    @ViewChild('parent', { read: ViewContainerRef }) container: ViewContainerRef;
    mMenus: any;
    dragOperation: boolean = false;
    displayState: any = 0;
    mManagementClass: any = 'col-md-12';
    constructor(
        private route: Router,
        private routeActive: ActivatedRoute,
        private menu: MenuService,
        private _cfr: ComponentFactoryResolver,
        private toastr: ToastrService
    ) {
        this.menu.GetAllMenu().subscribe(result => {
            this.mMenus = result;
        });
    }
    ngOnInit() {

    }
    onMouseOver(test: boolean) {
        this.dragOperation = test;
    }
    onNewMenu() {
        this.displayState = 1;
        this.mManagementClass = 'col-md-6';
        this.container.clear();
        const comp = this._cfr.resolveComponentFactory(MenuNewComponent);
        const expComponent = this.container.createComponent(comp, 0);
        expComponent.instance._ref = expComponent;
        expComponent.instance.close.subscribe(result => {
            this.onCloseMenu();
        });
        expComponent.instance.refresh.subscribe(result => {
            this.onRefreshMenu();
        });
    }
    onEditMenu(id) {
        this.displayState = 1;
        this.mManagementClass = 'col-md-6';
        this.container.clear();
        const comp = this._cfr.resolveComponentFactory(MenuEditComponent);
        const expComponent = this.container.createComponent(comp, 0);
        expComponent.instance._ref = expComponent;
        expComponent.instance._id = id;
        expComponent.instance.onBinding();
        expComponent.instance.close.subscribe(result => {
            this.onCloseMenu();
        });
        expComponent.instance.refresh.subscribe(result => {
            this.onRefreshMenu();
        });
    }
    onCloseMenu() {
        this.mManagementClass = 'col-md-12';
        this.container.clear();
    }
    onSort() {
        this.menu.SortMenu(this.mMenus).subscribe(result => {
            if (result) {
                this.toastr.success('Sort Menu Success.', 'Menu Management')
            } else {
                this.toastr.error('Sort Menu Failed', 'Menu Management')
            }
        });
    }
    onRefreshMenu() {
        this.menu.GetAllMenu().subscribe(result => {
            this.mMenus = result;
        });
    }
}
