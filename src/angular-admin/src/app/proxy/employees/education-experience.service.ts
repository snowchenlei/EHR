import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { EducationExperienceCreateDto, EducationExperienceDetailDto, EducationExperienceListDto, EducationExperienceUpdateDto, GetEducationExperienceForEditorOutput, GetEducationExperiencesInput } from '../employee-management/education-experiences/models';

@Injectable({
  providedIn: 'root',
})
export class EducationExperienceService {
  apiName = 'Default';

  create = (employeeId: string, input: EducationExperienceCreateDto) =>
    this.restService.request<any, EducationExperienceListDto>({
      method: 'POST',
      url: `/api/employee/${employeeId}/education-experience`,
      body: input,
    },
    { apiName: this.apiName });

  delete = (employeeId: string, workExperienceId: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/employee/${employeeId}/education-experience/${workExperienceId}`,
    },
    { apiName: this.apiName });

  get = (employeeId: string, workExperienceId: string) =>
    this.restService.request<any, EducationExperienceDetailDto>({
      method: 'GET',
      url: `/api/employee/${employeeId}/education-experience/${workExperienceId}`,
    },
    { apiName: this.apiName });

  getEditor = (employeeId: string, workExperienceId: string) =>
    this.restService.request<any, GetEducationExperienceForEditorOutput>({
      method: 'GET',
      url: `/api/employee/${employeeId}/education-experience/${workExperienceId}/editor`,
    },
    { apiName: this.apiName });

  getList = (employeeId: string, input: GetEducationExperiencesInput) =>
    this.restService.request<any, PagedResultDto<EducationExperienceListDto>>({
      method: 'GET',
      url: `/api/employee/${employeeId}/education-experience`,
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  update = (employeeId: string, workExperienceId: string, input: EducationExperienceUpdateDto) =>
    this.restService.request<any, EducationExperienceListDto>({
      method: 'PUT',
      url: `/api/employee/${employeeId}/education-experience/${workExperienceId}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
