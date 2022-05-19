import type { EntityDto } from '@abp/ng.core';

export interface RegionNodeDto extends EntityDto<string> {
  code?: string;
  name?: string;
  isLeaf: boolean;
  children: RegionNodeDto[];
}
