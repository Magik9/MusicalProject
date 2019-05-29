import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';

import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { GetListComponent } from './get-list/get-list.component';
import { PostCreateComponent } from './post-create/post-create.component';
import { UpdateElementComponent } from './update-element/update-element.component';
import { BraniListComponent } from './brani-list/brani-list.component';
import { PopoverTriggersComponent } from './popover-triggers/popover-triggers.component';
// Components


@NgModule({
  declarations: [
    AppComponent,
    GetListComponent,
    PostCreateComponent,
    UpdateElementComponent,
    BraniListComponent,
    PopoverTriggersComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    NgbModule
  ],
  exports: [],
  providers: [],
  bootstrap: [AppComponent]
})

export class AppModule { }
