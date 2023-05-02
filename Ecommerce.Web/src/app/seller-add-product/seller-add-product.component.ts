import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ProductService } from '../services/product.service';
import { product } from '../data-types';

@Component({
  selector: 'app-seller-add-product',
  templateUrl: './seller-add-product.component.html',
  styleUrls: ['./seller-add-product.component.scss']
})
export class SellerAddProductComponent implements OnInit {
  
  addProductMessage:string | undefined;

  constructor( private fb:FormBuilder, private product:ProductService) { }

  ngOnInit(): void {
  }
addProductForm = this.fb.group({
  productName:[''],
  productPrice:[''],
  productColor:[''],
  productCategory:[''],
  productDescription:[''],
  productImageUrl:['']
});

submit(data:product) {
  this.product.addProduct(data).subscribe((result) => {
    if (result) {
      this.addProductMessage = "Product is successfully added"
    }
    setTimeout(() => (this.addProductMessage = undefined),3000)
  });
}
}