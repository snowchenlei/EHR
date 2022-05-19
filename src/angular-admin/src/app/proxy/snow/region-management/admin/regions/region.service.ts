import type { RegionNodeDto } from './models';
import { RestService } from '@abp/ng.core';
import type { ListResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { RegionLevel } from '../../region-level.enum';

@Injectable({
  providedIn: 'root',
})
export class RegionService {
  apiName = 'RegionManagement';

  getChildren = (id: string, level: RegionLevel) =>
    this.restService.request<any, ListResultDto<RegionNodeDto>>({
      method: 'GET',
      url: `/api/regions/${id}/children/${level}`,
    },
    { apiName: this.apiName });

  getRoot = () =>
    this.restService.request<any, ListResultDto<RegionNodeDto>>({
      method: 'GET',
      url: '/api/regions/root',
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
