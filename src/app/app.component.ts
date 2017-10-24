import { Component,ElementRef } from '@angular/core';
import { StorageService } from './services/storage.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  LogedIn: boolean = false;
  CurrentUser: any;
  $el: any;
 
  constructor(el: ElementRef,private service:StorageService) {
    this.$el=el;
  }
  LogOut(){
    this.LogedIn=false;
    this.service.remove('plpuser');
  }

  ngOnInit() {
    var data=  this.service.get('plpuser');
    if(data!=undefined)
     {
       console.log("Current User",data);
       this.LogedIn=true;
       this.CurrentUser=  this.service.get('plpuser')['user'];
     
     }
   }
 
   AfterLogIn(data) {
     this.LogedIn = true;
     this.CurrentUser=  this.service.get('plpuser')['user'];
     
   }
}
