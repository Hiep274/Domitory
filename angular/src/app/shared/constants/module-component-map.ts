import { TABS } from '../constants/tab-keys';

export const MODULE_PATHS = {
    // TODO: Review Code. Duplicated declaration.
    APP_ADMIN_ADMIN_MODULE: 'app/admin/admin.module',
};

export const MODULE_COMPONENT_MAP = {
    [MODULE_PATHS.APP_ADMIN_ADMIN_MODULE]: [
        TABS.ADMIN_ORGANIZATION_UNITS,
        TABS.ADMIN_USERS,
        TABS.ADMIN_ROLES,
    ],
};
