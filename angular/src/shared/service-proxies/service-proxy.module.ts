import { AbpHttpInterceptor, RefreshTokenService, AbpHttpConfigurationService } from 'abp-ng2-module';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import * as ApiServiceProxies from './service-proxies';
import { ZeroRefreshTokenService } from '@account/auth/zero-refresh-token.service';
import { ZeroTemplateHttpConfigurationService } from './zero-template-http-configuration.service';

@NgModule({
    providers: [
        ApiServiceProxies.SessionServiceProxy,
        ApiServiceProxies.UserServiceProxy,
        ApiServiceProxies.WebLogServiceProxy,
        ApiServiceProxies.TokenAuthServiceProxy,
        ApiServiceProxies.StudentServiceProxy,
        ApiServiceProxies.BuildingRoomServiceProxy,
        ApiServiceProxies.InvoiceServiceProxy,
        ApiServiceProxies.InBillServiceProxy,
        ApiServiceProxies.OutBillServiceProxy,
        ApiServiceProxies.ContractServiceProxy,

        { provide: RefreshTokenService, useClass: ZeroRefreshTokenService },
        { provide: AbpHttpConfigurationService, useClass: ZeroTemplateHttpConfigurationService },
        { provide: HTTP_INTERCEPTORS, useClass: AbpHttpInterceptor, multi: true }
    ]
})
export class ServiceProxyModule {
}
