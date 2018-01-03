import { Component, OnInit, AfterViewInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Processing, CloseModal, Notify } from '../../../app.helpers';
import { DictonaryService, SortingService } from '../../../services/_index';
@Component({
  selector: 'dictonarylist',
  templateUrl: './dictonary.list.component.html',

})
export class DictonaryListComponent {
  private value: any = {};
  private _disabledV: string = '0';
  private disabled: boolean = false;
  private DeleteItemID: any;
  Data: any;

  /* Data Table Column */
  OrderColumn: any;
  cols: any[] = [
    {
      name: "Name",
      title: "Word",
      sorted: false,
      sortAs: "",
      sortable: true,
      cssClass: "fw-normal",
      direction: 1
    },
    {
      name: "Desc",
      title: "Desc",
      sorted: false,
      sortAs: "",
      sortable: true,
      cssClass: "fw-normal",
      direction: -1
    },
    {
      name: "Source Name",
      title: "SourceName",
      sorted: false,
      sortAs: "",
      sortable: true,
      cssClass: "fw-normal",
      direction: -1
    },
    {
      name: "Language Name",
      title: "LanguageName",
      sorted: false,
      sortAs: "",
      sortable: true,
      cssClass: "fw-normal",
      direction: -1
    },
    // {
    //   name: "enabled",
    //   title: "Status",
    //   sorted: false,
    //   sortAs: "",
    //   sortable: true,
    //   cssClass: "fw-normal",
    //   direction: -1
    // },
    {
      name: "Name",
      title: "Action",
      sorted: false,
      sortAs: "",
      sortable: false,
      cssClass: "fw-normal width-100",
      direction: -1
    }
  ];
  constructor(private _router: Router, private _service: DictonaryService, private _sorting: SortingService, ) {
  }
  ngOnInit() {
    this._service.GetAll().subscribe(m => {
      console.log("DDDD", m);
      this.Data = m.data;
    });
  }
  ngAfterViewInit() { }

  onAdd() {
    this._router.navigate(['dictonary/add']);
  }
  onEdit(edit) {
    this._router.navigate(['dictonary/edit', edit.id]);
  }
  public onDelete(ID) {
    this.DeleteItemID = ID;
    CloseModal("#commonModal");
  }
  public SaveLanguage(add) {

  }


  public btnOK(ID) {
    this._service.Delete(this.DeleteItemID._id).subscribe(m => {
      if (m.status == 1) {
        this.Data.splice(this.Data.indexOf(this.DeleteItemID), 1);
        CloseModal("#commonModal");
      }
      else {

      }
    })


  }

  sortColum(col) {
    this._sorting.sort(col, this.Data);
  }

}
