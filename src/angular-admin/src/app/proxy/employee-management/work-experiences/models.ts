import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetWorkExperienceForEditorOutput extends WorkExperienceCreateOrUpdateDtoBase {
}

export interface GetWorkExperiencesInput extends PagedAndSortedResultRequestDto {
}

export interface WorkExperienceCreateDto extends WorkExperienceCreateOrUpdateDtoBase {
}

export interface WorkExperienceCreateOrUpdateDtoBase {
  companyName?: string;
  post?: string;
  description?: string;
  startTime?: string;
  endTime?: string;
  creationTime?: string;
}

export interface WorkExperienceDetailDto extends EntityDto<string> {
  companyName?: string;
  post?: string;
  startTime?: string;
  endTime?: string;
  creationTime?: string;
}

export interface WorkExperienceListDto extends EntityDto<string> {
  companyName?: string;
  post?: string;
  startTime?: string;
  endTime?: string;
  creationTime?: string;
}

export interface WorkExperienceUpdateDto extends WorkExperienceCreateOrUpdateDtoBase {
}
