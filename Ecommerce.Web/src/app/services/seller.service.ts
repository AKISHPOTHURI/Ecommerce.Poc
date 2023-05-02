import { Injectable, EventEmitter } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { login, signUp } from '../data-types';
import { BehaviorSubject } from 'rxjs';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class SellerService {
  isSellerLoggedIn = new BehaviorSubject<boolean>(false);
  isLoginError = new EventEmitter<boolean>(false)
  constructor(private http: HttpClient, private router: Router) {}
  userSignUp(data: signUp) {
    this.http
      .post('http://localhost:3000/seller', data, { observe: 'response' })
      .subscribe((result) => {
        this.isSellerLoggedIn.next(true);
        localStorage.setItem('seller', JSON.stringify(result.body));
        this.router.navigate(['sellerhome']);
      });
  }

  reloadSeller() {
    if (localStorage.getItem('seller')) {
      this.isSellerLoggedIn.next(true);
      this.router.navigate(['sellerhome'])
    }
  }
  
  userLogin(data:login) {
    this.http
    .get(`http://localhost:3000/seller?email=${data.email}&password=${data.password}`, { observe: 'response' })
    .subscribe((result:any) => {
      
      if (result && result.body && result.body.length) {
        localStorage.setItem('seller',JSON.stringify(result.body));
        this.router.navigate(['sellerhome']);
      }else{
        console.log("Failed to login");
        this.isLoginError.emit(true);
      }
    })
  }

}
