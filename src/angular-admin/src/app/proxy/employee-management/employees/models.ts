import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

import type { BloodType } from './blood-type.enum';
import type { Constellation } from './constellation.enum';
import type { Gender } from './gender.enum';
import type { InServiceStatus } from './in-service-status.enum';
import type { MaritalStatus } from './marital-status.enum';
import type { PoliticalStatus } from './political-status.enum';
import type { Zodiac } from './zodiac.enum';

export interface EmployeeCreateDto extends EmployeeCreateOrUpdateDtoBase {
  idCardNumber?: string;
}

export interface EmployeeCreateOrUpdateDtoBase {
  name?: string;
  gender: Gender;
  phoneNumber?: string;
  address?: string;
  birthday?: string;
  bankCardNumber?: string;
  bankOfDeposit?: string;
  maritalStatus: MaritalStatus;
  politicalStatus: PoliticalStatus;
  isGregorianCalendar: boolean;
  zodiac: Zodiac;
  constellation: Constellation;
  bloodType: BloodType;
  coverImageMediaId?: string;
  provinceId: number;
  cityId: number;
  areaId: number;
}

export interface EmployeeDetailDto extends EntityDto<string> {
  employeeNumber?: string;
  name?: string;
  age: number;
  gender: Gender;
  phoneNumber?: string;
  idCardNumber?: string;
  address?: string;
  birthDay?: string;
  joinDate?: string;
  confirmationDate?: string;
}

export interface EmployeeListDto extends EntityDto<string> {
  employeeNumber?: string;
  name?: string;
  age: number;
  gender?: string;
  phoneNumber?: string;
  idCardNumber?: string;
  address?: string;
  birthDay?: string;
  joinDate?: string;
}

export interface EmployeeUpdateDto extends EmployeeCreateOrUpdateDtoBase {}

export interface GetEmployeeForEditorOutput extends EntityDto<string> {
  name?: string;
  gender: Gender;
  phoneNumber?: string;
  idCardNumber?: string;
  bankCardNumber?: string;
  bankOfDeposit?: string;
  maritalStatus: MaritalStatus;
  politicalStatus: PoliticalStatus;
  address?: string;
  violationOfLawOrDiscipline?: string;
  majorMedicalHistory?: string;
  birthday?: string;
  isGregorianCalendar: boolean;
  zodiac: Zodiac;
  constellation: Constellation;
  bloodType: BloodType;
  coverImageMediaId?: string;
  idCardPhotoPositive?: string;
  idCardPhotoBack?: string;
  provinceId: string;
  cityId: string;
  districtId: string;
  streetId: string;
}

export interface GetEmployeesInput extends PagedAndSortedResultRequestDto {
  name?: string;
  inServiceStatus: InServiceStatus;
}
