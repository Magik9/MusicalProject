import { Component, OnInit } from '@angular/core';
import { RestApiService } from "../shared/rest-api.service";
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-dischi-band',
  templateUrl: './dischi-band.component.html',
  styleUrls: ['./dischi-band.component.css']
})
export class DischiBandComponent implements OnInit {
  id = this.actRoute.snapshot.params['id'];
  Band: any;
  Dischi: any = [];
  constructor(
    public restApi: RestApiService,
    public actRoute: ActivatedRoute
  ) { }

  ngOnInit() {
    this.loadDischiBand(this.id);
  }

  loadDischiBand(idBand) {
    this.restApi.getDischiBand(idBand).subscribe((data: {}) => {
      this.Dischi = data;
      this.Band = this.Dischi[0].band;
  })
  }
  deleteDisco(idDisco) {
    if (window.confirm('Are you sure, you want to delete?')){
    this.restApi.deleteDisco(idDisco).subscribe(data => {
    this.loadDischiBand(this.id);
    })
    }
    } 

}
