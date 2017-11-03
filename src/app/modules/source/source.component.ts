import { Component, OnInit, AfterViewInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { SourceService, SortingService } from '../../services/_index';

@Component({
    selector: 'source',
    templateUrl: './source.component.html',

})
export class SourceComponent {
    private value: any = {};
    private _disabledV: string = '0';
    private disabled: boolean = false;
    private DeleteItemID: any;
    Data: any;
    AddModel: any = {
        sourceName: '',
        sourceCode: '',
        status: ''

    }
    EditModel: any;
    PreviousEdit: any;
    /* Data Table Column */
    OrderColumn: any;
    cols: any[] = [
        {
            name: "sourceName",
            title: "Source Name",
            sorted: false,
            sortAs: "",
            sortable: true,
            cssClass: "fw-normal",
            direction: 1
        },
        {
            name: "sourceCode",
            title: "Source Code",
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
    constructor(private _router: Router, private _service: SourceService, private _sorting: SortingService) {
    }
    ngOnInit() {
       // ValidateMe("#headingForm");
        this.Refresh();
    }

    Refresh() {
        this._service.GetAll().subscribe(m => {

            this.Data = m.data;
        });
    }
    ngAfterViewInit() { }
    onBack() {
        this._router.navigate(['/source/sourcelist']);
    }
   
    onEdit(edit) {
        if (this.PreviousEdit != undefined)
            this.PreviousEdit.Edit = false;
        this.PreviousEdit = edit;
        edit.Edit = true;
        this.EditModel = Object.assign({}, edit);
    }
    Update(edit) {


     //   if (ValidationCheck("#headingForm")) {
         if(0==0){
            this._service.Update(this.EditModel).subscribe(m => {

                if (m.status == 1) {
                    this.Title = "Save Confirmation"
                    this.Msg = "Heading updated successfully...";
                    // this.Refresh();
                    edit.name=this.EditModel.name;
                    edit.title = this.EditModel.title;
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
        this.Title = "Delete Confirmation"
        this.Msg = "Are you sure to delete this record ?";
        this.DeleteItemID = ID;
      //  CloseModal("#commonModal");
    }


    public btnOK(ID) {
        this._service.Delete(this.DeleteItemID._id).subscribe(m => {
            if (m.status == 1) {
                this.Data.splice(this.Data.indexOf(this.DeleteItemID), 1);
            //    CloseModal("#commonModal");
            }
            else {

            }
        })


    }
    Save() {
        console.log(this.AddModel);
      //  if (ValidationCheck("#headingForm")) {
            if(0==0){
            this._service.Add(this.AddModel).subscribe(m => {
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
