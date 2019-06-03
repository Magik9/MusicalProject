import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GetListComponent } from './get-list/get-list.component';
import { PostCreateComponent } from './post-create/post-create.component';
import { UpdateElementComponent } from './update-element/update-element.component';
import { BraniDiscoComponent } from './brani-disco/brani-disco.component';
import { BraniAllComponent } from './brani-all/brani-all.component';
import { DischiAllComponent } from './dischi-all/dischi-all.component';
import { BandAllComponent } from './band-all/band-all.component';
import { DischiBandComponent } from './dischi-band/dischi-band.component';
import { UpdateDiscoComponent } from './update-disco/update-disco.component';
import { UpdateBandComponent } from './update-band/update-band.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'brani-all' },
  {path: 'brani-all', component: BraniAllComponent},
  {path: 'dischi-all', component: DischiAllComponent},
  {path: 'dischi-band/:id', component: DischiBandComponent},
  {path: 'band-all', component: BandAllComponent},
  {path: 'get-list', component: GetListComponent},
  {path: 'post-create', component: PostCreateComponent},
  {path: 'update-element/:id', component: UpdateElementComponent},
  {path: 'update-disco/:id', component: UpdateDiscoComponent},
  {path: 'update-band/:id', component: UpdateBandComponent},
  {path: 'brani-disco/:id', component: BraniDiscoComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
