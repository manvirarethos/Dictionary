import { NgModule } from '@angular/core';
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
import { AuthService, StorageService, MenuService, HttpClient } from './services/_index';
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
    RouterModule.forRoot([])
  ],
  providers: [AppConfig, AuthService, StorageService, MenuService, HttpClient],
  bootstrap: [AppComponent]
})
export class AppModule { }
