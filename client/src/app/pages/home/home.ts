import { Component, inject } from '@angular/core';
import { UserService } from '../../service/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'home',
  templateUrl: './home.html',
  standalone: false
})

export class HomePage {

  private userService = inject(UserService);
  
  logout(){
    this.userService.logout();
  }
}
