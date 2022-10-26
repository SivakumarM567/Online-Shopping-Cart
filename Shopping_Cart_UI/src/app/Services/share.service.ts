import { Injectable } from '@angular/core';
import { HttpClient ,HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, map, Observable } from 'rxjs'; 
import { UserDetails } from '../Models/UserDetails.model';
import { Product } from '../Models/Product.model';
import cart from '../Models/Cart.model';
import { feedback } from '../Models/feedback.model';

@Injectable({
  providedIn: 'root'
})
export class ShareService {
  public userService =  UserDetails;
  public products :Product[];
  public product:Product;
  public cart:cart[];
  public search = new BehaviorSubject<string>("");
  readonly APIUrl ="https://localhost:7139"
  constructor(private http:HttpClient) { }

//Product Service

GetAllProduct():Observable<Product[]>{
  return this.http.get<Product[]>(this.APIUrl+'/api/Product/GetAllProduct()')
}
readonly apiurl="https://localhost:7139/api/Product/SaveProduct"
Addproduct(val:any){
  console.log(val)
  return this.http.post(this.apiurl,val);
}

UpdateProduct(val:any){
  return this.http.put<Product[]>(this.APIUrl+'/api/Product/UpdateProduct',val);
}
DeleteProduct(id:number){
  return this.http.delete<Product[]>(this.APIUrl+'/api/Product/DeleteProduct?ProductId='+id);
}
GetProduct(val:any){
  return this.http.post(this.APIUrl+'api/Product/GetProduct?ProductId=',val);
}

//Cart Service
UpdateCart(val:any){
  return this.http.put(this.APIUrl+'/api/Cart/UpdateCart',val)
}
addToCart(val:any){
  return this.http.post<cart>(this.APIUrl+'/api/Cart/SaveCart',val);
}
GetAllCart():Observable<cart[]>
{
return this.http.get<cart[]>(this.APIUrl+'/api/Cart/GetAllCart')
}
DeleteFromCart(id:number)
{ return this.http.delete<cart[]>(this.APIUrl+'/api/Cart/DeleteCart?CartId='+id)
}

//User service


GetAllUserDetails():Observable<any[]>{
  return this.http.get<any[]>(this.APIUrl+'/api/UserDetails/GetAllUserDetails()')
}
addUserDetails(val:any){
  console.log(val);
  return this.http.post<UserDetails>(this.APIUrl+'/api/UserDetails/SaveUserDetails',val)
  }
userlogin(val:any){
  console.log(val);
  return this.http.post<UserDetails>(this.APIUrl+'/api/UserDetails/login',val)
}
EmailService(name:any,receiver:any){
  return this.http.get<any[]>(this.APIUrl+'/api/UserDetails/EmailService?name='+name+'&receiver='+receiver)
 }
 getUserProfile(){
  var tokenHeader = new HttpHeaders({'Authorization':'Bearer '+localStorage.getItem('token')})
  console.log(tokenHeader);
  return this.http.get(this.APIUrl+'/api/UserDetails/GetUserDetails?UserId=', {headers : tokenHeader});
}

//Order Service
addOrderDetails(val:any){
  console.log(val);
  return this.http.post<cart[]>(this.APIUrl+'/api/Order/SaveOrderDetails',val)
}

//Feedback Service
GetAllFeedDetails():Observable<feedback[]>
{
 return this.http.get<feedback[]>(this.APIUrl+'/api/Feedback/GetAllFeedDetails()')
}
addFeedDetails(val:any){
  console.log(val);
  return this.http.post<feedback>(this.APIUrl+'/api/Feedback/SaveFeedDetails',val)
}
//Payment Service
addpaymentTransaction(val:any){
  console.log(val);
  return this.http.post<feedback>(this.APIUrl+'/api/Payment/SaveTransaction',val)
}

}





























// GetAllOrderDetails():Observable<order[]>
// {
//   return this.http.get<order[]>(this.APIUrl+'/api/Order/GetAllOrderDetails()')
// }

    //  GetAllUserDetailsbyEmail(val:any):{
    //   console.log(val);
    //   return this.http.get<UserDetails[]>(this.APIUrl+'api/UserDetails/GetUserbyEmail?EmailId=',val)
    //   }

///api/UserDetails/GetUserbyEmail