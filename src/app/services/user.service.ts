import { Injectable } from '@angular/core';
import { login, signUp } from '../data-types';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private router:Router, private http:HttpClient) { }

  userSignUp(user:signUp) {
    this.http.post("http://localhost:3000/users",user,{observe:'response'})
    .subscribe((result) => {
      console.warn(result)
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
    this.http.get<login>(`http://localhost:3000/users?email=${user.email}&password=${user.password}`,
    {observe:'response'})
    .subscribe((result) => {
      if (result && result.body) {
        localStorage.setItem('user', JSON.stringify(result.body));
        this.router.navigate(['/'])
      }
    });
  }
}
