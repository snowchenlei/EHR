import { mapEnumToOptions } from '@abp/ng.core';

export enum Degree {
  Doctorate = 0,
  MBA = 1,
  Master = 2,
  Undergraduate = 3,
  JuniorCollegeStudent = 4,
  TechnicalSecondarySchool = 5,
  HigherSchoolEducation = 6,
  JuniorHighSchoolEducation = 7,
  PrimarySchoolEducation = 8,
}

export const degreeOptions = mapEnumToOptions(Degree);
