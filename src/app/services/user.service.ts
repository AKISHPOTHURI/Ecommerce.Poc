import { Injectable } from '@angular/core';
import { signUp } from '../data-types';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private router:Router) { }

  userSignUp(user:signUp) {
    console.warn(user)
  }

  userReload() {
    if (localStorage.getItem('user')) {
      this.router.navigate(['/']);
    }
  }
}
