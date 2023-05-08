import {
  Component, OnInit, AfterViewInit, Injector,
  QueryList, ViewChildren, OnDestroy
} from '@angular/core';
import { Router } from '@angular/router';
import { AppComponentBase } from '@shared/common/app-component-base';
import { LocalStorageService } from '@shared/utils/local-storage.service';
import { AppConsts } from '@shared/AppConsts';
import { AllowIn } from 'ng-keyboard-shortcuts';
import { EventBusService } from '@app/shared/services/event-bus.service';

@Component({
  selector: 'home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.less'],
})
export class HomeComponent extends AppComponentBase implements OnInit, AfterViewInit, OnDestroy {

  @ViewChildren('dynamic_tab') tabElements: QueryList<any>;
  openedTabsObj: Array<any> = []; // { name: string, code: string, active: bool, params: {} }
  currentTabCode: string;
  maxNumberOfTab: Number;
  shortcuts = [];

  constructor(
    injector: Injector,
    private eventBus: EventBusService,
    private _router: Router,
    private _localStorageService: LocalStorageService,
  ) {
    super(injector);
  }

  ngOnInit() {
    this.maxNumberOfTab = 10;
    //Number(abp.setting.get("Abp.Zero.HomePage.MaxNumberOfTab"));
    // Load from Local Storage (not need to login)
    this._localStorageService.getItem(AppConsts.STORAGE_KEYS.OPEN_TABS, (err, data) => {
      if (data) {
        if (data && data.length > 0) {
          this.openedTabsObj = data;
          const tabCode = (data[data.length - 1]).code;
          this.currentTabCode = tabCode;
          this._localStorageService.setItem(AppConsts.STORAGE_KEYS.CURRENT_TAB, tabCode);
          this.displayTab(tabCode);

        }
      }
    });

    this.eventBus.on('openComponent').subscribe(val => {
      let tabCode = val.functionCode;
      let tabName = val.tabHeader;
      let newTabObj = null;
      let oldTabObj = null;
      let params = val.params;

      // Can not open more than the maximum number of tabs
      newTabObj = { name: tabName, code: tabCode, params: params };
      oldTabObj = this.openedTabsObj.find(item => item.code === newTabObj.code);
      if (this.openedTabsObj.length === this.maxNumberOfTab) {
        if (!oldTabObj) {
          this.message.warn(this.l('OverMaximumNumberOfTab', this.maxNumberOfTab));
          return;
        }
      }

      this._localStorageService.setItem(AppConsts.STORAGE_KEYS.CURRENT_TAB, tabCode);
      this.currentTabCode = tabCode;

      if (!oldTabObj) {
        this.openedTabsObj.push(newTabObj);
        this._localStorageService.setItem(AppConsts.STORAGE_KEYS.OPEN_TABS, this.openedTabsObj);
      }

      this.displayTab(newTabObj.code);
    });

  }

  ngAfterViewInit(): void {
    // this.setKeyboardShortcuts(this.selectedTab);
    // this.changeDetectorRef.detectChanges();
  }

  ngOnDestroy(): void {
    this.eventBus.clearObservers();
  }

  displayTab(code: string, event?) {
    if (event && code === this.currentTabCode) return;
    // name param is used for tabs that can open multi instances
    this.setCurrentTab(code);
  }

  setCurrentTab(code: string) {
    this._localStorageService.setItem(AppConsts.STORAGE_KEYS.CURRENT_TAB, code);
    this.currentTabCode = code;

    if (code === '') {
      this._router.navigate(['/']);
    } else {
      // No re-assign new ref to data-bound this.openedTabsObj
      for (const objTab of this.openedTabsObj) {
        if (objTab.code === code) {
          if (!objTab.active) objTab.active = true;
        } else {
          if (objTab.active === true) objTab.active = false;
        }
      }

      this._localStorageService.setItem(AppConsts.STORAGE_KEYS.OPEN_TABS, this.openedTabsObj);

      this.runCustomFunction(code);
    }

    const component = this.tabElements["_results"].find(e => e.tabCode === this.currentTabCode)?.componentRef;
    this.setShortcuts(component);
  }

  // config phím tắt
  setShortcuts(component) {
    this.shortcuts = [
      {
        key: ["ctrl + s"],
        allowIn: [AllowIn.Textarea, AllowIn.Input, AllowIn.Select],
        command: e => {
          if (this.currentTabCode.startsWith('MASTER') && component?.instance.createOrEditModal) component?.instance.createOrEditModal.save();
        },
        preventDefault: true
      },

    ];
  }

  removeTabHandler(tab: any): void {
    this._localStorageService.getItem(AppConsts.STORAGE_KEYS.OPEN_TABS, (err, tabs) => {
      if (tabs && Array.isArray(tabs)) {
        const idx = this.openedTabsObj.findIndex(obj => obj.code === tab.code);
        this.openedTabsObj.splice(idx, 1);
        this._localStorageService.setItem(AppConsts.STORAGE_KEYS.OPEN_TABS, this.openedTabsObj);

        if (this.openedTabsObj.length == 0) this.displayTab('');
      }
    });
  }

  runCustomFunction(code) {
    setTimeout(() => {
      const component = this.tabElements.find((e) => e.tabCode === code);
      if (component) {
        component.runCustomFunction();
      }
    });
  }
}
