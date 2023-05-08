import { PermissionCheckerService } from 'abp-ng2-module';
import { AppMenuItem } from './app-menu-item';

export class AppMenu {
    name = '';
    displayName = '';
    items: AppMenuItem[];

    constructor(
        name: string,
         displayName: string,
         items: AppMenuItem[],
         private permissionCheckerService: PermissionCheckerService
         ) {
        this.displayName = displayName;
        this.items = items.filter(e => this.permissionCheckerService.isGranted(e.permissionName));
    }
}
