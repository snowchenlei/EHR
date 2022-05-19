import { mapEnumToOptions } from '@abp/ng.core';

export enum Constellation {
  Capricorn = 0,
  Aquarius = 1,
  Pisces = 2,
  Aries = 3,
  Taurus = 4,
  Gemini = 5,
  Cancer = 6,
  Leo = 7,
  Virgo = 8,
  Libra = 9,
  Scorpio = 10,
  Sagittarius = 11,
}

export const constellationOptions = mapEnumToOptions(Constellation);
