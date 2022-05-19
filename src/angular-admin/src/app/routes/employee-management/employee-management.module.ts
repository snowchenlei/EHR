import { NgModule, Type } from '@angular/core';
import { SharedModule } from '@shared';

import { EmployeeManagementRoutingModule } from './employee-management-routing.module';
import { EmployeeManagementEmployeeEditComponent } from './employee/edit/edit.component';
import { EmployeeManagementEmployeeComponent } from './employee/employee.component';

const COMPONENTS: Array<Type<void>> = [EmployeeManagementEmployeeComponent, EmployeeManagementEmployeeEditComponent];

@NgModule({
  imports: [SharedModule, EmployeeManagementRoutingModule],
  declarations: COMPONENTS
})
export class EmployeeManagementModule {}
