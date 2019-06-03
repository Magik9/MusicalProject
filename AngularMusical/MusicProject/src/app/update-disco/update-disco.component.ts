import { Component, OnInit } from '@angular/core';
import {Location} from '@angular/common';
import { RestApiService } from "../shared/rest-api.service";
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-update-disco',
  templateUrl: './update-disco.component.html',
  styleUrls: ['./update-disco.component.css']
})
export class UpdateDiscoComponent implements OnInit {
  id = this.actRoute.snapshot.params['id'];
  Disco: any = {};
  constructor(
    private location: Location,
    public restApi: RestApiService,
    public actRoute: ActivatedRoute,
    public router: Router
  ) { }

  ngOnInit() {
    this.restApi.getDisco(this.id).subscribe((data: {}) => {
      this.Disco = data;
  })
  }
  updateDisco() {
    if(window.confirm('Are you sure, you want to update?')){
    this.restApi.updateDisco(this.Disco).subscribe(data => {
      this.location.back();
  })
  }
  }

}
