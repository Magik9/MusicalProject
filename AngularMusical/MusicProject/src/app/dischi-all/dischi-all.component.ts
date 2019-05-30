import { Component, OnInit } from '@angular/core';
import { RestApiService } from "../shared/rest-api.service";

@Component({
  selector: 'app-dischi-all',
  templateUrl: './dischi-all.component.html',
  styleUrls: ['./dischi-all.component.css']
})

export class DischiAllComponent implements OnInit {
  Dischi: any = [];
  constructor(
    public restApi: RestApiService,
  ) { }

  ngOnInit() {
    this.loadDischi();
  }

  loadDischi() {
    return this.restApi.getDischi().subscribe((data: {}) => {
    this.Dischi = data;
    })
    }
}
