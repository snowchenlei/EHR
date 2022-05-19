import { LocalizationService } from '@abp/ng.core';
import { Location } from '@angular/common';
import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { dateTimePickerUtil, toDate } from '@delon/util';
import { environment } from '@env/environment';
import { EnumService } from '@proxy/controllers';
import {
  BloodType,
  Constellation,
  Gender,
  MaritalStatus,
  PoliticalStatus,
  Zodiac,
  GetEmployeeForEditorOutput
} from '@proxy/employee-management/employees';
import { EmployeeService } from '@proxy/employees';
import { RegionLevel } from '@proxy/snow/region-management';
import { RegionService } from '@proxy/snow/region-management/admin/regions';
import { NzCascaderOption } from 'ng-zorro-antd/cascader';
import { NzMessageService } from 'ng-zorro-antd/message';
import { NzUploadFile } from 'ng-zorro-antd/upload';
import { forkJoin, lastValueFrom, Observable, Observer } from 'rxjs';
import { finalize, map, tap } from 'rxjs/operators';

@Component({
  selector: 'app-employee-management-employee-edit',
  templateUrl: './edit.component.html'
})
export class EmployeeManagementEmployeeEditComponent implements OnInit {
  employeeId: string;
  employee: GetEmployeeForEditorOutput;

  loading = false;
  isConfirmLoading = false;

  form: FormGroup = null;
  coverImage: string;
  regions: NzCascaderOption[] | null = null;
  bloodType: Array<{ value: number; label: string }> = [];
  constellation: Array<{ value: number; label: string }> = [];
  gender: Array<{ value: number; label: string }> = [];
  maritalStatus: Array<{ value: number; label: string }> = [];
  politicalStatus: Array<{ value: number; label: string }> = [];
  zodiac: Array<{ value: number; label: string }> = [];
  uploadLoading = false;
  uploadParameters: any = {};
  logoSetting: any = {
    action: environment.api.baseUrl,
    limit: 1,
    fileSize: 2 * 1024 * 1024,
    showUploadList: false,
    uploadParameters: this.uploadParameters,
    accept: ['image/png', 'image/jpg', 'image/jpeg', 'image/gif', 'image/bmp'],
    fileType: 'image/png,image/jpg,image/jpeg,image/gif,image/bmp',
    listType: 'picture-card'
  };
  constructor(
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private location: Location,
    private messageService: NzMessageService,
    private localizationService: LocalizationService,
    private employeeService: EmployeeService,
    private regionService: RegionService,
    private enumService: EnumService
  ) {}

  ngOnInit(): void {
    this.employeeId = this.route.snapshot.paramMap.get('id');
    this.loading = true;
    if (this.employeeId) {
      this.employeeService
        .getEditor(this.employeeId)
        .pipe(
          tap(response => {
            this.employee = response;
            this.buildForm();
            this.loading = false;
          })
        )
        .subscribe();
    } else {
      this.employee = {} as GetEmployeeForEditorOutput;
      this.buildForm();
      this.loading = false;
    }
  }

  buildForm() {
    var bloodTypeService = this.enumService.getBloodType();
    var constellationService = this.enumService.getConstellation();
    var genderService = this.enumService.getGender();
    var maritalStatusService = this.enumService.getMaritalStatus();
    var politicalStatusService = this.enumService.getPoliticalStatus();
    var zodiacService = this.enumService.getZodiac();
    var regionService = this.regionService.getRoot();
    forkJoin([
      regionService,
      bloodTypeService,
      constellationService,
      genderService,
      maritalStatusService,
      politicalStatusService,
      zodiacService
    ])
      .pipe(
        tap(results => {
          this.regions = results[0].items.map(item => {
            return { value: item.id, label: item.name, isLeaf: item.isLeaf };
          });
          Object.keys(results[1]).map(key => {
            this.bloodType.push({ label: results[1][key], value: +key });
          });
          Object.keys(results[2]).map(key => {
            this.constellation.push({ label: results[2][key], value: +key });
          });
          Object.keys(results[3]).map(key => {
            this.gender.push({ label: results[3][key], value: +key });
          });
          Object.keys(results[4]).map(key => {
            this.maritalStatus.push({ label: results[4][key], value: +key });
          });
          Object.keys(results[5]).map(key => {
            this.politicalStatus.push({ label: results[5][key], value: +key });
          });
          Object.keys(results[6]).map(key => {
            this.zodiac.push({ label: results[6][key], value: +key });
          });

          this.form = this.fb.group({
            name: [this.employee.name || '', [Validators.required]],
            phoneNumber: [this.employee.phoneNumber || '', [Validators.required]],
            idCardNumber: [this.employee.idCardNumber || '', [Validators.required]],
            birthday: [this.employee.birthday || '', [Validators.required]],
            isGregorianCalendar: [this.employee.isGregorianCalendar || true],
            gender: [this.employee.gender || this.gender[0].value],
            zodiac: [this.employee.zodiac || this.zodiac[0].value],
            constellation: [this.employee.constellation || this.constellation[0].value],
            bloodType: [this.employee.bloodType || this.bloodType[0].value],
            maritalStatus: [this.employee.maritalStatus || this.maritalStatus[0].value],
            politicalStatus: [this.employee.politicalStatus || this.politicalStatus[0].value],
            provinceId: [this.employee.provinceId || ''],
            cityId: [this.employee.cityId || ''],
            districtId: [this.employee.districtId || ''],
            streetId: [this.employee.streetId || ''],
            regionIds: [[this.employee.provinceId, this.employee.cityId, this.employee.districtId, this.employee.streetId] || []],
            address: [this.employee.address || ''],
            violationOfLawOrDiscipline: [this.employee.violationOfLawOrDiscipline || ''],
            majorMedicalHistory: [this.employee.majorMedicalHistory || ''],
            coverImageMediaId: [this.employee.coverImageMediaId || null],
            idCardPhotoPositive: [this.employee.idCardPhotoPositive || null],
            idCardPhotoBack: [this.employee.idCardPhotoBack || '']
          });
        })
      )
      .subscribe();
  }

  idCardNumberChange() {
    const idCardNumber = this.form.controls['idCardNumber'].value;
    if (idCardNumber.substr(16, 1) % 2 === 1) {
      this.form.controls['gender'].setValue(Gender.Man);
    } else {
      this.form.controls['gender'].setValue(Gender.Woman);
    }
    const birthYear = idCardNumber.substring(6, 10);
    const birthMonth = idCardNumber.substring(10, 12);
    const birthDay = idCardNumber.substring(12, 14);

    let constellation;
    if ((birthMonth == 1 && birthDay > 19) || (birthMonth == 2 && birthDay < 19)) {
      constellation = Constellation.Aquarius;
    } else if ((birthMonth == 2 && birthDay > 18) || (birthMonth == 3 && birthDay < 21)) {
      constellation = Constellation.Pisces;
    } else if ((birthMonth == 3 && birthDay > 20) || (birthMonth == 4 && birthDay < 21)) {
      constellation = Constellation.Aries;
    } else if ((birthMonth == 4 && birthDay > 20) || (birthMonth == 5 && birthDay < 21)) {
      constellation = Constellation.Taurus;
    } else if ((birthMonth == 5 && birthDay > 20) || (birthMonth == 6 && birthDay < 22)) {
      constellation = Constellation.Gemini;
    } else if ((birthMonth == 6 && birthDay > 21) || (birthMonth == 7 && birthDay < 23)) {
      constellation = Constellation.Cancer;
    } else if ((birthMonth == 7 && birthDay > 22) || (birthMonth == 8 && birthDay < 23)) {
      constellation = Constellation.Leo;
    } else if ((birthMonth == 8 && birthDay > 22) || (birthMonth == 93 && birthDay < 23)) {
      constellation = Constellation.Virgo;
    } else if ((birthMonth == 9 && birthDay > 22) || (birthMonth == 10 && birthDay < 24)) {
      constellation = Constellation.Libra;
    } else if ((birthMonth == 10 && birthDay > 23) || (birthMonth == 11 && birthDay < 22)) {
      constellation = Constellation.Scorpio;
    } else if ((birthMonth == 11 && birthDay > 21) || (birthMonth == 12 && birthDay < 22)) {
      constellation = Constellation.Sagittarius;
    } else {
      constellation = Constellation.Capricorn;
    }
    console.log(constellation);

    this.form.controls['constellation'].setValue(constellation);
    this.form.controls['birthday'].setValue(toDate(`${birthYear}-${birthMonth}-${birthDay}`));
  }
  // #region 区域
  /**
   * 区域改变
   *
   * @param values 选中值
   */
  onChanges(values: string[]): void {
    if (values != null && values.length === 4) {
      this.form.patchValue({ provinceId: values[0] });
      this.form.patchValue({ cityId: values[1] });
      this.form.patchValue({ districtId: values[2] });
      this.form.patchValue({ streetId: values[3] });
    }
  }
  /**
   * 加载区域数据
   *
   * @param node
   * @param index
   * @returns
   */
  async loadData(node: NzCascaderOption, index: number): Promise<PromiseLike<void>> {
    if (index < 0) {
      return await lastValueFrom(this.regionService.getRoot()).then(response => {
        node.children = response.items as NzCascaderOption[];
      });
    } else {
      let level;
      switch (index) {
        case 0:
          level = RegionLevel.City;
          break;
        case 1:
          level = RegionLevel.District;
          break;
        case 2:
          level = RegionLevel.Street;
          break;
        case 3:
          level = RegionLevel.Village;
          break;
      }
      return await lastValueFrom(this.regionService.getChildren(node['id'], level)).then(response => {
        if (index === 2) {
          response.items.map(r => {
            r.isLeaf = true;
            node.children.push(r);
          });
        } else {
          node.children = response.items as NzCascaderOption[];
        }
      });
    }
  }
  // #endregion
  // #region 头像上传
  beforeUpload = (file: NzUploadFile, _fileList: NzUploadFile[]) => {
    return new Observable((observer: Observer<boolean>) => {
      const isJpgOrPng = file.type === 'image/jpeg' || file.type === 'image/png';
      if (!isJpgOrPng) {
        this.messageService.error('You can only upload JPG file!');
        observer.complete();
        return;
      }
      // tslint:disable-next-line: no-non-null-assertion
      const isLt2M = file.size! / 1024 / 1024 < 2;
      if (!isLt2M) {
        this.messageService.error('Image must smaller than 2MB!');
        observer.complete();
        return;
      }

      this.uploadParameters.name = file.name;

      observer.next(isJpgOrPng && isLt2M);
      observer.complete();
    });
  };
  handleChange(info: { file: NzUploadFile }): void {
    switch (info.file.status) {
      case 'uploading':
        this.uploadLoading = true;
        break;
      case 'done':
        this.uploadLoading = false;
        this.employee.coverImageMediaId = info.file.response.id;
        this.coverImage = `${environment.api.baseUrl}/${info.file.response.id}`;
        break;
      case 'error':
        this.messageService.error('Network error');
        this.uploadLoading = false;
        break;
    }
  }
  // #endregion
  save() {
    if (!this.form.valid || this.isConfirmLoading) {
      for (const key of Object.keys(this.form.controls)) {
        this.form.controls[key].markAsDirty();
        this.form.controls[key].updateValueAndValidity();
      }
      return;
    }
    this.isConfirmLoading = true;

    if (this.employeeId) {
      this.employeeService
        .update(this.employeeId, {
          ...this.employee,
          ...this.form.value,
          birthday: dateTimePickerUtil.format(this.form.controls['birthday'].value, 'yyyy-MM-dd')
        })
        .pipe(
          tap(response => {
            this.messageService.success(this.localizationService.instant('Ehr::SaveSucceed'));
            this.location.back();
          }),
          finalize(() => (this.isConfirmLoading = false))
        )
        .subscribe();
    } else {
      this.employeeService
        .create({
          ...this.form.value,
          birthday: dateTimePickerUtil.format(this.form.controls['birthday'].value, 'yyyy-MM-dd')
        })
        .pipe(
          tap(response => {
            this.messageService.success(this.localizationService.instant('Ehr::SaveSucceed'));
            this.location.back();
          }),
          finalize(() => (this.isConfirmLoading = false))
        )
        .subscribe();
    }
  }

  back(e: MouseEvent) {
    e.preventDefault();
    this.location.back();
  }
}
