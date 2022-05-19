import { mapEnumToOptions } from '@abp/ng.core';

export enum PoliticalStatus {
  PublicPeople = 0,
  CPC = 1,
  LeagueMember = 2,
  Non = 3,
}

export const politicalStatusOptions = mapEnumToOptions(PoliticalStatus);
