import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/Models/Product.model';
import { ShareService } from 'src/app/Services/share.service';
import { NavbarServiceService } from 'src/app/Services/navbar-service.service';
import { FooterService } from 'src/app/Services/footer.service';
import Cart from 'src/app/Models/Cart.model';
import { LoginComponent } from '../login/login.component';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
 public products: Product[] ;
 p:number = 1;
 itemsPerPage:number = 6;
 totalProduct:any;
 searchKey:string ="";
 public searchTerm !: string;
 
  constructor(private service:ShareService,private nav :NavbarServiceService ,private fs :FooterService) { }

  ngOnInit(): void {
    this.refreshProductList();
    this.nav.show();
    this.nav.isLogin();
    this.nav.showCart();
    //this.nav.hide();
    this.nav.doSomethingElseUseful();
    this.fs.show();
    this.fs.doSomethingElseUseful(); 

    this.service.search.subscribe((val:any)=>{
      this.searchKey = val;
    })
  }
  refreshProductList(){
    this.service.GetAllProduct().subscribe(data=>{
      this.products=data;
      this.totalProduct = data.length;
      console.log(this.products)
    });
  }

  search(event:any){
    this.searchTerm = (event.target as HTMLInputElement).value;
    console.log(this.searchTerm);
    this.service.search.next(this.searchTerm);
  }

  addToCart(products:Product){
    
    console.log(products);
    
      this.service.addToCart(products)
      .subscribe({
        next:(res)=>{
          alert("Added to Cart!");
        },
        error:(err)=>{
            if(err.status==200)
              alert("Added to Cart!");
            else
              alert("Failed to add");
        }
        
      });
      
    }

}
