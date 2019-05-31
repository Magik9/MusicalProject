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
import { BraniDiscoComponent } from './brani-disco/brani-disco.component';
import { PopoverTriggersComponent } from './popover-triggers/popover-triggers.component';
import { BraniAllComponent } from './brani-all/brani-all.component';
import { DischiAllComponent } from './dischi-all/dischi-all.component';
import { BandAllComponent } from './band-all/band-all.component';
import { DischiBandComponent } from './dischi-band/dischi-band.component';
// Components


@NgModule({
  declarations: [
    AppComponent,
    GetListComponent,
    PostCreateComponent,
    UpdateElementComponent,
    BraniDiscoComponent,
    PopoverTriggersComponent,
    BraniAllComponent,
    DischiAllComponent,
    BandAllComponent,
    DischiBandComponent
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
