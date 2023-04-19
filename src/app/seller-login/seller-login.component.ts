import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { SellerService } from '../services/seller.service';
import { Router } from '@angular/router';
import { login, signUp } from '../data-types';

@Component({
  selector: 'app-seller-login',
  templateUrl: './seller-login.component.html',
  styleUrls: ['./seller-login.component.scss']
})
export class SellerLoginComponent implements OnInit {
  
  showLogin = true;
  authError:string = '';

  constructor(private fb:FormBuilder,private seller:SellerService, private router:Router) { }

  ngOnInit(): void {
    this.seller.reloadSeller()
  }

  signUpForm = this.fb.group({
    userName:[''],
    email:[''],
    password:[''],
    confirmPassword:['']
    });

  loginForm = this.fb.group({
    email:[''],
    password:['']
  });

    openLogin(){
      this.showLogin = true;
    }

    openSignUp(){
      this.showLogin = false;
    }

    signUp(data:signUp):void{
      this.seller.userSignUp(data)
    }

    login(data:login):void{
      this.authError = '';
      // console.warn(data)
      this.seller.userLogin(data);
      this.seller.isLoginError.subscribe((isError) => {
        if (isError) {
          this.authError = 'Email or password is wrong'
        }
      });
    }
}
