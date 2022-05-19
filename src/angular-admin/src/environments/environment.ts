// This file can be replaced during build by using the `fileReplacements` array.
// `ng build ---prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

import { DelonMockModule } from '@delon/mock';
import { Environment } from 'src/Environment';

import * as MOCKDATA from '../../_mock';

const baseUrl = 'http://localhost:4200';
export const environment = {
  production: false,
  useHash: true,
  application: {
    baseUrl,
    name: '123',
    logoUrl: ''
  },
  oAuthConfig: {
    // oauth授权相关配置
    issuer: 'https://localhost:44369', // 授权服务器地址
    redirectUri: baseUrl, // 如果不准备使用oauth2授权，后面的配置可以不填
    clientId: 'Ehr_App', // 客户端Id
    responseType: 'code',
    scope: 'offline_access Ehr',
    requireHttps: true
  },
  apis: {
    //请求接口与生成动态请求需要
    default: {
      url: 'https://localhost:44369', //接口地址
      rootNamespace: 'Snow.Ehr' //根命名空间
    }
  },
  api: {
    baseUrl: './',
    refreshTokenEnabled: true,
    refreshTokenType: 'auth-refresh'
  }
  // modules: [DelonMockModule.forRoot({ data: MOCKDATA })]
} as Environment;

/*
 * In development mode, to ignore zone related error stack frames such as
 * `zone.run`, `zoneDelegate.invokeTask` for easier debugging, you can
 * import the following file, but please comment it out in production mode
 * because it will have performance impact when throw error
 */
// import 'zone.js/plugins/zone-error';  // Included with Angular CLI.
