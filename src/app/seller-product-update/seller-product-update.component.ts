import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-seller-product-update',
  templateUrl: './seller-product-update.component.html',
  styleUrls: ['./seller-product-update.component.scss']
})
export class SellerProductUpdateComponent implements OnInit {
  public updateProductForm:FormGroup
  public productData:any
  constructor(private fb:FormBuilder, private route:ActivatedRoute,private product:ProductService, private router:Router) {
    this.updateProductForm=this.fb.group({
      productName:'',
        productPrice:'',
        productColor:'',
        productCategory:'',
        productDescription:'',
        productImageUrl:''
    })
   

    // let productId = this.route.snapshot.paramMap.get('id')
    // console.warn(productId)
    // productId && this.product.getProduct(productId).subscribe((data) => {
    //  this.productData=data
    //  console.log(this.productData.productName);
    //  this.updateProductForm.controls["productName"].setValue(this.productData.productName)
    //  this.updateProductForm.controls["productPrice"].setValue(this.productData.productPrice)
    //  this.updateProductForm.controls["productColor"].setValue(this.productData.productColor)
    //  this.updateProductForm.controls["productCategory"].setValue(this.productData.productCategory)
    //  this.updateProductForm.controls["productDescription"].setValue(this.productData.productDescription)
    //  this.updateProductForm.controls["productImageUrl"].setValue(this.productData.productImageUrl)
   
    // })

    }

  ngOnInit(): void {

    let productId = this.route.snapshot.paramMap.get('id')
    productId && this.product.getProduct(productId).subscribe((data) => {
     this.productData=data
     this.updateProductForm.controls["productName"].setValue(this.productData.productName)
     this.updateProductForm.controls["productPrice"].setValue(this.productData.productPrice)
     this.updateProductForm.controls["productColor"].setValue(this.productData.productColor)
     this.updateProductForm.controls["productCategory"].setValue(this.productData.productCategory)
     this.updateProductForm.controls["productDescription"].setValue(this.productData.productDescription)
     this.updateProductForm.controls["productImageUrl"].setValue(this.productData.productImageUrl)
   
    })
  }

  submit(data:any) {
    let productId = this.route.snapshot.paramMap.get('id')
    productId && this.product.updateProduct(productId,data).subscribe((data) => {
     this.productData=data
     this.router.navigate(['/sellerhome'])
    })

  }
}
