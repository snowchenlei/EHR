import { mapEnumToOptions } from '@abp/ng.core';

export enum RegionLevel {
  Country = 0,
  Province = 1,
  City = 2,
  District = 3,
  Street = 4,
  Village = 5,
}

export const regionLevelOptions = mapEnumToOptions(RegionLevel);
