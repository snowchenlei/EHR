import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface EmergencyContactCreateDto extends EmergencyContactCreateOrUpdateDtoBase {
}

export interface EmergencyContactCreateOrUpdateDtoBase {
  name?: string;
  phoneNumber?: string;
  relation?: string;
}

export interface EmergencyContactDetailDto extends EntityDto<number> {
  name?: string;
  phoneNumber?: string;
  relation?: string;
}

export interface EmergencyContactListDto extends EntityDto<string> {
  name?: string;
  phoneNumber?: string;
  relation?: string;
}

export interface EmergencyContactUpdateDto extends EmergencyContactCreateOrUpdateDtoBase {
}

export interface GetEmergencyContactForEditorOutput extends EmergencyContactCreateOrUpdateDtoBase {
}

export interface GetEmergencyContactsInput extends PagedAndSortedResultRequestDto {
  employeeId?: string;
}
