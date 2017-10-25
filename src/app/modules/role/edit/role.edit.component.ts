import { Component, OnInit, AfterViewInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { CloseModal, ValidateMe, ValidationCheck } from '../../../app.helpers';
import { RoleService, MenuService } from '../../../services/_index';
@Component({
  selector: 'app-addedit',
  templateUrl: './role.edit.component.html',

})
export class RoleEditComponent {

  taskModel: any = { name: '', title: '', enabled: true, tasks: [] };
  Headings: any;
  Msg: string;
  private value: any = {};

  constructor(private _router: Router, private _route: ActivatedRoute, private _service: RoleService, private _menuSerive: MenuService) {
  }
  ngOnInit() {
    ValidateMe("#formValidation");
    this.GetHeading();
    this._route.params.subscribe(
      params => {

        this.GetRoleTask(params["id"]);
      });



  }
  ngAfterViewInit() { }


  GetRoleTask(ID) {
    this._service.GetOne(ID).subscribe(m => {
      console.log("Role DDDDD", m);
      if (m.status == 1) {
        this.taskModel = m.data;

      }

    });
  }
  onBack() {
    this._router.navigate(['/role/list']);
  }


  public btnOK(ID) {

    CloseModal("#commonModal");


  }

  CheckTask(task, event) {
    console.log("Event Data", event,task);
    if (event == true) {
      var roleTask = { menuTaskID: task.id }
      this.taskModel.tasks.push(roleTask)
    }
    else {
      var roletask = this.taskModel.tasks.filter(m => m.menuTaskID == task.id)[0];
      this.taskModel.tasks.splice(this.taskModel.tasks.indexOf(roletask), 1);

    }
    console.log("Selected tasks", this.taskModel.tasks);
  }
  IsCheck(task) {

    if (this.taskModel.tasks.filter(m => m.menuTaskID == task.id).length == 0) {
      return "";
    }
    else {
      return "checked";
    }
  }
  GetHeading() {
    this._menuSerive.GetDBMenu().subscribe(m => {

      this.Headings = m.data;
    });
  }

  Save() {
    if (ValidationCheck("#formValidation")) {
      this._service.Update(this.taskModel).subscribe(m => {

        if (m.status == 1) {
          this.Msg = "Role updated successfully...";
          CloseModal("#commonModal");
        } else {
          this.Msg = "Error in saving record";
          CloseModal("#commonModal");
        }
      })
    }
  }

}
