import { Environment } from 'src/Environment';

const baseUrl = 'https://localhost:4200';
export const environment = {
  production: true,
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
} as Environment;
