

import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Router } from "@angular/router";
import { MenuService } from "../../services/_index";

@Component({
    selector: 'app-nav',
    templateUrl: './nav.component.html',
    providers:[MenuService]
})

export class NavComponent {

    Menu: any[];
    constructor(private srv: MenuService) {
        let self = this;
        this.srv.GetDBMenu().subscribe(m => {
            console.log("Menu Data",m.data);
            self.Menu =  m.data;
        });
    }


}
