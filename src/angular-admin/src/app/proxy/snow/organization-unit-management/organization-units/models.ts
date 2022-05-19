import type { EntityDto } from '@abp/ng.core';

export interface OrganizationUnitCreateDto extends OrganizationUnitCreateOrUpdateDto {
}

export interface OrganizationUnitCreateOrUpdateDto {
  parentId?: string;
  displayName?: string;
}

export interface OrganizationUnitListDto extends EntityDto<string> {
  code?: string;
  displayName?: string;
  isParent: boolean;
}

export interface OrganizationUnitUpdateDto extends OrganizationUnitCreateOrUpdateDto {
}
