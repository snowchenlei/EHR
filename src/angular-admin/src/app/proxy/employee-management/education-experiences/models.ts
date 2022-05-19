import type { Degree } from './degree.enum';
import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface EducationExperienceCreateDto extends EducationExperienceCreateOrUpdateDtoBase {
}

export interface EducationExperienceCreateOrUpdateDtoBase {
  schoolName?: string;
  specialty?: string;
  degree: Degree;
  startTime?: string;
  endTime?: string;
  employeeId?: string;
  description?: string;
}

export interface EducationExperienceDetailDto extends EntityDto<string> {
  schoolName?: string;
  specialty?: string;
  degree: Degree;
  startTime?: string;
  endTime?: string;
  creationTime?: string;
}

export interface EducationExperienceListDto extends EntityDto<string> {
  schoolName?: string;
  specialty?: string;
  degree?: string;
  startTime?: string;
  endTime?: string;
  creationTime?: string;
}

export interface EducationExperienceUpdateDto extends EducationExperienceCreateOrUpdateDtoBase {
}

export interface GetEducationExperienceForEditorOutput extends EntityDto<string> {
  schoolName?: string;
  specialty?: string;
  degree: Degree;
  startTime?: string;
  endTime?: string;
  employeeId?: string;
  description?: string;
}

export interface GetEducationExperiencesInput extends PagedAndSortedResultRequestDto {
}
