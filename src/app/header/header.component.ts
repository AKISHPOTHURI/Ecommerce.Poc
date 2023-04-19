import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  menuType: string = 'default';
  sellerName:string = 'hi';

  constructor(private router:Router) { }

  ngOnInit(): void {
    this.router.events.subscribe((val:any)=>{
      if(val.url) {
        if (localStorage.getItem('seller') && val.url.includes('seller')){
          console.warn("in seller area")
          this.menuType = "seller"
          if (localStorage.getItem('seller')){
            let sellerStore = localStorage.getItem('seller');
            let sellerData =sellerStore && JSON.parse(sellerStore)[0];
            this.sellerName = sellerData.userName
          }
        }else{
          console.warn("outside seller")
          this.menuType='default'
        }
      }
    })
  }

  logout(): void {
    localStorage.removeItem('seller');
    this.router.navigate(["/"])
  }

}
