import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Product } from 'src/app/Models/Product.model';
import { NavbarServiceService } from 'src/app/Services/navbar-service.service';
import { FooterService } from 'src/app/Services/footer.service';
import { ShareService } from 'src/app/Services/share.service';
@Component({
  selector: 'app-add-edit-products',
  templateUrl: './add-edit-products.component.html',
  styleUrls: ['./add-edit-products.component.css']
})
export class AddEditProductsComponent implements OnInit {
  public products:Product[];
   ProductForm = new FormGroup({
    productId: new FormControl('',Validators.required),
    productName: new FormControl('',Validators.required),
    price: new FormControl('',Validators.required),
    productImage: new FormControl('',Validators.required),
    description: new FormControl('',Validators.required),
    category: new FormControl('',Validators.required)
  });
  
  submitted=false;
  get productId(){
    return this.ProductForm.get('productId');
  }
  get productName() {
    return this.ProductForm.get('productName');
  }
  get price() {
    return this.ProductForm.get('price');
  }
  get productImage() {
    return this.ProductForm.get('productImage');
  }
  get description(){
    return this.ProductForm.get('description');
  }
  get category(){
    return this.ProductForm.get('category');
  }
  displayStyle = "none";
  constructor( public shared:ShareService,public nav:NavbarServiceService,public fs:FooterService,private router:Router) { }

  ngOnInit(): void {
    this.nav.show();
    this.nav.hideCart();
    this.nav.isLogin();
    this.fs.show();
  }

  EditProduct(){
    console.log(this.ProductForm.value)
    this.shared.UpdateProduct(this.ProductForm.value)
    .subscribe({
      next:(res)=>{
        alert("Product Edited Successfully");
        this.ProductForm.reset();
        this.router.navigate(['login/admin']);

      },
      error:(err)=>{
          if(err.status==200)
          {
            alert("Product Edited Successfully");
            this.ProductForm.reset();
            this.router.navigate(['login/admin']);
          }
          else{
            alert("Failed to update");
          }
      }
    });
 }
}
