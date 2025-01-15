import { inject, Injectable, signal } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { User } from '../_models/user';
import { map } from 'rxjs';
import { Router } from '@angular/router';


@Injectable({
  providedIn: 'root'
})
export class UserService {
  private http = inject(HttpClient);
  private router = inject(Router)
  
  private baseUrl = environment.baseUrl;
  currentUser = signal<User | null>(null)
  
  constructor() { }

  login(model){
    return this.http.post<User>(this.baseUrl + 'Account/login',model)
    .pipe(map(user => {
      if (user) {
        localStorage.setItem('RefuseTDSUser', JSON.stringify(user));
        this.currentUser.set(user);
        console.warn(this.currentUser());
        this.router.navigate(['home']);
      }
    }))
  }

  logout(){
    localStorage.removeItem('RefuseTDSUser');
    this.currentUser.set(null);
    this.router.navigate(['login'])
  }

  register(formData){
    return this.http.post(this.baseUrl+'Account/Register',formData)
  }
}
