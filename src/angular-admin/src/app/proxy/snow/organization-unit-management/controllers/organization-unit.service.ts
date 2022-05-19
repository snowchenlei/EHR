import { RestService } from '@abp/ng.core';
import type { ListResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { OrganizationUnitCreateDto, OrganizationUnitListDto, OrganizationUnitUpdateDto } from '../organization-units/models';

@Injectable({
  providedIn: 'root',
})
export class OrganizationUnitService {
  apiName = 'Default';

  create = (input: OrganizationUnitCreateDto) =>
    this.restService.request<any, OrganizationUnitListDto>({
      method: 'POST',
      url: '/api/organization-units',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/organization-units/${id}`,
    },
    { apiName: this.apiName });

  getChildrenByParentId = (parentId: string) =>
    this.restService.request<any, ListResultDto<OrganizationUnitListDto>>({
      method: 'GET',
      url: `/api/organization-units/${parentId}`,
    },
    { apiName: this.apiName });

  move = (id: string, parentId: string) =>
    this.restService.request<any, void>({
      method: 'PATCH',
      url: `/api/organization-units/${id}/to`,
      params: { parentId },
    },
    { apiName: this.apiName });

  update = (id: string, input: OrganizationUnitUpdateDto) =>
    this.restService.request<any, void>({
      method: 'PUT',
      url: `/api/organization-units/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
