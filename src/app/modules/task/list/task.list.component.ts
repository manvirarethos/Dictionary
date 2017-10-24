import { Component, OnInit, AfterViewInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
//import { Processing, CloseModal, Notify } from '../../../app.helpers';
import { TaskService,SortingService } from '../../../services/_index'
@Component({
  selector: 'companyuserList',
  templateUrl: './task.list.componet.html',

})
export class TaskListComponent {
  private value: any = {};
  private _disabledV: string = '0';
  private disabled: boolean = false;
  private DeleteItemID: any;
  Data: any;

  /* Data Table Column */
   OrderColumn: any;
  cols: any[] = [
    
    
    {
      name: "name",
      title: "Task Name",
      sorted: false,
      sortAs: "",
      sortable: true,
      cssClass: "fw-normal",
      direction: 1
    },
    {
      name: "url",
      title: "Url",
      sorted: false,
      sortAs: "",
      sortable: true,
      cssClass: "fw-normal",
      direction: -1
    },
    {
      name: "sortOrder",
      title: "Sort Order",
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
      cssClass: "fw-normal width-100",
      direction: -1
    }
  ];

  constructor(private _router: Router, private _service: TaskService,private  _sorting:SortingService) {
  }
  ngOnInit() {
    this._service.GetAll().subscribe(m => {

      this.Data = m.data;
    });
  }
  ngAfterViewInit() { }

  onAdd() {
    this._router.navigate(['task/add']);
  }
  onEdit(edit) {
    this._router.navigate(['task/edit',edit.id]);
  }
  public onDelete(ID) {
    this.DeleteItemID = ID;
   // CloseModal("#commonModal");
  }
  public selected(value: any): void {
    console.log('Selected value is: ', value);
  }

  public removed(value: any): void {
    console.log('Removed value is: ', value);
  }

  public typed(value: any): void {
    console.log('New search input: ', value);
  }

  public refreshValue(value: any): void {
    this.value = value;
  }


  public btnOK(ID) {
    this._service.Delete(this.DeleteItemID.id).subscribe(m => {
      if (m.status == 1) {
        this.Data.splice(this.Data.indexOf(this.DeleteItemID), 1);
      //  CloseModal("#commonModal");
      }
      else {

      }
    })


  }

   sortColum(col){
    this._sorting.sort(col,this.Data);
   }
  
}
