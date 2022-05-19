import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { GetSalaryForEditorOutput, GetSalarysInput, SalaryCreateDto, SalaryDetailDto, SalaryListDto, SalaryUpdateDto } from '../employee-management/salaries/models';

@Injectable({
  providedIn: 'root',
})
export class SalaryService {
  apiName = 'Default';

  create = (input: SalaryCreateDto) =>
    this.restService.request<any, SalaryListDto>({
      method: 'POST',
      url: '/api/app/salary',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, SalaryDetailDto>({
      method: 'GET',
      url: `/${id}`,
    },
    { apiName: this.apiName });

  getEditor = (id: string) =>
    this.restService.request<any, GetSalaryForEditorOutput>({
      method: 'GET',
      url: `/${id}/editor`,
    },
    { apiName: this.apiName });

  getList = (input: GetSalarysInput) =>
    this.restService.request<any, PagedResultDto<SalaryListDto>>({
      method: 'GET',
      url: '/api/app/salary',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  update = (id: string, input: SalaryUpdateDto) =>
    this.restService.request<any, SalaryListDto>({
      method: 'PUT',
      url: `/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
