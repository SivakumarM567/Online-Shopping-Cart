import { Component, OnInit } from '@angular/core';
import { NavbarServiceService } from 'src/app/Services/navbar-service.service';
import { MatIcon } from '@angular/material/icon';
import { Router } from '@angular/router';
@Component({
 
  selector: 'sd-navbar',
   templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  logedIn:any;
  constructor(public nav: NavbarServiceService,public router:Router) { }

  ngOnInit(): void {
  }
  onLogout() {
    localStorage.clear();
    // location.reload();
    this.router.navigate(['/home']);
  }
}
