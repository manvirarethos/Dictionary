
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Router } from "@angular/router";
import { AuthService, StorageService } from "../../services/_index";

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',

})

export class HeaderComponent  {
@Output() LogOutEmit = new EventEmitter();
   
    
    constructor(private service: AuthService, private cacheService: StorageService,private router:Router) {
        
            }

            LogOut()
            {
               
                this.cacheService.remove('plpuser');
                this.LogOutEmit.emit();
            }
}
