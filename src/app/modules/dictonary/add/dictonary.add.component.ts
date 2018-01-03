

import { Component, OnInit, AfterViewInit } from '@angular/core';
import { Router } from '@angular/router';
import { CloseModal, ValidateMe, ValidationCheck } from '../../../app.helpers';
import { DictonaryService, LanguageService,SourceService } from '../../../services/_index';
@Component({
    selector: 'app-adddictonary',
    templateUrl: './dictonary.add.component.html',

})
export class DictonaryAddComponent {
    private 
    private value: any = {};
    private _disabledV: string = '0';
    private disabled: boolean = false;
    private DeleteItemID: any;
    Data: any;
    AddModel: any = {
        Word: '',
        Translation: '',
        DictonaryLanguage: [],
        DictonarySource: [],
    };
    DictonaryLanguage: any = {
        LanguageName: '',
        Discreption: ''
    };
    EditDictonaryLanguage: any = {
        LanguageName: '',
        Discreption: ''
    };
    DictonarySource: any = {
        SourceName: '',
        WordMeaning: '',
        Translation: ''
    };
    EditDictonarySource: any = {
        SourceName: '',
        WordMeaning: '',
        Translation: ''
    };
    EditModel: any;
    PreviousEdit: any;
    /* Data Table Column */
    OrderColumn: any;
    colsLang: any[] = [
        {
            name: "language",
            title: "Language",
            sorted: false,
            sortAs: "",
            sortable: true,
            cssClass: "fw-normal",
            direction: 1
        },
        {
            name: "word",
            title: "Word",
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
    colsSource: any[] = [
        {
            name: "source",
            title: "Source",
            sorted: false,
            sortAs: "",
            sortable: true,
            cssClass: "fw-normal",
            direction: 1
        },
        {
            name: "Source Desc",
            title: "Desc",
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
    constructor(private _router: Router, private _service: DictonaryService, private sourceService: SourceService,private langService:LanguageService) {
    }
    ngOnInit() {
        ValidateMe("#formValidation");
        // this.GetHeading();
     
        console.log("all languages" + this._service.GetAllLanguage());
    }
    ngAfterViewInit() { }

    onBack() {
        this._router.navigate(['/dictonary/list']);
    }


    public btnOK(ID) {

        CloseModal("#commonModal");


    }

    AddLanguage() {
        console.log(this.AddModel);
        //alert(JSON.stringify(this.AddModel));
        this.AddModel.DictonaryLanguage.push(this.DictonaryLanguage);
        console.log(this.DictonaryLanguage);
        this.DictonaryLanguage = { LanguageName: '', Discreption: '' };
    }
    onEdit(task) {
        if (this.PreviousEdit != undefined)
            this.PreviousEdit.Edit = false;
        task.Edit = true;
        this.PreviousEdit = task;
        this.EditDictonaryLanguage = Object.assign({}, task);
    }
    Update(task) {
        task.Edit = false;
        task.LanguageName = this.EditDictonaryLanguage.LanguageName;
        task.Discreption = this.EditDictonaryLanguage.Discreption;
    }
    Cancel(task) {
        task.Edit = false;
    }
    onDelete(task) {
        console.log(this.AddModel.DictonaryLanguage.indexOf(task));
        this.AddModel.DictonaryLanguage.splice(this.AddModel.DictonaryLanguage.indexOf(task), 1);
    }

    AddSource() {
        console.log(this.AddModel);
        //alert(JSON.stringify(this.AddModel));
        this.AddModel.DictonarySource.push(this.DictonarySource);
        console.log(this.DictonarySource);
        this.DictonarySource = { SourceName: '', WordMeaning: '', Translation: '' };
    }
    onEditSource(task) {
        if (this.PreviousEdit != undefined)
            this.PreviousEdit.Edit = false;
        task.Edit = true;
        this.PreviousEdit = task;
        this.EditDictonarySource = Object.assign({}, task);
    }
    UpdateSource(task) {
        task.Edit = false;
        task.SourceName = this.EditDictonarySource.SourceName;
        task.WordMeaning = this.EditDictonarySource.WordMeaning;
        task.Taranslation = this.EditDictonarySource.Translation;
    }

    onDeleteSource(task) {
        console.log(this.AddModel.DictonarySource.indexOf(task));
        this.AddModel.DictonarySource.splice(this.AddModel.DictonarySource.indexOf(task), 1);
    }

    Save() {
        // if (ValidationCheck("#formValidation")) {
        this._service.Add(this.AddModel).subscribe(m => {
            console.log(this.AddModel);
            if (m.status == 1) {
                this.Msg = "Task added successfully...";
                CloseModal("#commonModal");
            } else {
                this.Msg = "Error in saving record";
                CloseModal("#commonModal");
            }
        })
        //}
    }

}