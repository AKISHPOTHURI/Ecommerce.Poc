import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { AbstractControl, FormBuilder, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { login, signUp } from '../data-types';
import { Router } from '@angular/router';
import { passwordValid } from '../validators/passwordMatch';

@Component({
  selector: 'app-user-auth',
  templateUrl: './user-auth.component.html',
  styleUrls: ['./user-auth.component.scss']
})
export class UserAuthComponent implements OnInit {

  showLogin:boolean = true;
  constructor(private user:UserService, private fb:FormBuilder, private http:HttpClient, private router:Router) { }

  ngOnInit(): void {
    this.user.userReload();
  }

  userSignUpForm = this.fb.group({
    userName:['', [Validators.required]],
    email:['', [Validators.required, Validators.pattern(/^[\w]{1,}[\w.+-]{0,}@[\w-]{1,}([.][a-zA-Z]{2,}|[.][\w-]{2,}[.][a-zA-Z]{2,})$/)]],
    password:['', [Validators.required, Validators.pattern('(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&].{8,}')]],
    confirmPassword:['',[Validators.required] ]
    },{validator:passwordValid});

  loginForm = this.fb.group({
    email:['', [Validators.required]],
    password:['', [Validators.required]]
  });

    openLogin(){
      this.showLogin = true;
    }

    openSignUp(){
      this.showLogin = false;
    }

    userSignUp(user:signUp):void{
      this.user.userSignUp(user);
    }

    userLogin(user:login) {
      this.user.userLogin(user);
    }

}
