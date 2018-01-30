import { Component, OnInit, AfterViewInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { CloseModal, ValidateMe, ValidationCheck } from '../../app.helpers';
import { LanguageService, SortingService } from '../../services/_index';

@Component({
    selector: 'language',
    templateUrl: './language.component.html',

})
export class LanguageComponent {
    private value: any = {};
    private _disabledV: string = '0';
    private disabled: boolean = false;
    private DeleteItemID: any;
    Data: any;
    AddModel: any = {
        languageName: '',
        languageCode: '',
        status: ''

    }
    EditModel: any;
    PreviousEdit: any;
    /* Data Table Column */
    OrderColumn: any;
    cols: any[] = [
        {
            name: "languageName",
            title: "Language Name",
            sorted: false,
            sortAs: "",
            sortable: true,
            cssClass: "fw-normal",
            direction: 1
        },
        {
            name: "languageCode",
            title: "Language Code",
            sorted: false,
            sortAs: "",
            sortable: true,
            cssClass: "fw-normal",
            direction: -1
        },
       {
            name: "status",
            title: "Status",
            sorted: false,
            sortAs: "",
            sortable: true,
            cssClass: "fw-normal",
            direction: -1
        },
        {
            name: "Name",
            title: "Action",
            sorted: false,
            sortAs: "",
            sortable: false,
            cssClass: "fw-normal width-150",
            direction: -1
        }
    ];
    Msg: String;
    Title: String;
    constructor(private _router: Router, private _service: LanguageService, private _sorting: SortingService) {
    }
    ngOnInit() {
       // ValidateMe("#headingForm");
        this.Refresh();
    }

    Refresh() {
        this._service.GetAll().subscribe(m => {

            this.Data = m.data;
            console.log(this.Data);
        });
    }
    ngAfterViewInit() { }
    onBack() {
        this._router.navigate(['/language/languagelist']);
    }
   
    onEdit(edit) {
        if (this.PreviousEdit != undefined)
            this.PreviousEdit.Edit = false;
        this.PreviousEdit = edit;
        edit.Edit = true;
        this.EditModel = Object.assign({}, edit);
        console.log(this.EditModel);
    }
    Update(edit) {


     //   if (ValidationCheck("#headingForm")) {
         if(0==0){
            this._service.Update(this.EditModel).subscribe(m => {

                if (m.status == 1) {
                    this.Title = "Save Confirmation"
                    this.Msg = "Heading updated successfully...";
                    // this.Refresh();
                    edit.languageName=this.EditModel.languageName;
                    edit.languageCode = this.EditModel.languageCode;
                    edit.status = this.EditModel.status;
                    edit.Edit = false;
                    //  CloseModal("#commonModal");
                } else {
                    this.Title = "Save Confirmation"
                    this.Msg = "Error in saving record";
                    // CloseModal("#commonModal");
                }
            })

        }

    }
    Cancel(edit) {
        edit.Edit = false;
        //  this.EditModel=Object.assign({},edit);
    }
    public onDelete(ID) {
        this.DeleteItemID = ID;
        console.log(ID);
        CloseModal("#commonModal");
    }


    public btnOK(ID) {
        this._service.Delete(this.DeleteItemID.id).subscribe(m => {
            if (m.status == 1) {
                this.Data.splice(this.Data.indexOf(this.DeleteItemID), 1);
               CloseModal("#commonModal");
            }
            else {

            }
        })


    }
    Save() {
      //  if (ValidationCheck("#headingForm")) {
            if(0==0){
            this._service.Add(this.AddModel).subscribe(m => {
                 console.log(this.AddModel);
                // alert(JSON.stringify(this.AddModel));
                if (m.status == 1) {
                    this.Title = "Save Confirmation"
                    this.Msg = "Heading added successfully...";
                    this.Refresh();
                    this.AddModel = { languageName: '', languageCode: '', status: '' }
                    //  CloseModal("#commonModal");
                } else {
                    this.Title = "Save Confirmation"
                    this.Msg = "Error in saving record";
                    // CloseModal("#commonModal");
                }
            })
        }
    }
    sortColum(col) {
        this._sorting.sort(col, this.Data);
    }

}
