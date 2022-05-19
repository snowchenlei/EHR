import { RestService } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { IActionResult } from '../microsoft/asp-net-core/mvc/models';

@Injectable({
  providedIn: 'root',
})
export class AppService {
  apiName = 'Default';

  getData = () =>
    this.restService.request<any, IActionResult>({
      method: 'GET',
      url: '/api/app/data',
    },
    { apiName: this.apiName });

  getSettings = () =>
    this.restService.request<any, IActionResult>({
      method: 'GET',
      url: '/api/app/setting',
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
