import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetSalaryForEditorOutput extends SalaryCreateOrUpdateDtoBase {
}

export interface GetSalarysInput extends PagedAndSortedResultRequestDto {
}

export interface SalaryCreateDto extends SalaryCreateOrUpdateDtoBase {
}

export interface SalaryCreateOrUpdateDtoBase {
  basicAmount: number;
}

export interface SalaryDetailDto extends EntityDto<string> {
  basicAmount: number;
}

export interface SalaryListDto extends EntityDto<string> {
  basicAmount: number;
}

export interface SalaryUpdateDto extends SalaryCreateOrUpdateDtoBase {
}
