import { Component, OnInit } from '@angular/core';
import { ProductService } from '../services/product.service';
import { product } from '../data-types';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  // images = [944, 1011, 984].map((n) => `https://picsum.photos/id/${n}/900/500`);
  popularProducts: undefined | product[]
  constructor(private product:ProductService) { }

  ngOnInit(): void {
    this.product.popularProduct().subscribe((data) => {
      console.warn(data)
      this.popularProducts = data;
    })
  }

}
