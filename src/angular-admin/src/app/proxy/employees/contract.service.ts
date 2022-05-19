import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { ContractCreateDto, ContractDetailDto, ContractListDto, ContractUpdateDto, GetContractForEditorOutput, GetContractsInput } from '../employee-management/contracts/models';

@Injectable({
  providedIn: 'root',
})
export class ContractService {
  apiName = 'Default';

  create = (employeeId: string, input: ContractCreateDto) =>
    this.restService.request<any, ContractListDto>({
      method: 'POST',
      url: `/api/employee/${employeeId}/contract`,
      body: input,
    },
    { apiName: this.apiName });

  delete = (employeeId: string, contractId: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/employee/${employeeId}/contract/${contractId}`,
    },
    { apiName: this.apiName });

  get = (employeeId: string, contractId: string) =>
    this.restService.request<any, ContractDetailDto>({
      method: 'GET',
      url: `/api/employee/${employeeId}/contract/${contractId}`,
    },
    { apiName: this.apiName });

  getEditor = (employeeId: string, contractId: string) =>
    this.restService.request<any, GetContractForEditorOutput>({
      method: 'GET',
      url: `/api/employee/${employeeId}/contract/${contractId}/editor`,
    },
    { apiName: this.apiName });

  getList = (employeeId: string, input: GetContractsInput) =>
    this.restService.request<any, PagedResultDto<ContractListDto>>({
      method: 'GET',
      url: `/api/employee/${employeeId}/contract`,
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  update = (employeeId: string, contractId: string, input: ContractUpdateDto) =>
    this.restService.request<any, ContractListDto>({
      method: 'PUT',
      url: `/api/employee/${employeeId}/contract/${contractId}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
