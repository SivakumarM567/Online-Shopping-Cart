import { Component, OnInit } from '@angular/core';
import { NavbarServiceService } from 'src/app/Services/navbar-service.service';
import{ShareService} from 'src/app/Services/share.service';
import { feedback } from 'src/app/Models/feedback.model';
import { FormControl, FormGroup, Validators } from '@angular/forms';
@Component({
  selector: 'app-feedback',
  templateUrl: './feedback.component.html',
  styleUrls: ['./feedback.component.css']
})
export class FeedbackComponent implements OnInit {
  Feedbackform = new FormGroup({
    
    Username : new FormControl('', Validators.required),
    Feedback:new FormControl('', Validators.required)
    
  });
  submitted=false;
  public feedbacks:feedback[];
  get username() {
    return this.Feedbackform.get('Username');
  }
  get feedback() {
    return this.Feedbackform.get('Feedback');
  }
  
  constructor(public nav: NavbarServiceService,private shared:ShareService) { }

  ngOnInit(): void {
    this.nav.show()
    this.nav.isLogin();
    this.nav.showCart();
    this.nav.doSomethingElseUseful()
    
  }

  onSubmit() {
    this.submitted = true;
    console.log(this.Feedbackform.value)
    if (this.Feedbackform.invalid) {
      console.log("False");
      return;
    
    }
    
    this.shared.addFeedDetails(this.Feedbackform.value)
    .subscribe({
      next:(res)=>{
        console.log(res)
        alert("Successful");
      },
      error:(err)=>{
        if(err.status==200)
        {
          alert("Successful");
        }
        else{
          console.log(err)
          alert("Failed");
        }
      
      }
    });
  
  //location.reload();
}


}