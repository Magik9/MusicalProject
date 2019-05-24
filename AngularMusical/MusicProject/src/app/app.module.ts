import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { GetListComponent } from './get-list/get-list.component';
import { PostCreateComponent } from './post-create/post-create.component';
import { UpdateElementComponent } from './update-element/update-element.component';
// Components


@NgModule({
  declarations: [
    AppComponent,
    GetListComponent,
    PostCreateComponent,
    UpdateElementComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
