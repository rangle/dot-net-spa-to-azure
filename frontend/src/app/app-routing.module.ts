import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CustomersComponent } from './customers/customers.component';
import { CustomersGridComponent } from './customers/customers-grid.component';
import { CustomerEditComponent } from './customers/customer-edit.component';
import { CustomerEditReactiveComponent } from './customers/customer-edit-reactive.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'counter', component: CounterComponent },
  { path: 'fetch-data', component: FetchDataComponent },
  { path: 'customers', component: CustomersComponent },
  //{ path: 'customers/:id', component: CustomerEditComponent},
  { path: 'customers/:id', component: CustomerEditReactiveComponent },
  { path: '**', pathMatch: 'full', redirectTo: '/customers' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
  static components = [HomeComponent, FetchDataComponent, CounterComponent, CustomersComponent, CustomersGridComponent, CustomerEditComponent, CustomerEditReactiveComponent];
}
