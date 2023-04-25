export interface signUp{
    name:string,
    email:string,
    password:string,
    confirmPassword:string
    
}

export interface login {
    email:String,
    password:string
}

export interface product{
    productName:string,
    productPrice:string,
    productColor:string,
    productCategory:string,
    productDescription:string,
    productImageUrl:string,
    id:number,
    productId:number
}