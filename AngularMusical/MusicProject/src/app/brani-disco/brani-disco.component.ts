import { Component, OnInit } from '@angular/core';
import { RestApiService } from "../shared/rest-api.service";
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-brani-disco',
  templateUrl: './brani-disco.component.html',
  styleUrls: ['./brani-disco.component.css']
})
export class BraniDiscoComponent implements OnInit {
  id = this.actRoute.snapshot.params['id'];
  Disco: any;
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
      this.Disco = this.Brani[0].disco;
  })
  }
}
