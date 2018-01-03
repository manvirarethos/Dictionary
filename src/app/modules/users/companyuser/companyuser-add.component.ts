// import { Component, OnInit, AfterViewInit } from '@angular/core';
// import { Router } from '@angular/router';
// import { CloseModal, ValidateMe, ValidationCheck } from '../../../app.helpers';
// import { UserService, RoleService } from '../../../services/_index';

// @Component({
//   selector: 'companyuserAdd',
//   templateUrl: './companyuser-add.component.html',

// })
// export class CompanyUserAddComponent {
//   ApplicationUserModel: any = {
//     firstName: '',
//     lastName: '',
//     userType: '',
//     emailAddress: '',
//     password: '',
//     //confirmPassword: '',
//     status: ''
//    // roles: []
//   };
//   Msg: string;
//   private value: any = {};
//   private Roles: any[];
//   constructor(private _router: Router, private _service: UserService, private _roleService: RoleService) {
//   }
//   ngOnInit() {
//     ValidateMe("#userForm");
//   }

//   GetUserTypeRoles() {
//     this._roleService.GetColumnWise({ condition: { "Status": "Active", "RoleForUserType": this.ApplicationUserModel.UserType }, columns: "_id Name" }).subscribe(m => {
//       if (m.requestStatus == 1) {
//         this.Roles = m.lstData;
//       }
//     });
//   }

//   OnUserTypeChange() {
//     this.GetUserTypeRoles();
//   }
//   ngAfterViewInit() { }

//   onBack() {
//     this._router.navigate(['/users']);
//   }
//   Save() {
//     if (ValidationCheck("#userForm")) {
//       alert(JSON.stringify(this.ApplicationUserModel));
//       this._service.Add(this.ApplicationUserModel).subscribe(m => {
//         console.log("Save Called", m);
//         if (m.requestStatus == 1) {
//           this.Msg = "User added successfully...";
//           CloseModal("#commonModal");
//         } else {
//           this.Msg = "Error in saving record";
//           CloseModal("#commonModal");
//         }
//       })
//     }
//   }
//   CheckTask(task, event) {
//     console.log("Event Data", event);
//     if (event == true) {
//       this.ApplicationUserModel.Roles.push(task._id)
//     }
//     else {
//       this.ApplicationUserModel.Roles.splice(this.ApplicationUserModel.Roles.indexOf(task._id), 1);

//     }
//     console.log("Selected Tasks", this.ApplicationUserModel.Roles);
//   }

//   public selected(value: any): void {
//     console.log('Selected value is: ', value);
//   }

//   public removed(value: any): void {
//     console.log('Removed value is: ', value);
//   }

//   public typed(value: any): void {
//     console.log('New search input: ', value);
//   }

//   public refreshValue(value: any): void {
//     this.value = value;
//   }

//   public btnOK(ID) {

//     CloseModal("#commonModal");


//   }
// }



import { Component, OnInit, AfterViewInit } from '@angular/core';
import { Router } from '@angular/router';
import { CloseModal, ValidateMe, ValidationCheck } from '../../../app.helpers';
import { UserService, MenuService } from '../../../services/_index';
@Component({
  selector: 'app-adduser',
  templateUrl: './Companyuser-add.component.html',

})
export class CompanyUserAddComponent {

  ApplicationUserModel: any = {
    firstName: '',
    lastName: '',
    userType: '',
    emailAddress: '',
    password: '',
    userName: '',
    status: '',
    contactNumber: '',
 // roles: []
  };
  Headings: any;
  Msg: string;
  private value: any = {};

  constructor(private _router: Router, private _service: UserService, private _menuSerive: MenuService) {
  }
   public ngOnInit() {
    ValidateMe("#userForm");
    this.GetHeading();
      }
  onBack() {
    this._router.navigate(['/users']);
  }


  public btnOK(ID) {
    CloseModal("#commonModal");
 }

 public removed(value: any): void {
  console.log('Removed value is: ', value);
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
