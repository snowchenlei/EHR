import { ConfigStateService, LocalizationService, PermissionService } from '@abp/ng.core';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { STChange, STColumn, STComponent, STData, STPage } from '@delon/abc/st';
import { SFSchema } from '@delon/form';
import { ModalHelper } from '@delon/theme';
import { InServiceStatus, EmployeeListDto, GetEmployeesInput } from '@proxy/employee-management/employees';
import { EmployeeService } from '@proxy/employees';
import { NzMessageService } from 'ng-zorro-antd/message';
import { tap } from 'rxjs/operators';

import { EmployeeManagementEmployeeEditComponent } from './edit/edit.component';

@Component({
  selector: 'app-employee-management-employee',
  templateUrl: './employee.component.html'
})
export class EmployeeManagementEmployeeComponent implements OnInit {
  employees: EmployeeListDto[];
  total: number;
  loading = false;
  params: GetEmployeesInput;
  page: STPage = {
    show: true,
    showSize: true,
    front: false,
    pageSizes: [10, 20, 30, 40, 50]
  };
  searchSchema: SFSchema = {
    properties: {
      // TODO:搜索参数
    }
  };
  @ViewChild('st', { static: false }) st: STComponent;
  columns: STColumn[] = [
    { title: this.localizationService.instant('Ehr::EmployeeNumber'), index: 'employeeNumber' },
    { title: this.localizationService.instant('Ehr::Name'), index: 'name' },
    { title: this.localizationService.instant('Ehr::Age'), index: 'age' },
    { title: this.localizationService.instant('Ehr::Gender'), index: 'gender' },
    { title: this.localizationService.instant('Ehr::PhoneNumber'), index: 'phoneNumber' },
    { title: this.localizationService.instant('Ehr::IdCardNumber'), index: 'idCardNumber' },
    { title: this.localizationService.instant('Ehr::Address'), index: 'address' },
    { title: this.localizationService.instant('Ehr::Birthday'), index: 'birthday' },
    { title: this.localizationService.instant('Ehr::JoinDate'), index: 'joinDate' },
    {
      title: this.localizationService.instant('Ehr::Actions'),
      buttons: [
        {
          icon: 'edit',
          tooltip: this.localizationService.instant('Ehr::Edit'),
          iif: () => {
            return this.permissionService.getGrantedPolicy('Ehr.Employee.Update');
          },
          click: (record: STData, modal?: any, instance?: STComponent) => {
            this.router.navigateByUrl(`employee-management/employee/${record['id']}`);
          }
        },
        {
          icon: 'delete',
          type: 'del',
          tooltip: this.localizationService.instant('Ehr::Delete'),
          pop: {
            title: this.localizationService.instant('Ehr::AreYouSure'),
            okType: 'danger',
            icon: 'star'
          },
          iif: () => {
            return this.permissionService.getGrantedPolicy('Ehr.Employee.Delete');
          },
          click: (record, _modal, component) => {
            this.employeeService.delete(record.id).subscribe(response => {
              // tslint:disable-next-line: no-non-null-assertion
              component!.removeRow(record);
            });
          }
        }
      ]
    }
  ];

  constructor(
    private router: Router,
    private localizationService: LocalizationService,
    private messageService: NzMessageService,
    private permissionService: PermissionService,
    private employeeService: EmployeeService
  ) {}

  ngOnInit() {
    this.params = this.resetParameters();
    this.getList();
  }
  getList() {
    this.loading = true;
    this.employeeService
      .getList(this.params)
      .pipe(tap(() => (this.loading = false)))
      .subscribe(response => ((this.employees = response.items), (this.total = response.totalCount)));
  }
  resetParameters(): GetEmployeesInput {
    return {
      skipCount: 0,
      maxResultCount: 10,
      sorting: 'Id Desc',
      inServiceStatus: InServiceStatus.In
    };
  }
  change(e: STChange) {
    if (e.type === 'pi' || e.type === 'ps') {
      this.params.skipCount = (e.pi - 1) * e.ps;
      this.params.maxResultCount = e.ps;
      this.getList();
    } else if (e.type === 'sort') {
      this.params.sorting = e.sort.column.index[0];
      this.getList();
    }
  }
  reset() {
    this.params = this.resetParameters();
    this.getList();
  }
  search(e) {
    this.getList();
  }
  add() {
    this.router.navigateByUrl(`/employee-management/employee/new`);
  }
}
