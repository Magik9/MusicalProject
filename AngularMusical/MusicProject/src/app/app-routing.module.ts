import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GetListComponent } from './get-list/get-list.component';
import { PostCreateComponent } from './post-create/post-create.component';
import { UpdateElementComponent } from './update-element/update-element.component';
import { BraniListComponent } from './brani-list/brani-list.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'get-list' },
  {path: 'get-list', component: GetListComponent},
  {path: 'post-create', component: PostCreateComponent},
  {path: 'update-element/:id', component: UpdateElementComponent},
  {path: 'brani-disco/:id', component: BraniListComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
