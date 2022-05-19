import { mapEnumToOptions } from '@abp/ng.core';

export enum BloodType {
  A = 0,
  B = 1,
  AB = 2,
  O = 3,
}

export const bloodTypeOptions = mapEnumToOptions(BloodType);
