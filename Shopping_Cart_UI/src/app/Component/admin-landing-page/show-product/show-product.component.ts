import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/Models/Product.model';
import { HttpClient } from '@angular/common/http';
import { Observable,} from 'rxjs';
import { ShareService } from 'src/app/Services/share.service';
import { NavbarServiceService } from 'src/app/Services/navbar-service.service';
import { FormControl, Validators } from '@angular/forms';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
@Component({
  selector: 'app-show-product',
  templateUrl: './show-product.component.html',
  styleUrls: ['./show-product.component.css']
})
export class ShowProductComponent implements OnInit {
   public products:Product[];
  //  _ProductForm = new FormGroup({
  //   productId: new FormControl(''),
  //   productName: new FormControl('', Validators.required),
  //   price: new FormControl('', Validators.required),
  //   productImage: new FormControl('', Validators.required),
  //   description: new FormControl('', Validators.required),
  //   category: new FormControl('', Validators.required)
  // });
  
  // submitted=false;
  // get productId(){
  //   return this._ProductForm.get('productId');
  // }
  // get prouctName() {
  //   return this._ProductForm.get('productName');
  // }
  // get price() {
  //   return this._ProductForm.get('price');
  // }
  // get productImage() {
  //   return this._ProductForm.get('productImage');
  // }
  // get description(){
  //   return this._ProductForm.get('description');
  // }
  // get category(){
  //   return this._ProductForm.get('category');
  // }
  // displayStyle = "none";
  
  // ModalTitle:string;
  
  // router: any;
  // modalInput: number;
  constructor(private router:Router, private service:ShareService,private http:HttpClient, public nav:NavbarServiceService ) {}
  
  // ActivateAddEditProd:boolean=false;
  // Product:any;
  ngOnInit(): void {
    this.nav.show();
    this.nav.isLogin();
    this.nav.hideCart();
    this.refreshList();
  }
delete(id:number){
  if(confirm('Are you sure?')){
    this.service.DeleteProduct(id)
    .subscribe({
      next:(res)=>{        
              console.log(res);
              alert("Deleted Successfully");
              this.refreshList();
              location.reload();
      },
      error:(err)=>{
          if(err.status==200){
              //console.log(res);
              alert("Deleted Successfully");
              this.refreshList();
              location.reload();
          }
          else{
            alert("Failed to delete");
          }
      }
    });
  }
  
} 
refreshList(){
      this.service.GetAllProduct().subscribe(data=>{
        this.products=data;
        console.log(this.products)
      });

      
//   openPopup1() {
//     this.displayStyle = "block";
//     this.ModalTitle="Add Product";
   
//   }
//   openPopup() {
//     this.displayStyle = "block";
//     this.ModalTitle="Add Product";
   
//   }
  
//   closePopup() {
//     this.displayStyle = "none";
//     location.reload();
//   }
//   
    
//   }
//   editClick(id:number){
//     this.displayStyle = "block";
//     console.log(id);
    
//     this.ModalTitle="Edit Product";
   
//   }
//   EditProduct(){
    
//     this.service.UpdateProduct(this._ProductForm.value).subscribe((result)=>{
  
//     });
 }
 onLogout() {
  localStorage.clear();
  this.router.navigate(['/home']);
}
}
