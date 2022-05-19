import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface ContractCreateDto extends ContractCreateOrUpdateDtoBase {
}

export interface ContractCreateOrUpdateDtoBase {
  name?: string;
  contractNumber?: string;
  startTime?: string;
  endTime?: string;
}

export interface ContractDetailDto extends EntityDto<string> {
  name?: string;
  contractNumber?: string;
  startTime?: string;
  endTime?: string;
}

export interface ContractListDto extends EntityDto<string> {
  name?: string;
  contractNumber?: string;
  startTime?: string;
  endTime?: string;
}

export interface ContractUpdateDto extends ContractCreateOrUpdateDtoBase {
}

export interface GetContractForEditorOutput extends ContractCreateOrUpdateDtoBase {
}

export interface GetContractsInput extends PagedAndSortedResultRequestDto {
}
