import { mapEnumToOptions } from '@abp/ng.core';

export enum InServiceStatus {
  In = 0,
  Out = 1,
}

export const inServiceStatusOptions = mapEnumToOptions(InServiceStatus);
