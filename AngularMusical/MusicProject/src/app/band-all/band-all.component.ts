import { Component, OnInit } from '@angular/core';
import { RestApiService } from "../shared/rest-api.service";
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-band-all',
  templateUrl: './band-all.component.html',
  styleUrls: ['./band-all.component.css']
})


export class BandAllComponent implements OnInit {
  Bands: any = [];
  constructor(
    public restApi: RestApiService,
    public actRoute: ActivatedRoute
  ) { }

  ngOnInit() {
    this.loadBands();
  }

  loadBands() {
    return this.restApi.getBands().subscribe((data: {}) => {
    this.Bands = data;
    })
    }
    deleteBand(id) {
      if (window.confirm('Are you sure, you want to delete?')){
      this.restApi.deleteBand(id).subscribe(data => {
      this.loadBands();
      })
      }
      } 
}