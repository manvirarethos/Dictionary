import { NgModule,LOCALE_ID } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
// import { AppRoutingModule } from './app.routing';


import { LoginComponent } from './modules/login/login.component';
import { FooterComponent } from './modules/footer/footer.component';
import { HeaderComponent } from './modules/header/header.component';
import { NavComponent } from './modules/navigation/nav.component';
import { DashboardModule } from './modules/dashboard/dashboard.module';

import { TaskModule } from './modules/task/task.module';
import { RoleModule } from './modules/role/role.module';
import { LanguageModule } from './modules/language/language.module';
import { SourceModule } from './modules/source/source.module';
import { DictonaryModule } from './modules/dictonary/dictonary.module';

import {CompanyUserModule} from './modules/users/companyuser/companyuser.module';
import { AuthService, StorageService, MenuService,LanguageService, SourceService, DictonaryService, HttpClient } from './services/_index';
import { AppConfig } from './app.config';




@NgModule({
  declarations: [
    AppComponent, LoginComponent, FooterComponent, HeaderComponent, NavComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    DashboardModule,
    TaskModule,
    RoleModule,
    CompanyUserModule,
    LanguageModule,
    SourceModule,
    DictonaryModule,
        RouterModule.forRoot([])
  ],
  providers: [AppConfig, AuthService, StorageService, MenuService,LanguageService,SourceService,DictonaryService, HttpClient],
  bootstrap: [AppComponent]
})
export class AppModule { }
