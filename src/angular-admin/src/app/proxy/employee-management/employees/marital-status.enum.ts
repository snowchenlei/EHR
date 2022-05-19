import { mapEnumToOptions } from '@abp/ng.core';

export enum MaritalStatus {
  Unmarried = 0,
  Married = 1,
  Divorced = 2,
  Widowed = 3,
}

export const maritalStatusOptions = mapEnumToOptions(MaritalStatus);
