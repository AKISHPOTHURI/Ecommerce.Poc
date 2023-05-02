import { Injectable } from '@angular/core';
import { login, signUp } from '../data-types';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { EventEmitter } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  invalidUserAuth = new EventEmitter<boolean>(false);
  constructor(private router:Router, private http:HttpClient) { }

  userSignUp(user:signUp) {
    this.http.post("http://localhost:3000/users",user,{observe:'response'})
    .subscribe((result) => {
      if (result) {
        localStorage.setItem('user', JSON.stringify(result.body));
        this.router.navigate(['/'])
      }
    })
  }

  userReload() {
    if (localStorage.getItem('user')) {
      this.router.navigate(['/']);
    }
  }

  userLogin(user:login) {
    this.http.get(`http://localhost:3000/users?email=${user.email}&password=${user.password}`,
    {observe:'response'})
    .subscribe((result:any) => {
      if (result && result.body && result.body.length) {
        localStorage.setItem('user', JSON.stringify(result.body[0]));
        this.router.navigate(['/'])
        this.invalidUserAuth.emit(false);
      } else {
        this.invalidUserAuth.emit(true);
      }
    });
  }
}
