import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';

// More 3rd Party Modules / Components
import { Ng2PaginationModule } from 'ng2-pagination';
import { SelectModule } from 'ng2-select';

// Shard Module
import { SharedModule } from '../../shared/shared.module';

// Services for the Module
import { DictonaryService, HttpClient, SortingService,MenuService } from '../../services/_index';

// Task Components for List, Add, Edit and Delete Oprations
// import { RoleAddComponent } from './add/role.add.component';
// import { RoleEditComponent } from './edit/role.edit.component';
import { DictonaryListComponent } from './list/dictonary.list.component';
import { DictonaryAddComponent } from './add/dictonary.Add.component';


@NgModule({
    declarations: [
        DictonaryListComponent,
        DictonaryAddComponent,
        // RoleEditComponent


    ],
    imports: [

        CommonModule,
        FormsModule,
        SelectModule,
        Ng2PaginationModule,
        SharedModule,
        RouterModule.forChild([
             { path: 'dictonary/list', component: DictonaryListComponent },
             { path: 'dictonary/add', component: DictonaryAddComponent },
            // { path: 'role/edit/:id', component: RoleEditComponent }
          
        ])
    ],
    providers: [DictonaryService, HttpClient, SortingService,MenuService]

})
export class DictonaryModule {

}