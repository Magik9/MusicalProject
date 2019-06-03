import { Component, OnInit } from '@angular/core';
import {Location} from '@angular/common';
import { RestApiService } from "../shared/rest-api.service";
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-update-band',
  templateUrl: './update-band.component.html',
  styleUrls: ['./update-band.component.css']
})
export class UpdateBandComponent implements OnInit {
  id = this.actRoute.snapshot.params['id'];
  Band: any = {};
  constructor(
    private location: Location,
    public restApi: RestApiService,
    public actRoute: ActivatedRoute,
    public router: Router
  ) { }

  ngOnInit() {
    this.restApi.getBand(this.id).subscribe((data: {}) => {
    this.Band = data;
  })
  }
  updateBand() {
    if(window.confirm('Are you sure, you want to update?')){
    this.restApi.updateBand(this.Band).subscribe(data => {
      this.location.back();
  })
  }
  }
}
