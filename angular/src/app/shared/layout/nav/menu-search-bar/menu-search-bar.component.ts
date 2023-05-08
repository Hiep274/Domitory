import { Component, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { AppNavigationService } from '../app-navigation.service';
import { Router } from '@angular/router';

@Component({
  selector: 'menu-search-bar',
  templateUrl: './menu-search-bar.component.html',
  styleUrls: ['./menu-search-bar.component.css']
})
export class MenuSearchBarComponent extends AppComponentBase {

  allMenuItems: any[];


  isMenuSearchActive = false;

  selected: '';

  constructor(
    injector: Injector,
    private _appNavigationService: AppNavigationService,
    private router: Router) {

    super(injector);
    this.initializeMenuSearch();
  }

  showMenuItem(menuItem): boolean {
    return this._appNavigationService.showMenuItem(menuItem);
  }

  private getAllMenuItems() {
    return this._appNavigationService.getAllMenuItems().filter(item => this.showMenuItem(item) && item.route).map(menuItem => {
      return {
        name: this.l(menuItem.name),
        route: menuItem.route
      };
    });
  }



  selectMenuItem(event) {
    if (event && event.value) {
      this.router.navigate([event.value]).then((navigated) => {
        this.selected = '';
      });
    }
  }

  private initializeMenuSearch() {
    this.isMenuSearchActive = false;
    let themeSettings = this.currentTheme.baseSettings;

    if (themeSettings && themeSettings.menu && themeSettings.menu.searchActive) {
      this.allMenuItems = this.getAllMenuItems();
      this.isMenuSearchActive = true;
    }
  }
}
