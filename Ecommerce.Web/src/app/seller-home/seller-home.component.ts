import { Component, OnInit } from '@angular/core';
import { ProductService } from '../services/product.service';
import { MatTableDataSource } from '@angular/material/table';
import { faTrash } from '@fortawesome/free-solid-svg-icons';
import { product } from '../data-types';

@Component({
  selector: 'app-seller-home',
  templateUrl: './seller-home.component.html',
  styleUrls: ['./seller-home.component.scss']
})
export class SellerHomeComponent implements OnInit {
  public dataSource:any = []
  private dataArray: any;
  icon = faTrash;
  productMessage: undefined | string;

      public displayedColumns:string[] = ["productName","productPrice","productColor","productCategory","productDescription","productImageUrl","Actions"]

  constructor(private product:ProductService) { }

  ngOnInit(): void {
    this.displayProduct();
  }

  deleteProduct(id:number) {
    this.product.deleteProduct(id).subscribe((result) => {
      if (result) {
        this.productMessage = "Product deleted"
      }
      this.displayProduct();
    })
    setTimeout(() => {
      this.productMessage = undefined;
    },2000)
  }

  displayProduct() {
    this.product.productList().subscribe((result) => {
      this.dataArray=result
      this.dataSource=new MatTableDataSource<product>(this.dataArray)
    });
  }
}
