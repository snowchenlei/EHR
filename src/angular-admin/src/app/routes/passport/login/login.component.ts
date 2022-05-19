import { AuthService } from '@abp/ng.core';
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, Inject, OnDestroy, Optional } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { StartupService } from '@core';
import { ReuseTabService } from '@delon/abc/reuse-tab';
import { DA_SERVICE_TOKEN, ITokenService, SocialOpenType, SocialService } from '@delon/auth';
import { SettingsService, _HttpClient } from '@delon/theme';
import { environment } from '@env/environment';
import { OAuthService } from 'angular-oauth2-oidc';
import { NzTabChangeEvent } from 'ng-zorro-antd/tabs';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'passport-login',
  template: '',
  providers: [SocialService],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class UserLoginComponent {
  constructor(
    private router: Router,
    @Inject(DA_SERVICE_TOKEN) private tokenService: ITokenService,
    private startupSrv: StartupService,
    private authService: AuthService,
    private oAuthService: OAuthService
  ) {
    debugger;
    if (this.oAuthService.hasValidAccessToken()) {
      console.log(this.oAuthService.getAccessTokenExpiration());
      this.tokenService.set({
        token: this.oAuthService.getAccessToken(),
        expired: this.oAuthService.getAccessTokenExpiration()
      });
      // 重新获取 StartupService 内容，我们始终认为应用信息一般都会受当前用户授权范围而影响
      // TODO:回调里跳转
      this.startupSrv.load().subscribe(() => {
        let url = this.tokenService.referrer?.url || '/';
        if (url.includes('/passport')) {
          url = '/';
        }
        this.router.navigateByUrl(url);
      });
    } else {
      this.authService.navigateToLogin();
    }
  }
}
