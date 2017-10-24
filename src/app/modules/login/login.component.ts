import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Router } from "@angular/router";
import { AuthService, StorageService } from "../../services/_index";

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',

})

export class LoginComponent implements OnInit {

    @Output() LoginUser = new EventEmitter<boolean>();
    loginModel: any = { userName: '', password: '' }
    constructor(private service: AuthService, private cacheService: StorageService) {

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
