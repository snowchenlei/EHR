import { RestService } from '@abp/ng.core';
import type { ListResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { IdentityRoleDto } from '../../../volo/abp/identity/models';

@Injectable({
  providedIn: 'root',
})
export class RoleService {
  apiName = 'Default';

  create = (ouId: string, roleIds: string[]) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: `/api/organization-units/${ouId}/roles`,
      params: { roleIds },
    },
    { apiName: this.apiName });

  delete = (ouId: string, roleId: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/organization-units/${ouId}/roles/${roleId}`,
    },
    { apiName: this.apiName });

  getList = (ouId: string) =>
    this.restService.request<any, ListResultDto<IdentityRoleDto>>({
      method: 'GET',
      url: `/api/organization-units/${ouId}/roles`,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
