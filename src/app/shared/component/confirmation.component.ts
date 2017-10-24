import { Component, OnInit, AfterViewInit, Output, EventEmitter, Input } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { CloseModal } from '../../app.helpers';

@Component({
    selector: 'app-confirm',
    templateUrl: './confirmation.component.html',

})
export class ConfirmationComponent {
    @Output() btnOKClicked = new EventEmitter();
    @Input() Title: string="Alert";
    @Input() ID:string="commonModal";
    @Input() desc: string = "This is small example of todo list";
    constructor(private _router: Router) {
    }
    ngOnInit() {

    }
    ngAfterViewInit() { }



    public btnOK(event) {
        this.btnOKClicked.emit(event);
     
    }
}
