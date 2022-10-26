
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class NavbarServiceService {
  visible: boolean;
  logedIn: boolean;
  cart:boolean;

  constructor() { this.visible = false; }

  hide() { this.visible = false; }

  show() { this.visible = true; }

  isLogin() {
    if(localStorage.getItem('token'))
      this.logedIn = true
    else
      this.logedIn = false
  }

  showCart(){ this.cart = true }

  hideCart(){ this.cart = false }

  toggle() { this.visible = !this.visible; }

  doSomethingElseUseful() { }

  
}
