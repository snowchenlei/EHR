import { mapEnumToOptions } from '@abp/ng.core';

export enum Zodiac {
  Mouse = 0,
  Cattle = 1,
  Tiger = 2,
  Rabbit = 3,
  Dragon = 4,
  Snake = 5,
  Horse = 6,
  Sheep = 7,
  Monkey = 8,
  Chicken = 9,
  Dog = 10,
  Pig = 11,
}

export const zodiacOptions = mapEnumToOptions(Zodiac);
