export class AppConsts {

    static readonly tenancyNamePlaceHolderInUrl = '{TENANCY_NAME}';

    static remoteServiceBaseUrl: string;
    static remoteServiceBaseUrlFormat: string;
    static appBaseUrl: string;
    static appBaseHref: string; // returns angular's base-href parameter value if used during the publish
    static appBaseUrlFormat: string;
    static recaptchaSiteKey: string;
    static subscriptionExpireNootifyDayCount: number;

    static localeMappings: any = [];

    static readonly userManagement = {
        defaultAdminUserName: 'admin'
    };

    static readonly localization = {
        defaultLocalizationSourceName: 'tmss'
    };

    static readonly authorization = {
        encrptedAuthTokenName: 'enc_auth_token'
    };

    static readonly grid = {
        defaultPageSize: 10
    };

    static readonly MinimumUpgradePaymentAmount = 1;

    /// <summary>
    /// Gets current version of the application.
    /// It's also shown in the web page.
    /// </summary>
    static readonly WebAppGuiVersion = '8.6.0.0';
    static STORAGE_KEYS = {
        OPEN_TABS:            'OPEN_TABS', // Value [{ name: string, code: string, params: {}, active: boolean }, {}, {}...]
        CURRENT_TAB:          'CURRENT_TAB',
        CURRENT_MENU_GROUP:   'CURRENT_MENU_GROUP'
    }
}
