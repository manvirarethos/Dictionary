import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

// More 3rd Party Modules / Components
import { Ng2PaginationModule } from 'ng2-pagination';
import { SelectModule } from 'ng2-select';
// Shard Module
import {SharedModule} from '../../shared/shared.module'

import { LanguageComponent } from './language.component';

import { AuthService, StorageService,SortingService,LanguageService } from '../../services/_index';

@NgModule({
    declarations: [
       LanguageComponent
    ],
    imports: [
        CommonModule,
        SharedModule,
        Ng2PaginationModule,SelectModule,
        FormsModule,
               RouterModule.forChild([
            {
                path: 'language',
                component: LanguageComponent,
            }
        ]

        )
    ],
    providers: [LanguageService]

})
export class LanguageModule { }
