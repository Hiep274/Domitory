import { PermissionCheckerService } from 'abp-ng2-module';
import { Injector, ElementRef, Component, OnInit, ViewEncapsulation, Inject, Renderer2, AfterViewInit, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { AppMenu } from './app-menu';
import { AppNavigationService } from './app-navigation.service';
import { DOCUMENT } from '@angular/common';
import { NavigationEnd, Router } from '@angular/router';
import { filter } from 'rxjs/operators';
import { MenuOptions } from '@metronic/app/core/_base/layout/directives/menu.directive';
import { FormattedStringValueExtracter } from '@shared/helpers/FormattedStringValueExtracter';
import { EventBusService } from '@app/shared/services/event-bus.service';
import { AppMenuItem } from './app-menu-item';
import { TABS } from '@app/shared/constants/tab-keys';
import { TmssReportModalComponent } from '@app/shared/common/input-types/tmss-report-modal/tmss-report-modal.component';

@Component({
    templateUrl: './side-bar-menu.component.html',
    selector: 'side-bar-menu',
    encapsulation: ViewEncapsulation.None
})
export class SideBarMenuComponent extends AppComponentBase implements OnInit, AfterViewInit {
@ViewChild('promotionRotationHistory') promotionRotationHistory : TmssReportModalComponent;
    menu: AppMenu = null;

    isLoading: boolean = false;
    currentRouteUrl = '';
    insideTm: any;
    outsideTm: any;
    item;

    showFilterModalTabs: Array<any> = [];
    tabCodeAndModalIdDict: {};

    menuOptions: MenuOptions = {
        // vertical scroll
        scroll: null,

        // submenu setup
        submenu: {
            desktop: {
                default: 'dropdown',
                state: {
                    body: 'kt-aside--minimize',
                    mode: 'dropdown'
                }
            },
            tablet: 'accordion', // menu set to accordion in tablet mode
            mobile: 'accordion' // menu set to accordion in mobile mode
        },

        // accordion setup
        accordion: {
            expandAll: false // allow having multiple expanded accordions in the menu
        }
    };

    constructor(
        injector: Injector,
        private el: ElementRef,
        private router: Router,
        public permission: PermissionCheckerService,
        private _appNavigationService: AppNavigationService,
        @Inject(DOCUMENT) private document: Document,
        private render: Renderer2,
        private eventBus: EventBusService) {
        super(injector);
    }

    ngOnInit() {
        this.menu = this._appNavigationService.getMenu();

        this.currentRouteUrl = this.router.url.split(/[?#]/)[0];

        this.router.events
            .pipe(filter(event => event instanceof NavigationEnd))
            .subscribe(event => this.currentRouteUrl = this.router.url.split(/[?#]/)[0]);

        this.showFilterModalTabs = [
            // [TABS.XXX],
            // [TABS.YYY],
        ]

        this.tabCodeAndModalIdDict = {
            // [TABS.XXX]: 'sampleModalId',
            // [TABS.YYY]: 'sample2ModalId',
        }
    }

    ngAfterViewInit(): void {
        this.scrollToCurrentMenuElement();
    }

    showMenuItem(menuItem): boolean {
        return this._appNavigationService.showMenuItem(menuItem);
    }

    isMenuItemIsActive(item): boolean {
        if (item.items.length) {
            return this.isMenuRootItemIsActive(item);
        }

        if (!item.route) {
            return true;
        }

        let urlTree = this.router.parseUrl(this.currentRouteUrl.replace(/\/$/, ''));
        let urlString = '/' + urlTree.root.children.primary.segments.map(segment => segment.path).join('/');
        let exactMatch = urlString === item.route.replace(/\/$/, '');
        if (!exactMatch && item.routeTemplates) {
            for (let i = 0; i < item.routeTemplates.length; i++) {
                let result = new FormattedStringValueExtracter().Extract(urlString, item.routeTemplates[i]);
                if (result.IsMatch) {
                   return true;
                }
            }
        }
        return exactMatch;
    }

    isMenuRootItemIsActive(item): boolean {
        let result = false;

        for (const subItem of item.items) {
            result = this.isMenuItemIsActive(subItem);
            if (result) {
                return true;
            }
        }

        return false;
    }

    /**
	 * Use for fixed left aside menu, to show menu on mouseenter event.
	 * @param e Event
	 */
    mouseEnter(e: Event) {

        if (!this.currentTheme.baseSettings.menu.allowAsideMinimizing) {
            return;
        }

        // check if the left aside menu is fixed
        if (document.body.classList.contains('kt-aside--fixed')) {
            if (this.outsideTm) {
                clearTimeout(this.outsideTm);
                this.outsideTm = null;
            }

            this.insideTm = setTimeout(() => {
                // if the left aside menu is minimized
                if (document.body.classList.contains('kt-aside--minimize') && KTUtil.isInResponsiveRange('desktop')) {
                    // show the left aside menu
                    this.render.removeClass(document.body, 'kt-aside--minimize');
                    this.render.addClass(document.body, 'kt-aside--minimize-hover');
                }
            }, 50);
        }
    }

    /**
     * Use for fixed left aside menu, to show menu on mouseenter event.
     * @param e Event
     */
    mouseLeave(e: Event) {
        if (!this.currentTheme.baseSettings.menu.allowAsideMinimizing) {
            return;
        }

        if (document.body.classList.contains('kt-aside--fixed')) {
            if (this.insideTm) {
                clearTimeout(this.insideTm);
                this.insideTm = null;
            }

            this.outsideTm = setTimeout(() => {
                // if the left aside menu is expand
                if (document.body.classList.contains('kt-aside--minimize-hover') && KTUtil.isInResponsiveRange('desktop')) {
                    // hide back the left aside menu
                    this.render.removeClass(document.body, 'kt-aside--minimize-hover');
                    this.render.addClass(document.body, 'kt-aside--minimize');
                }
            }, 100);
        }
    }

    scrollToCurrentMenuElement(): void {
        const path = location.pathname;
        const menuItem = document.querySelector('a[href=\'' + path + '\']');
        if (menuItem) {
            menuItem.scrollIntoView({ block: 'center' });
        }
    }

    /**
     * Open the selected component. Display in placeholder of dynamic tab,
     * or open a dedicated tab, or open a specific tab.
     *
     * @param event
     * @param item
     */
    openComponent(event, item: AppMenuItem) {
        if (item.route.startsWith('SERVICE_REPORT') || item.route.startsWith('SALE_REPORT')) {
            this[item.name.charAt(0).toLowerCase() + item.name.slice(1)].show();
            return;
        }
        // const functionCode = (item.parameters && item.parameters.functionCode) || item.route; // origin
        const functionCode = item.route;
        if (!functionCode) { return; }

        // Only emit event for TABS
        if (Object.values(TABS).indexOf(functionCode) < 0) { return; }
        event.stopPropagation();
        // TODO: Review Code. Replace this.eventBus.
        // TODO:
        // - 1st Show Modal Filter Tabs
        // - 2nd Show a new browser tab
        // - 3rd emit event 'openComponent' to immediatly show tab
        this.eventBus.emit({
          type: 'openComponent',
          functionCode: functionCode,
          tabHeader: this.l(item.name)
      });
    }


}
