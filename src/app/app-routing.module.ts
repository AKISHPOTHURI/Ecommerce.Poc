import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { SellerLoginComponent } from './seller-login/seller-login.component';
import { SellerHomeComponent } from './seller-home/seller-home.component';
import { AuthGuard } from './auth.guard';
import { SellerAddProductComponent } from './seller-add-product/seller-add-product.component';
import { SellerProductUpdateComponent } from './seller-product-update/seller-product-update.component';

const routes: Routes = [
  {path:'',component:HomeComponent},
  {path:'login',component:LoginComponent},
  {path:'sellerlogin', component:SellerLoginComponent},
  {path:'sellerhome', component:SellerHomeComponent,canActivate:[AuthGuard]},
  {path:'selleraddproduct', component:SellerAddProductComponent, canActivate:[AuthGuard]},
  {path:'sellerproductupdate/:id', component:SellerProductUpdateComponent, canActivate:[AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
export const routingComponents = [HomeComponent,LoginComponent,SellerLoginComponent,SellerAddProductComponent,SellerProductUpdateComponent]
