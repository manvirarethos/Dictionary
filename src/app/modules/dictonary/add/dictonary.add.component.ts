

import { Component, OnInit, AfterViewInit, Inject, LOCALE_ID } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs/Subscription';
import { CloseModal, ValidateMe, ValidationCheck } from '../../../app.helpers';
import { DictonaryService, LanguageService, SourceService } from '../../../services/_index';

@Component({
  selector: 'app-adddictonary',
  templateUrl: './dictonary.add.component.html',

})
export class DictonaryAddComponent {
  private sourceList = [];
  private langList = [];
  private value: any = {};
  private _disabledV: string = '0';
  private disabled: boolean = false;
  private DeleteItemID: any;
  private lngLang: string;
  private lngSource: string;
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






  constructor(private _router: Router, private _service: DictonaryService, private sourceService: SourceService, private langService: LanguageService) {
    console.log("Locate ID", LOCALE_ID);
  }
  ngOnInit() {

    ValidateMe("#formValidation");
    // this.GetHeading();
    this.sourceService.GetActive().subscribe(m => {
      console.log("Source Control", m);
      this.sourceList = m.data;
    });
    this.langService.GetActive().subscribe(m => {
      console.log("long Control", m);
      this.langList = m.data;
    })



  }

  ngAfterViewInit() { }

  onBack() {
    this._router.navigate(['/dictonary/list']);
  }


  public btnOK(ID) {

    CloseModal("#commonModal");


  }

  OnLanguage() {
    var Data = this.langList.filter(m => m.id == this.DictonaryLanguage.LanguageID)[0];
    console.log("On Change", Data);
    this.lngLang = Data.languageCode;
  }

  OnSource() {
    var Data = this.langList.filter(m => m.id == this.DictonarySource.LanguageID)[0];
    console.log("On Change", Data);
    this.lngSource = Data.languageCode;
  }
  AddLanguage() {
    console.log(this.AddModel);
    this.DictonaryLanguage.LanguageName = this.langList.filter(m => m.id == this.DictonaryLanguage.LanguageID)[0].languageName;
    this.DictonaryLanguage.LanguageCode = this.langList.filter(m => m.id == this.DictonaryLanguage.LanguageID)[0].languageCode;
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
    task.LanguageID = this.EditDictonaryLanguage.LanguageID;
    task.LanguageName = this.langList.filter(m => m.id == this.EditDictonaryLanguage.LanguageID)[0].languageName;
    task.LanguageCode = this.langList.filter(m => m.id == this.EditDictonaryLanguage.LanguageID)[0].languageCode;
    task.Word = this.EditDictonaryLanguage.Word;

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
    this.DictonarySource.SourceName = this.sourceList.filter(m => m.id == this.DictonarySource.SourceID)[0].sourceName;

    this.DictonarySource.LanguageCode = this.langList.filter(m => m.id == this.DictonarySource.LanguageID)[0].languageCode;
    this.DictonarySource.LanguageName = this.langList.filter(m => m.id == this.DictonarySource.LanguageID)[0].languageName;

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
    task.SourceName = this.sourceList.filter(m => m.id == this.EditDictonarySource.SourceID)[0].sourceName;
    task.LanguageCode = this.langList.filter(m => m.id == this.EditDictonarySource.LanguageID)[0].languageCode;
    task.LanguageName = this.langList.filter(m => m.id == this.EditDictonarySource.LanguageID)[0].languageName;
    task.LanguageID = this.EditDictonarySource.LanguageID;
   
    task.SourceID = this.EditDictonarySource.SourceID;
    task.WordMeaning = this.EditDictonarySource.WordMeaning;
    task.Translation = this.EditDictonarySource.Translation;
  }

  onDeleteSource(task) {
    console.log(this.AddModel.DictonarySource.indexOf(task));
    this.AddModel.DictonarySource.splice(this.AddModel.DictonarySource.indexOf(task), 1);
  }

  Save() {
    // if (ValidationCheck("#formValidation")) {
    console.log("Added Log", this.AddModel);
    this.AddModel.DictonarySourceModel = this.AddModel.DictonarySource;
    this.AddModel.DictonaryLanguageModel = this.AddModel.DictonaryLanguage;

    this._service.Add(this.AddModel).subscribe(m => {
      console.log("Data Save", m);
      if (m.status == 1) {
        this._router.navigate(['/dictonary/list']);
      } else {
        this.Msg = "Error in saving record";
        CloseModal("#commonModal");
      }
    })
    //}
  }

}
