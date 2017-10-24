
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Router } from "@angular/router";
import { AuthService, StorageService } from "../../services/_index";

@Component({
    selector: 'app-dasboard',
    templateUrl: './dashboard.component.html',

})

export class DashboardComponent  {

   
    
    constructor(private service: AuthService, private cacheService: StorageService) {
        
            }

            LogOut()
            {
               
                this.cacheService.remove('plpuser');
            }
}
