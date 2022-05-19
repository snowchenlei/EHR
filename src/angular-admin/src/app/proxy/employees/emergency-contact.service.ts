import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { EmergencyContactCreateDto, EmergencyContactDetailDto, EmergencyContactListDto, EmergencyContactUpdateDto, GetEmergencyContactForEditorOutput, GetEmergencyContactsInput } from '../employee-management/emergency-contacts/models';

@Injectable({
  providedIn: 'root',
})
export class EmergencyContactService {
  apiName = 'Default';

  create = (employeeId: string, input: EmergencyContactCreateDto) =>
    this.restService.request<any, EmergencyContactListDto>({
      method: 'POST',
      url: `/api/employee/${employeeId}/emergency-contact`,
      body: input,
    },
    { apiName: this.apiName });

  delete = (employeeId: string, emergencyContactId: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/employee/${employeeId}/emergency-contact/${emergencyContactId}`,
    },
    { apiName: this.apiName });

  get = (employeeId: string, emergencyContactId: string) =>
    this.restService.request<any, EmergencyContactDetailDto>({
      method: 'GET',
      url: `/api/employee/${employeeId}/emergency-contact/${emergencyContactId}`,
    },
    { apiName: this.apiName });

  getEditor = (employeeId: string, emergencyContactId: string) =>
    this.restService.request<any, GetEmergencyContactForEditorOutput>({
      method: 'GET',
      url: `/api/employee/${employeeId}/emergency-contact/${emergencyContactId}/editor`,
    },
    { apiName: this.apiName });

  getList = (employeeId: string, input: GetEmergencyContactsInput) =>
    this.restService.request<any, PagedResultDto<EmergencyContactListDto>>({
      method: 'GET',
      url: `/api/employee/${employeeId}/emergency-contact`,
      params: { employeeId: input.employeeId, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  update = (employeeId: string, emergencyContactId: string, input: EmergencyContactUpdateDto) =>
    this.restService.request<any, EmergencyContactListDto>({
      method: 'PUT',
      url: `/api/employee/${employeeId}/emergency-contact/${emergencyContactId}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
