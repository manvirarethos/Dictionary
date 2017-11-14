import { Component, OnInit, AfterViewInit } from '@angular/core';
import { Router } from '@angular/router';
import { CloseModal, ValidateMe, ValidationCheck } from '../../../app.helpers';
import { RoleService, MenuService } from '../../../services/_index';
@Component({
    selector: 'app-adddictonary',
    templateUrl: './dictonary.add.component.html',

})
export class DictonaryAddComponent {
    private value: any = {};
    private _disabledV: string = '0';
    private disabled: boolean = false;
    private DeleteItemID: any;
    Data: any;
    AddModel: any = {
        language: '',
        word: ''
       
    }
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
    constructor(private _router: Router, private _service: RoleService, private _menuSerive: MenuService) {
    }
    ngOnInit() {
        ValidateMe("#formValidation");
       // this.GetHeading();

    }
    ngAfterViewInit() { }

    onBack() {
        this._router.navigate(['/dictonary/list']);
    }


    public btnOK(ID) {

        CloseModal("#commonModal");


    }

    // CheckTask(task, event) {
    //     console.log("Event Data", event);
    //     if (event == true) {
    //         var roleTask = {menuTaskID:task.id}
    //         this.taskModel.tasks.push(roleTask)
    //     }
    //     else {
    //         var roletask =this.taskModel.tasks.filter(m=>m.id==task.id)[0];
    //         this.taskModel.tasks.splice(this.taskModel.tasks.indexOf(roletask), 1);

    //     }
    //     console.log("Selected Tasks", this.taskModel.tasks);
    // }

    //  GetHeading() {
    //      this._menuSerive.GetDBMenu().subscribe(m => {
    //          console.log("Menu Data", m);
    //          this.Headings = m.data;
    //      });
    //  }

    // Save() {
    //     if (ValidationCheck("#formValidation")) {
    //       console.log("Role Data",this.taskModel);
        
    //         this._service.Add(this.taskModel).subscribe(m => {

    //             if (m.status == 1) {
    //                 this.Msg = "Role added successfully...";
    //                 CloseModal("#commonModal");
    //             } else {
    //                 this.Msg = "Error in saving record";
    //                 CloseModal("#commonModal");
    //             }
    //         })
    //     }
    // }

}
