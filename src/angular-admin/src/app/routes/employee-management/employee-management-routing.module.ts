import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { EmployeeManagementEmployeeEditComponent } from './employee/edit/edit.component';
import { EmployeeManagementEmployeeComponent } from './employee/employee.component';

const routes: Routes = [
  { path: 'employee', component: EmployeeManagementEmployeeComponent },
  { path: 'employee/new', component: EmployeeManagementEmployeeEditComponent },
  { path: 'employee/:id', component: EmployeeManagementEmployeeEditComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EmployeeManagementRoutingModule {}
