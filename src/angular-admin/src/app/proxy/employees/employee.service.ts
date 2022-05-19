import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { EmployeeCreateDto, EmployeeDetailDto, EmployeeListDto, EmployeeUpdateDto, GetEmployeeForEditorOutput, GetEmployeesInput } from '../employee-management/employees/models';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  apiName = 'Default';

  create = (input: EmployeeCreateDto) =>
    this.restService.request<any, EmployeeListDto>({
      method: 'POST',
      url: '/api/employee',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/employee/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, EmployeeDetailDto>({
      method: 'GET',
      url: `/api/employee/${id}`,
    },
    { apiName: this.apiName });

  getEditor = (id: string) =>
    this.restService.request<any, GetEmployeeForEditorOutput>({
      method: 'GET',
      url: `/api/employee/${id}/editor`,
    },
    { apiName: this.apiName });

  getList = (input: GetEmployeesInput) =>
    this.restService.request<any, PagedResultDto<EmployeeListDto>>({
      method: 'GET',
      url: '/api/employee',
      params: { name: input.name, inServiceStatus: input.inServiceStatus, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  update = (id: string, input: EmployeeUpdateDto) =>
    this.restService.request<any, EmployeeListDto>({
      method: 'PUT',
      url: `/api/employee/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
