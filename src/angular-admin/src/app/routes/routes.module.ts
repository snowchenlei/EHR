import { NgModule, Type } from '@angular/core';
import { SharedModule } from '@shared';

// dashboard pages
import { DashboardComponent } from './dashboard/dashboard.component';
// single pages
import { UserLockComponent } from './passport/lock/lock.component';
// passport pages
import { UserLoginComponent } from './passport/login/login.component';
import { RouteRoutingModule } from './routes-routing.module';

const COMPONENTS: Array<Type<void>> = [
  DashboardComponent,
  // passport pages
  UserLoginComponent,
  UserLockComponent
];

@NgModule({
  imports: [SharedModule, RouteRoutingModule],
  declarations: COMPONENTS
})
export class RoutesModule {}
