export interface signUp{
    name:string,
    password:string,
    email:string
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
    id:number
}