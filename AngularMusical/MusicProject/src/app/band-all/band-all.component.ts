import { Component, OnInit } from '@angular/core';
import { RestApiService } from "../shared/rest-api.service";

@Component({
  selector: 'app-band-all',
  templateUrl: './band-all.component.html',
  styleUrls: ['./band-all.component.css']
})


export class BandAllComponent implements OnInit {
  Bands: any = [];
  constructor(
    public restApi: RestApiService,
  ) { }

  ngOnInit() {
    this.loadBands();
  }

  loadBands() {
    return this.restApi.getBands().subscribe((data: {}) => {
    this.Bands = data;
    })
    }
}