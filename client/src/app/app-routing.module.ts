import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';

// Home
import { HomePage } from './pages/home/home';
import { Login } from './pages/login/login';

// Error
import { ErrorPage } from './pages/error/error';
import { RegisterComponent } from './pages/register/register.component';

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component : Login, data : { title : 'Login'}},
  { path: 'register', component : RegisterComponent, data : { title : 'Login'}},
  { path: 'home', component: HomePage, data: { title: 'Home'} },
  
	{ path: '**', component: ErrorPage, data: { title: '404 Error'} }
];

@NgModule({
  imports: [ CommonModule, RouterModule.forRoot(routes) ],
  exports: [ RouterModule ],
  declarations: []
})


export class AppRoutingModule { }
