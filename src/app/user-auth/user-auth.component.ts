import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { AbstractControl, FormBuilder, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { cart, login, product, signUp } from '../data-types';
import { Router } from '@angular/router';
import { passwordValid } from '../validators/passwordMatch';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-user-auth',
  templateUrl: './user-auth.component.html',
  styleUrls: ['./user-auth.component.scss'],
})
export class UserAuthComponent implements OnInit {
  showLogin: boolean = true;
  authError: string = '';
  constructor(
    private user: UserService,
    private fb: FormBuilder,
    private http: HttpClient,
    private router: Router,
    private product: ProductService
  ) {}

  ngOnInit(): void {
    this.user.userReload();
  }

  userSignUpForm = this.fb.group(
    {
      userName: ['', [Validators.required]],
      email: [
        '',
        [
          Validators.required,
          Validators.pattern(
            /^[\w]{1,}[\w.+-]{0,}@[\w-]{1,}([.][a-zA-Z]{2,}|[.][\w-]{2,}[.][a-zA-Z]{2,})$/
          ),
        ],
      ],
      password: [
        '',
        [
          Validators.required,
          Validators.pattern(
            '(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-zd$@$!%*?&].{8,}'
          ),
        ],
      ],
      confirmPassword: ['', [Validators.required]],
    },
    { validator: passwordValid }
  );

  loginForm = this.fb.group({
    email: [
      '',
      [
        Validators.required,
        Validators.pattern(
          /^[\w]{1,}[\w.+-]{0,}@[\w-]{1,}([.][a-zA-Z]{2,}|[.][\w-]{2,}[.][a-zA-Z]{2,})$/
        ),
      ],
    ],
    password: [
      '',
      [
        Validators.required,
        Validators.pattern(
          '(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-zd$@$!%*?&].{8,}'
        ),
      ],
    ],
  });

  openLogin() {
    this.showLogin = true;
  }

  openSignUp() {
    this.showLogin = false;
  }

  userSignUp(user: signUp): void {
    this.user.userSignUp(user);
  }

  userLogin(user: login) {
    this.user.userLogin(user);
    this.user.invalidUserAuth.subscribe((result) => {
      if (result) {
        this.authError = 'Invalid Email Id or Password';
      } else {
        console.log("user Logged in")
        this.localCartToRemoteCart();
      }
    });
  }

  localCartToRemoteCart() {
    let data = localStorage.getItem('localCart');
    if (data) {
      let cartDataList: product[] = JSON.parse(data);
      let user = localStorage.getItem('user');
      let userId = user && JSON.parse(user).id;

      cartDataList.forEach((product: product, index) => {
        let cartData: cart = {
          ...product,
          productId: product.id,
          userId,
        };
        delete cartData.id;
        setTimeout(() => {
          this.product.addToCart(cartData).subscribe((result) => {
          if (result) {
              console.log('Item stored in DB');
          }
          });
          if (cartDataList.length === index + 1) {
            localStorage.removeItem('localCart');
          }
        }, 500);
      });
    }
  }
}
