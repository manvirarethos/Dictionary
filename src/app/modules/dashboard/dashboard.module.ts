import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';


import { DashboardComponent } from './dashboard.component';


import { AuthService, StorageService } from '../../services/_index';

@NgModule({
    declarations: [
        DashboardComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        HttpModule,

        RouterModule.forChild([
            {
                path: '',
                component: DashboardComponent,
            }, {
                path: 'dashboard',
                component: DashboardComponent,
            }
        ]

        )
    ],
    providers: [AuthService, StorageService]

})
export class DashboardModule { }
