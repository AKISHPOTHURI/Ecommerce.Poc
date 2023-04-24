import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { FormBuilder } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { signUp } from '../data-types';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-auth',
  templateUrl: './user-auth.component.html',
  styleUrls: ['./user-auth.component.scss']
})
export class UserAuthComponent implements OnInit {

  constructor(private user:UserService, private fb:FormBuilder, private http:HttpClient, private router:Router) { }

  ngOnInit(): void {
    this.user.userReload();
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

    // openLogin(){
    //   this.showLogin = true;
    // }

    // openSignUp(){
    //   this.showLogin = false;
    // }

    userSignUp(user:signUp):void{
      this.http.post("http://localhost:3000/users",user,{observe:'response'})
      .subscribe((result) => {
        console.warn(result)
        if (result) {
          localStorage.setItem('user', JSON.stringify(result.body));
          this.router.navigate(['/'])
        }
      })
    }

    // login(data:login):void{
    //   this.authError = '';
    //   // console.warn(data)
    //   this.user.userLogin(data);
    //   this.user.isLoginError.subscribe((isError) => {
    //     if (isError) {
    //       this.authError = 'Email or password is wrong'
    //     }
    //   });
    // }

}
