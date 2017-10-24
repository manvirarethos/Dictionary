import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

// More 3rd Party Modules / Components
import { Ng2PaginationModule } from 'ng2-pagination';
import { SelectModule } from 'ng2-select';
// Shard Module
import {SharedModule} from '../../shared/shared.module'

import { TaskAddComponent } from './add/task.add.component';
import { TaskEditComponent } from './edit/task.edit.component';
import { TaskListComponent } from './list/task.list.component';
import { MenuListComponent } from './menu/menu.component';

import { AuthService, StorageService,MenuService,SortingService,TaskService } from '../../services/_index';

@NgModule({
    declarations: [
        TaskListComponent, TaskAddComponent, TaskEditComponent,MenuListComponent
    ],
    imports: [
        CommonModule,
        SharedModule,
        Ng2PaginationModule,SelectModule,
        FormsModule,
               RouterModule.forChild([
            {
                path: 'task',
                component: TaskListComponent,
            }, {
                path: 'task/list',
                component: TaskListComponent,
            }, {
                path: 'task/add',
                component: TaskAddComponent,
            }, {
                path: 'task/edit/:id',
                component: TaskEditComponent,
            }, {
                path: 'task/menu',
                component: MenuListComponent,
            }
        ]

        )
    ],
    providers: [AuthService, StorageService,MenuService,SortingService,TaskService]

})
export class TaskModule { }
