
import { Component, OnInit, AfterViewInit, Inject, LOCALE_ID } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs/Subscription';
import { CloseModal, ValidateMe, ValidationCheck } from '../../../app.helpers';
import { DictonaryService, LanguageService, SourceService } from '../../../services/_index';

@Component({
  selector: 'app-editdictonary',
  templateUrl: './dictonary.edit.component.html',

})
export class DictonaryEditComponent {
  private lang;
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
    word: '',
    translation: '',
    dictonaryLanguage: [],
    dictonarySource: [],
  };
  dictonaryLanguage: any = {
    languageName: '',
    discreption: ''
  };
  editDictonaryLanguage: any = {
    languageName: '',
    discreption: ''
  };
  dictonarySource: any = {
    sourceName: '',
    wordMeaning: '',
    translation: ''
  };
  editDictonarySource: any = {
    sourceName: '',
    wordMeaning: '',
    translation: ''
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






  constructor(private _router: Router, private _route: ActivatedRoute, private _service: DictonaryService, private sourceService: SourceService, private langService: LanguageService) {
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
    this._route.params.subscribe(
        params => {
  
          this._service.GetOne(params["id"]).subscribe(m => {
            console.log("Data", m);
            if (m.status == 1) {
              this.AddModel = m.data;

              console.log(this.AddModel);
              ValidateMe("#formValidation");
            }
          })
        });

  }

  ngAfterViewInit() { }

  onBack() {
    this._router.navigate(['/dictonary/list']);
  }


  public btnOK(ID) {

    CloseModal("#commonModal");


  }

  OnLanguage() {
    var Data = this.langList.filter(m => m.id == this.dictonaryLanguage.LanguageID)[0];
    console.log("On Change", Data);
    this.lngLang = Data.languageCode;
  }

  OnSource() {
    var Data = this.langList.filter(m => m.id == this.dictonarySource.LanguageID)[0];
    console.log("On Change", Data);
    this.lngSource = Data.languageCode;
  }
  AddLanguage() {
    console.log(this.AddModel);
    this.dictonaryLanguage.languageName = this.langList.filter(m => m.id == this.dictonaryLanguage.languageID)[0].languageName;
    this.dictonaryLanguage.languageCode = this.langList.filter(m => m.id == this.dictonaryLanguage.languageID)[0].languageCode;
    //alert(JSON.stringify(this.AddModel));
    this.AddModel.dictonaryLanguage.push(this.dictonaryLanguage);
    console.log(this.dictonaryLanguage);
    this.dictonaryLanguage = { languageName: '', discreption: '' };
  }
  onEdit(task) {
    if (this.PreviousEdit != undefined)
      this.PreviousEdit.Edit = false;
    task.Edit = true;
    this.PreviousEdit = task;
    this.editDictonaryLanguage = Object.assign({}, task);
  }
  Update(task) {
    task.Edit = false;
    task.LanguageID = this.editDictonaryLanguage.languageID;
    task.LanguageName = this.langList.filter(m => m.id == this.editDictonaryLanguage.languageID)[0].languageName;
    task.LanguageCode = this.langList.filter(m => m.id == this.editDictonaryLanguage.languageID)[0].languageCode;
    task.Word = this.editDictonaryLanguage.Word;

  }
  Cancel(task) {
    task.Edit = false;
  }
  onDelete(task) {
    console.log(this.AddModel.dictonaryLanguage.indexOf(task));
    this.AddModel.dictonaryLanguage.splice(this.AddModel.dictonaryLanguage.indexOf(task), 1);
  }

  AddSource() {
    console.log(this.AddModel);
    this.dictonarySource.sourceName = this.sourceList.filter(m => m.id == this.dictonarySource.sourceID)[0].sourceName;

    this.dictonarySource.languageCode = this.langList.filter(m => m.id == this.dictonarySource.languageID)[0].languageCode;
    this.dictonarySource.languageName = this.langList.filter(m => m.id == this.dictonarySource.languageID)[0].languageName;

    //alert(JSON.stringify(this.AddModel));
    this.AddModel.dictonarySource.push(this.dictonarySource);
    console.log(this.dictonarySource);
    this.dictonarySource = { sourceName: '', wordMeaning: '', translation: '' };
  }
  onEditSource(task) {
    if (this.PreviousEdit != undefined)
      this.PreviousEdit.Edit = false;
    task.Edit = true;
    this.PreviousEdit = task;
    this.editDictonarySource = Object.assign({}, task);
  }
  UpdateSource(task) {
    task.Edit = false;
    task.sourceName = this.sourceList.filter(m => m.id == this.editDictonarySource.sourceID)[0].sourceName;
    task.languageCode = this.langList.filter(m => m.id == this.editDictonarySource.languageID)[0].languageCode;
    task.languageName = this.langList.filter(m => m.id == this.editDictonarySource.languageID)[0].languageName;
    task.languageID = this.editDictonarySource.languageID;
   
    task.sourceID = this.editDictonarySource.sourceID;
    task.wordMeaning = this.editDictonarySource.wordMeaning;
    task.translation = this.editDictonarySource.translation;
  }

  onDeleteSource(task) {
    console.log(this.AddModel.dictonarySource.indexOf(task));
    this.AddModel.dictonarySource.splice(this.AddModel.dictonarySource.indexOf(task), 1);
  }

  Save() {
    // if (ValidationCheck("#formValidation")) {
    console.log("Update Log", this.AddModel);
    this.AddModel.dictonarySourceModel = this.AddModel.dictonarySource;
    this.AddModel.dictonaryLanguageModel = this.AddModel.dictonaryLanguage;

    this._service.Update(this.AddModel).subscribe(m => {
      console.log("Data Save", m);
      if (m.status == 1) {
        this.Msg = "Task updated successfully...";
        CloseModal("#commonModal");
      } else {
        this.Msg = "Error in saving record";
        CloseModal("#commonModal");
      }
    })
    //}
  }

}
