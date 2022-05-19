import { RestService } from '@abp/ng.core';
import type { ListResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { IdentityUserDto } from '../../../volo/abp/identity/models';

@Injectable({
  providedIn: 'root',
})
export class MemberService {
  apiName = 'Default';

  create = (ouId: string, userIds: string[]) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: `/api/organization-units/${ouId}/members`,
      params: { userIds },
    },
    { apiName: this.apiName });

  delete = (ouId: string, userId: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/organization-units/${ouId}/members/${userId}`,
    },
    { apiName: this.apiName });

  getList = (ouId: string) =>
    this.restService.request<any, ListResultDto<IdentityUserDto>>({
      method: 'GET',
      url: `/api/organization-units/${ouId}/members`,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
