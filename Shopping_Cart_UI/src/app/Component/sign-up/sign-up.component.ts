import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, NgForm } from '@angular/forms';
import { ShareService } from 'src/app/Services/share.service';
import { Router } from '@angular/router';
import { UserDetails } from 'src/app/Models/UserDetails.model';
import { NavbarServiceService } from 'src/app/Services/navbar-service.service';
import { FooterService } from 'src/app/Services/footer.service';
@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {

  SignUpform = new FormGroup({
    Role: new FormControl('', Validators.required),
    FirstName : new FormControl('', Validators.required),
    LastName : new FormControl,
    EmailId : new FormControl('',[Validators.required , Validators.email]),
    MobileNumber : new FormControl('' , [Validators.required , Validators.minLength(10) , Validators.maxLength(10)]),
    Address : new FormControl('',Validators.required),
    Password : new FormControl('',Validators.required)
    
  });
  submitted=false;
  get Role() {
    return this.SignUpform.get('Role');
  }
  get FirstName() {
    return this.SignUpform.get('FirstName');
  }
  get LastName() {
    return this.SignUpform.get('LastName');
  }
  get EmailId() {
    return this.SignUpform.get('EmailId');
  }
  get MobileNumber() {
    return this.SignUpform.get('MobileNumber');
  }
  get AddressInfo(){
    return this.SignUpform.get('AddressInfo'); 
  }
  get Password() {
    return this.SignUpform.get('Password');
  }


  constructor(private shared:ShareService, private nav:NavbarServiceService, private fs:FooterService,private router :Router) { }

  ngOnInit(): void {
    this.fs.hide();
  }

  onSubmit() {
 
      console.log("register")
    console.log(this.SignUpform.value)
     console.log("TRUE");
      this.shared.addUserDetails(this.SignUpform.value)
      .subscribe({
        next:(res)=>{
          console.log(res);
          alert("SignUp Successful");
          this.SignUpform.reset();
          this.router.navigate(['login']);
        },
        error:(err)=>{
          if(err.status == 200)
          {
            alert("SignUp Successful");
            this.SignUpform.reset();
            this.router.navigate(['login']);
          }
          else{
            console.log(err);
            alert("Something Wrong!!");
          }
          }
      })  
    }
  }
  

