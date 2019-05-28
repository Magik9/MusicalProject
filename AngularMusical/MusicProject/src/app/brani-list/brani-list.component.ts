import { Component, OnInit } from '@angular/core';
import { RestApiService } from "../shared/rest-api.service";
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-brani-list',
  templateUrl: './brani-list.component.html',
  styleUrls: ['./brani-list.component.css']
})
export class BraniListComponent implements OnInit {
  id = this.actRoute.snapshot.params['id'];
  Brani: any = [];
  constructor(
    public restApi: RestApiService,
    public actRoute: ActivatedRoute
  ) { }
  ngOnInit() {
    this.loadBraniDisco();
  }
  deleteBrano(id) {
    if (window.confirm('Are you sure, you want to delete?')){
    this.restApi.deleteBrano(id).subscribe(data => {
      this.loadBraniDisco();
    })
    }
  }
  loadBraniDisco() {
    this.restApi.getBraniDisco(this.id).subscribe((data: {}) => {
      this.Brani = data;
  })
  }
}
