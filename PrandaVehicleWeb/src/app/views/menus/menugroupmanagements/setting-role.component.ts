import { Component, OnInit, ViewChild, ComponentFactoryResolver, ViewContainerRef, Input, Output, EventEmitter } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { MenuService } from '../../../services/menu.services';
import { Role } from '../../../model/role';


@Component({
    templateUrl: 'setting-role.component.html'
})
export class SettingRoleComponent implements OnInit {
  @ViewChild('parent', { read: ViewContainerRef }) container: ViewContainerRef;
    _ref: any;
    @Input() _id: any;
    @Output() close: EventEmitter<any> = new EventEmitter();
    @Output() refresh: EventEmitter<any> = new EventEmitter();
    criteria = new Role(0, '',true);
    mMenus: any;
    mRole: any;
    dragOperation: boolean = false;
    displayState: any = 0;
    mManagementClass: any = 'col-md-12';
    groupID: any = 0;
    MenuItems: any;
    constructor(
        private route: Router, 
        private routeActive: ActivatedRoute, 
        private menu: MenuService,
        private _cfr: ComponentFactoryResolver,
        private toastr: ToastrService
    ) {

    }
    ngOnInit() {

    }
    onBinding() {
        this.menu.GetRoleDetail(this._id).subscribe(result => {
            this.mMenus = result;
        });
    }
    onClose() {
        this.close.emit();
    }
    onRefresh() {
        this.refresh.emit();
    }
    removeObject() {
        this._ref.destroy();
    }

    onSubmit() {
        this.mRole = {
            GroupID : this._id,
            MenuItems : this.mMenus
        };  
        this.menu.SettingRole(this.mRole).subscribe(result => {
            if (result.status === 1) {
                this.toastr.success('Update Success.', 'Setting Role')
                this.onClose();
                this.onRefresh();
            } else {
                this.toastr.error('Update Failed.', 'Setting Role')
            }
        });
    }

    onCloseMenu() {
        this.mManagementClass = 'col-md-12';
        this.container.clear();
    }

    onRefreshMenu() {
        this.menu.GetRoleDetail(this._id).subscribe(result => {
            this.mMenus = result;
        });
    }

    selectChange(item, subItem){
        if (subItem != null) var sub = subItem.checked;
        if (item.childs != null && item.childs.length > 0 && subItem == null) {
            for ( var i = 0; i < item.childs.length; i++) {
                var tmp = item.childs[i];
                tmp.checked = item.checked;
            }
        }
        if (subItem != null && sub) {
            item.checked = subItem.checked = sub;
        }
    }
}
