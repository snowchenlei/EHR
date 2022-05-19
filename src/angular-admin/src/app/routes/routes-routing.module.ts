import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SimpleGuard } from '@delon/auth';
import { environment } from '@env/environment';

// layout
import { LayoutBasicComponent } from '../layout/basic/basic.component';
import { LayoutPassportComponent } from '../layout/passport/passport.component';
// dashboard pages
import { DashboardComponent } from './dashboard/dashboard.component';
// single pages
import { UserLockComponent } from './passport/lock/lock.component';
// passport pages
import { UserLoginComponent } from './passport/login/login.component';

const routes: Routes = [
  {
    path: '',
    component: LayoutBasicComponent,
    canActivate: [SimpleGuard],
    children: [
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
      { path: 'dashboard', component: DashboardComponent, data: { title: '仪表盘', titleI18n: 'dashboard' } },
      { path: 'exception', loadChildren: () => import('./exception/exception.module').then(m => m.ExceptionModule) },
      {
        path: 'menu-management',
        loadChildren: () => import('@snow/ng.menu-management').then(m => m.MenuManagementModule)
      },
      {
        path: 'dictionary-management',
        loadChildren: () => import('@snow/ng.dictionary-management').then(m => m.DictionaryManagementModule)
      },
      {
        path: 'identity',
        loadChildren: () => import('@snow/ng.identity').then(m => m.IdentityModule)
      },
      // 业务子模块
      // { path: 'widgets', loadChildren: () => import('./widgets/widgets.module').then(m => m.WidgetsModule) },
      {
        path: 'employee-management',
        loadChildren: () => import('./employee-management/employee-management.module').then(m => m.EmployeeManagementModule)
      }
    ]
  },
  // 空白布局
  // {
  //     path: 'blank',
  //     component: LayoutBlankComponent,
  //     children: [
  //     ]
  // },
  // passport
  {
    path: 'passport',
    component: LayoutPassportComponent,
    children: [
      { path: 'login', component: UserLoginComponent, data: { title: '登录', titleI18n: 'pro-login' } },
      { path: 'lock', component: UserLockComponent, data: { title: '锁屏', titleI18n: 'lock' } }
    ]
  },
  // 单页不包裹Layout
  { path: '**', redirectTo: 'exception/404' }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, {
      useHash: environment.useHash,
      // NOTICE: If you use `reuse-tab` component and turn on keepingScroll you can set to `disabled`
      // Pls refer to https://ng-alain.com/components/reuse-tab
      scrollPositionRestoration: 'top'
    })
  ],
  exports: [RouterModule]
})
export class RouteRoutingModule {}
