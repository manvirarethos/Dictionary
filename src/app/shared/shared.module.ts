import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { ConfirmationComponent } from './component/confirmation.component';

import { SearchPipe } from './pipes/search.pipe';
import { HighlightSearch } from './pipes/highlight.pipe';

@NgModule({
  declarations: [ ConfirmationComponent, SearchPipe, HighlightSearch

  ],
  imports: [
    CommonModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot([])

  ],
  providers: [],
  exports: [ConfirmationComponent,  SearchPipe, HighlightSearch]
})
export class SharedModule { }
