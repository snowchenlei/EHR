import type { ExtensibleEntityDto, ExtensibleFullAuditedEntityDto } from '@abp/ng.core';

export interface IdentityRoleDto extends ExtensibleEntityDto<string> {
  name?: string;
  isDefault: boolean;
  isStatic: boolean;
  isPublic: boolean;
  concurrencyStamp?: string;
}

export interface IdentityUserDto extends ExtensibleFullAuditedEntityDto<string> {
  tenantId?: string;
  userName?: string;
  name?: string;
  surname?: string;
  email?: string;
  emailConfirmed: boolean;
  phoneNumber?: string;
  phoneNumberConfirmed: boolean;
  isActive: boolean;
  lockoutEnabled: boolean;
  lockoutEnd?: string;
  concurrencyStamp?: string;
}
