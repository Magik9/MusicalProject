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
    this.loadDischiBand();
  }

  loadDischiBand() {
    this.restApi.getDischiBand(this.id).subscribe((data: {}) => {
      this.Dischi = data;
      this.Band = this.Dischi[0].Band;
  })
  }

}
