import { Component, OnInit, Output, EventEmitter,LOCALE_ID } from '@angular/core';
import { Router } from "@angular/router";
import { AuthService, StorageService } from "../../services/_index";

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',

})

export class LoginComponent implements OnInit {
myDate:any;
    @Output() LoginUser = new EventEmitter<boolean>();
    loginModel: any = { userName: '', password: '' }
    constructor(private service: AuthService, private cacheService: StorageService) {
   this.    myDate= (new Date());
   console.log("llll",LOCALE_ID);
    }


    LoginMe() {
        console.log("User Loged In", this.loginModel);
        if (this.loginModel.username == "test") {
            this.cacheService.add("plpuser", { FirstName: 'Demo',LastName: 'User',Email:'Test@gmail.com',token:'TestToken' });
            this.LoginUser.emit(true);
        }
        else {
            this.service.ValidateUser(this.loginModel).subscribe(m => {
                console.log("Data from Server", m);
                if (m.status == 1) {
                    this.cacheService.add("plpuser", m.data);
                    this.LoginUser.emit(true);
                }
            });
        }
   // this.LoginUser.emit(true);

    }


    ngOnInit() {

    }



}
