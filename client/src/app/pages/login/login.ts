import { Component, inject } from '@angular/core';
import { UserService } from '../../service/user.service';

@Component({
  selector: 'login',
  templateUrl: './login.html',
  standalone : false
})

export class Login {

  constructor(){}

  private userService = inject(UserService);
  
  invalidCredentials : any;
  currentYear : any = new Date().getFullYear();
  
  login(formData){
    console.log(formData.value)
    this.invalidCredentials = null;
    this.userService.login(formData.value).subscribe({  
      next:(d)=>{
        console.warn(this.userService.currentUser());
        
      },
      error:(e)=>{
        console.error(e)
        this.invalidCredentials = e.error;
      }
    })
  }
}
