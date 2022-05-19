import { mapEnumToOptions } from '@abp/ng.core';

export enum Gender {
  UnKnown = 0,
  Man = 1,
  Woman = 2,
}

export const genderOptions = mapEnumToOptions(Gender);
