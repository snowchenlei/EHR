import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { GetWorkExperienceForEditorOutput, GetWorkExperiencesInput, WorkExperienceCreateDto, WorkExperienceDetailDto, WorkExperienceListDto, WorkExperienceUpdateDto } from '../employee-management/work-experiences/models';

@Injectable({
  providedIn: 'root',
})
export class WorkExperienceService {
  apiName = 'Default';

  create = (employeeId: string, input: WorkExperienceCreateDto) =>
    this.restService.request<any, WorkExperienceListDto>({
      method: 'POST',
      url: `/api/employee/${employeeId}/work-experience`,
      body: input,
    },
    { apiName: this.apiName });

  delete = (employeeId: string, workExperienceId: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/employee/${employeeId}/work-experience/${workExperienceId}`,
    },
    { apiName: this.apiName });

  get = (employeeId: string, workExperienceId: string) =>
    this.restService.request<any, WorkExperienceDetailDto>({
      method: 'GET',
      url: `/api/employee/${employeeId}/work-experience/${workExperienceId}`,
    },
    { apiName: this.apiName });

  getEditor = (employeeId: string, workExperienceId: string) =>
    this.restService.request<any, GetWorkExperienceForEditorOutput>({
      method: 'GET',
      url: `/api/employee/${employeeId}/work-experience/${workExperienceId}/editor`,
    },
    { apiName: this.apiName });

  getList = (employeeId: string, input: GetWorkExperiencesInput) =>
    this.restService.request<any, PagedResultDto<WorkExperienceListDto>>({
      method: 'GET',
      url: `/api/employee/${employeeId}/work-experience`,
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  update = (employeeId: string, workExperienceId: string, input: WorkExperienceUpdateDto) =>
    this.restService.request<any, WorkExperienceListDto>({
      method: 'PUT',
      url: `/api/employee/${employeeId}/work-experience/${workExperienceId}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
