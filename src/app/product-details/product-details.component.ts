import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from '../services/product.service';
import { product } from '../data-types';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
  productData: undefined | product;
  productQuantity:number=1;
  quantity:number=1;
 constructor(private activateRoute:ActivatedRoute, private product:ProductService) { }

  ngOnInit(): void {
    let productId = this.activateRoute.snapshot.paramMap.get('productId');
    productId && this.product.getProduct(productId).subscribe((result) => {
      this.productData =result;
    })
  }

  handleQuantity(val:string){
    if(this.productQuantity<20 && val === 'plus'){
      this.productQuantity += 1
    }else if(this.productQuantity>1 && val === 'min'){
      this.productQuantity -= 1
    }
  }

  addToCart() {
    if(this.productData){
      this.productData.quantity = this.productQuantity;
      console.log("productQuantity:", this.productData.quantity)
      if(localStorage.getItem('user')) {
        this.product.localAddToCart(this.productData);
        console.log(this.productData)
      }
    }
  }

}
