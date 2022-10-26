import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ShareService } from 'src/app/Services/share.service';
import {MatIconModule} from '@angular/material/icon';
import { NavbarServiceService } from 'src/app/Services/navbar-service.service';
import { FooterService } from 'src/app/Services/footer.service';
import { NgIf } from '@angular/common';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import {Payment} from 'src/app/Models/Payment.model';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import jsPDF from 'jspdf';
import Cart from 'src/app/Models/Cart.model';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {
  Paymentform=new FormGroup({

    CardHolderName:new FormControl('', Validators.required),
    Email:new FormControl('', Validators.required),
    transactionAmount:new FormControl(''),
    Cardnumber : new FormControl('',[Validators.required , Validators.minLength(16) , Validators.maxLength(16)]),
    CardCVV : new FormControl('',[Validators.required , Validators.minLength(3) , Validators.maxLength(3)]),
    Mode: new FormControl('',),
  });
  submitted=false;
  get CardHolderName() {
    return this.Paymentform.get('CardHolderName');
  }
  get Email() {
    return this.Paymentform.get('Email');
  }
  get transactionAmount() {
    return this.Paymentform.get('transactionAmount');
  }
  get Mode() {
    return this.Paymentform.get('Mode');
  }
  get Cardnumber() {
    return this.Paymentform.get('Cardnumber');
  }
  get CardCVV() {
    return this.Paymentform.get('CardCVV');
  }

  public order:Cart[];
  public payment:Payment[];
  readonly APIUrl ="https://localhost:44339"
  constructor(private shared:ShareService, private nav:NavbarServiceService, private fs:FooterService,private router :Router) { }

  ngOnInit(): void {
    this.fs.show();
    this.nav.show();
    this.nav.isLogin();
    this.nav.showCart();
    this.getTotalAmount();
  }

  getTotalAmount(){
    this.shared.GetAllCart().subscribe(data=>{
       this.order=data;
       console.log(this.order)
    });
  }

  public grandTotal():number{
    let total : number = 0;
    for(let order of this.order){
      total+= order.quantity* order.price;
    }
    return total;
  }

  onSubmit() {
    this.submitted = true;
    console.log(this.Paymentform.value)

    if(Number(this.Paymentform.value.transactionAmount) === this.grandTotal())
    {
      this.shared.addpaymentTransaction(this.Paymentform.value)
      .subscribe({
        next:(res)=>{
          this.Paymentform.reset();
          this.router.navigate(['order-successful']);
        },
        error:(err)=>{
          if(err.status==200){
            this.Paymentform.reset();
            this.router.navigate(['order-successful']);
          }
          else{
            alert("Transaction Failed");
          }
        }
      });
    }
    else
    {
      alert("Please Enter Correct Amount!!")
    }
}

}
