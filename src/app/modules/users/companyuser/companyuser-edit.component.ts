import { Component, OnInit, AfterViewInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { CloseModal, ValidateMe, ValidationCheck } from '../../../app.helpers';
import { UserService, MenuService } from '../../../services/_index';
@Component({
  selector: 'companyuserEdit',
  templateUrl: './companyuser-edit.component.html',

})
export class CompanyUserEditComponent {

  ApplicationUserModel: any = {};
  Headings: any;
  Msg: string;
  private value: any = {};

  constructor(private _router: Router, private _route: ActivatedRoute, private _service: UserService, private _menuSerive: MenuService) {
  }
  public ngOnInit() {
    ValidateMe("#userForm");
    this.GetHeading();
    this._route.params.subscribe(
      params => {
        this._service.GetOne(params["id"]).subscribe(m => {
          console.log("Data dsd", m);
          if (m.status == 1) {
            this.ApplicationUserModel = m.data;
          }
        })
      });
  }
  onBack() {
    this._router.navigate(['/users']);
  }


  public btnOK(ID) {
    CloseModal("#commonModal");
  }

  Save() {
    if (ValidationCheck("#userForm")) {
      alert(JSON.stringify(this.ApplicationUserModel));
      this._service.Add(this.ApplicationUserModel).subscribe(m => {
        console.log("Save Called", m);
        if (m.requestStatus == 1) {
          this.Msg = "User added successfully...";
          CloseModal("#commonModal");
        } else {
          this.Msg = "Error in saving record";
          CloseModal("#commonModal");
        }
      })
    }
  }

  GetHeading() {
    this._menuSerive.GetDBMenu().subscribe(m => {
      console.log("Menu Data", m);
      this.Headings = m.data;
    });
  }
}
