import { Globals } from '../../globals/globals';
import { Component, ElementRef, Input, OnInit, Renderer2 } from '@angular/core';

// Import navigation elements
import { requesterMenu, adminMenu, securityMenu } from '../../_nav';

@Component({
  selector: 'app-sidebar-nav',
  template: `
    <nav class="sidebar-nav">
      <ul class="nav">
        <ng-template ngFor let-navitem [ngForOf]="navigation">
          <li *ngIf="isDivider(navitem)" class="nav-divider"></li>
          <ng-template [ngIf]="isTitle(navitem)">
            <app-sidebar-nav-title [title]='navitem'></app-sidebar-nav-title>
          </ng-template>
          <ng-template [ngIf]="!isDivider(navitem)&&!isTitle(navitem)">
            <app-sidebar-nav-item [item]='navitem'></app-sidebar-nav-item>
          </ng-template>
        </ng-template>
      </ul>
    </nav>`
})
export class AppSidebarNavComponent implements OnInit {
  public navigation;

  public isDivider(item) {
    return item.divider ? true : false;
  }

  public isTitle(item) {
    return item.title ? true : false;
  }

  constructor(private global: Globals) {
    // this.navigation = this.global.getCookie('sidebar').menus;
    /*
    this.navigation = [
      { menuID: 1, menuIcon: 'icon-menu', menuSystemName: 'Menu', menuSystemUrl: '', useFlag: true, childs: [] },
      { menuID: 2, menuIcon: '', menuSystemName: 'บันทึกใบขอใช้รถยนต์', menuSystemUrl: '/request/addrequest', useFlag: true, childs: [] },
      { menuID: 6, menuIcon: '', menuSystemName: 'ประวัติใบขอใช้รถยนต์', menuSystemUrl: '/request/searchrequest', useFlag: true, childs: [] },

      { menuID: 1, menuIcon: 'icon-menu', menuSystemName: 'Menu', menuSystemUrl: '', useFlag: true, childs: [] },
      { menuID: 4, menuIcon: '', menuSystemName: 'อนุมัติใบขอใช้บริการรถยนต์', menuSystemUrl: '/request/searchapprove', useFlag: true, childs: [] },
      { menuID: 3, menuIcon: '', menuSystemName: 'บันทึกใบมอบหมายงาน', menuSystemUrl: '/assign/add', useFlag: true, childs: [] },
      { menuID: 7, menuIcon: '', menuSystemName: 'ประวัติใบมอบหมายงาน', menuSystemUrl: '/assign/view', useFlag: true, childs: [] },
      { menuID: 4, menuIcon: '', menuSystemName: 'ให้คะแนนใบขอใช้บริการรถยนต์', menuSystemUrl: '/request/rate', useFlag: true, childs: [] },
      { menuID: 5, menuIcon: '', menuSystemName: 'บันทึกค่าแรงใบขอใช้บริการรถยนต์', menuSystemUrl: '/request/pay', useFlag: true, childs: [] },
      { menuID: 6, menuIcon: '', menuSystemName: 'อนุมัติรถยนต์ออกปฏิบัติงาน', menuSystemUrl: '/used/searchused', useFlag: true, childs: [] },

      { menuID: 1, menuIcon: 'icon-menu', menuSystemName: 'Menu', menuSystemUrl: '', useFlag: true, childs: [] },
      { menuID: 2, menuIcon: '', menuSystemName: 'บันทึกข้อมูลรถยนต์', menuSystemUrl: '/cars/newcars', useFlag: true, childs: [] },
      { menuID: 3, menuIcon: '', menuSystemName: 'ข้อมูลรายการรถยนต์', menuSystemUrl: '/cars/searchcars', useFlag: true, childs: [] },
      { menuID: 4, menuIcon: '', menuSystemName: 'บันทึกรายการซ่อมบำรุง', menuSystemUrl: '/cars/newmaintenance', useFlag: true, childs: [] },
      { menuID: 5, menuIcon: '', menuSystemName: 'ข้อมูลรายการต่อภาษี-ทะเบียน-พรบ', menuSystemUrl: '/cars/searchdocumentcars', useFlag: true, childs: [] },
      { menuID: 6, menuIcon: '', menuSystemName: 'ประวัติรายการซ่อมบำรุง', menuSystemUrl: '/cars/searchmaintenance', useFlag: true, childs: [] }
    ]
    */
  }
  ngOnInit() {
    const role = window.localStorage.getItem('role');
    if (role === 'REQUEST') {
      this.navigation = requesterMenu;
    } else if (role === 'ADMIN') {
      this.navigation = adminMenu;
    } else if (role === 'SECURITY') {
      this.navigation = securityMenu;
    }
    // this.navigation = this.global.getCookie('sidebar').menus;
  }
}

import { Router } from '@angular/router';

@Component({
  selector: 'app-sidebar-nav-item',
  template: `
    <li *ngIf="!isDropdown(); else dropdown" [ngClass]="hasClass() ? 'nav-item ' + item.class : 'nav-item'">
      <app-sidebar-nav-link [link]='item'></app-sidebar-nav-link>
    </li>
    <ng-template #dropdown>
      <li [ngClass]="hasClass() ? 'nav-item nav-dropdown ' + item.class : 'nav-item nav-dropdown'"
          [class.open]="isActive()"
          routerLinkActive="open"
          appNavDropdown>
        <app-sidebar-nav-dropdown [link]='item'></app-sidebar-nav-dropdown>
      </li>
    </ng-template>
    `
})
export class AppSidebarNavItemComponent {
  @Input()
  item: any;

  public hasClass() {
    return this.item.class ? true : false;
  }

  public isDropdown() {
    return this.item.childs !== null && this.item.childs.length > 0
      ? true
      : false;
  }

  public thisUrl() {
    return this.item.menuSystemUrl;
  }

  public isActive() {
    return this.router.isActive(this.thisUrl(), false);
  }

  constructor(private router: Router) {}
}

@Component({
  selector: 'app-sidebar-nav-link',
  template: `
    <a *ngIf="!isExternalLink(); else external"
      [ngClass]="hasVariant() ? 'nav-link nav-link-' + link.variant : 'nav-link'"
      routerLinkActive="active"
      [routerLink]="[link.menuSystemUrl]">
      <i *ngIf="isIcon()" class="{{ link.menuIcon }}"></i>
      {{ link.menuSystemName }}
      <span *ngIf="isBadge()" [ngClass]="'badge badge-' + link.badge.variant">{{ link.badge.text }}</span>
    </a>
    <ng-template #external>
      <a [ngClass]="hasVariant() ? 'nav-link nav-link-' + link.variant : 'nav-link'" href="{{link.menuSystemUrl}}">
        <i *ngIf="isIcon()" class="{{ link.menuIcon }}"></i>
        {{ link.menuSystemName }}
        <span *ngIf="isBadge()" [ngClass]="'badge badge-' + link.badge.variant">{{ link.badge.text }}</span>
      </a>
    </ng-template>
  `
})
export class AppSidebarNavLinkComponent {
  @Input()
  link: any;

  public hasVariant() {
    return this.link.variant ? true : false;
  }

  public isBadge() {
    return this.link.badge ? true : false;
  }

  public isExternalLink() {
    return this.link.menuSystemUrl.substring(0, 4) === 'http' ? true : false;
  }

  public isIcon() {
    return this.link.menuIcon ? true : false;
  }

  constructor() {}
}

@Component({
  selector: 'app-sidebar-nav-dropdown',
  template: `
    <a class="nav-link nav-dropdown-toggle mouseOver" appNavDropdownToggle>
      <i *ngIf="isIcon()" class="{{ link.menuIcon }}"></i>
      {{ link.menuSystemName }}
      <span *ngIf="isBadge()" [ngClass]="'badge badge-' + link.badge.variant">{{ link.badge.text }}</span>
    </a>
    <ul class="nav-dropdown-items">
      <ng-template ngFor let-child [ngForOf]="link.childs">
        <app-sidebar-nav-item [item]='child'></app-sidebar-nav-item>
      </ng-template>
    </ul>
  `
})
export class AppSidebarNavDropdownComponent {
  @Input()
  link: any;

  public isBadge() {
    return this.link.badge ? true : false;
  }

  public isIcon() {
    return this.link.menuIcon ? true : false;
  }

  constructor() {}
}

@Component({
  selector: 'app-sidebar-nav-title',
  template: ''
})
export class AppSidebarNavTitleComponent implements OnInit {
  @Input()
  title: any;

  constructor(private el: ElementRef, private renderer: Renderer2) {}

  ngOnInit() {
    const nativeElement: HTMLElement = this.el.nativeElement;
    const li = this.renderer.createElement('li');
    const name = this.renderer.createText(this.title.name);

    this.renderer.addClass(li, 'nav-title');

    if (this.title.class) {
      const classes = this.title.class;
      this.renderer.addClass(li, classes);
    }

    if (this.title.wrapper) {
      const wrapper = this.renderer.createElement(this.title.wrapper.element);

      this.renderer.appendChild(wrapper, name);
      this.renderer.appendChild(li, wrapper);
    } else {
      this.renderer.appendChild(li, name);
    }
    this.renderer.appendChild(nativeElement, li);
  }
}

export const APP_SIDEBAR_NAV = [
  AppSidebarNavComponent,
  AppSidebarNavDropdownComponent,
  AppSidebarNavItemComponent,
  AppSidebarNavLinkComponent,
  AppSidebarNavTitleComponent
];
