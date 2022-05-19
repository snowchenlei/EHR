import { RestService } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class EnumService {
  apiName = 'Default';

  getBloodType = () =>
    this.restService.request<any, Record<number, string>>(
      {
        method: 'GET',
        url: '/api/enum/blood-type'
      },
      { apiName: this.apiName }
    );

  getConstellation = () =>
    this.restService.request<any, Record<number, string>>(
      {
        method: 'GET',
        url: '/api/enum/constellation'
      },
      { apiName: this.apiName }
    );

  getGender = () =>
    this.restService.request<any, Record<number, string>>(
      {
        method: 'GET',
        url: '/api/enum/gender'
      },
      { apiName: this.apiName }
    );

  getInServiceStatus = () =>
    this.restService.request<any, Record<number, string>>(
      {
        method: 'GET',
        url: '/api/enum/in-service-status'
      },
      { apiName: this.apiName }
    );

  getMaritalStatus = () =>
    this.restService.request<any, Record<number, string>>(
      {
        method: 'GET',
        url: '/api/enum/marital-status'
      },
      { apiName: this.apiName }
    );

  getPoliticalStatus = () =>
    this.restService.request<any, Record<number, string>>(
      {
        method: 'GET',
        url: '/api/enum/political-status'
      },
      { apiName: this.apiName }
    );

  getZodiac = () =>
    this.restService.request<any, Record<number, string>>(
      {
        method: 'GET',
        url: '/api/enum/zodiac'
      },
      { apiName: this.apiName }
    );

  constructor(private restService: RestService) {}
}
