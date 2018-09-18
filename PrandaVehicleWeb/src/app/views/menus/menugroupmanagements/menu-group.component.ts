import { Component, OnInit, ViewChild, ComponentFactoryResolver, ViewContainerRef } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { MenuService } from '../../../services/menu.services';
import { MenuNewGroupComponent } from './menu-group-new.component';
import { MenuEditGroupComponent } from './menu-group-edit.component';
import { SettingRoleComponent } from './setting-role.component';


@Component({
    templateUrl: 'menu-group.component.html'
})
export class MenuGroupComponent implements OnInit {
    @ViewChild('parent', { read: ViewContainerRef }) container: ViewContainerRef;
    mRoles: any;
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
        this.menu.GetRoles().subscribe(result => {
            this.mRoles = result;
        });
    }
    ngOnInit() {

    }
    onMouseOver(test: boolean) {
        this.dragOperation = test;
    }
    onNewRole() {
        this.displayState = 1;
        this.mManagementClass = 'col-md-6';
        this.container.clear();
        const comp = this._cfr.resolveComponentFactory(MenuNewGroupComponent);
        const expComponent = this.container.createComponent(comp, 0);
        expComponent.instance._ref = expComponent;
        expComponent.instance.close.subscribe(result => {
            this.onCloseMenu();
        });
        expComponent.instance.refresh.subscribe(result => {
            this.onRefreshMenu();
        });
    }

    onEditRole(id) {
        this.displayState = 1;
        this.mManagementClass = 'col-md-6';
        this.container.clear();
        const comp = this._cfr.resolveComponentFactory(MenuEditGroupComponent);
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
        this.menu.SortMenu(this.mRoles).subscribe(result => {
            if (result) {
                this.toastr.success('Sort Menu Success.', 'Menu Management')
            } else {
                this.toastr.error('Sort Menu Failed', 'Menu Management')
            }
        });
    }

    onRefreshMenu() {
        this.menu.GetRoles().subscribe(result => {
            this.mRoles = result;
        });
    }

    onSettingRole(id) {
        this.displayState = 1;
        this.mManagementClass = 'col-md-6';
        this.container.clear();
        const comp = this._cfr.resolveComponentFactory(SettingRoleComponent);
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
}
