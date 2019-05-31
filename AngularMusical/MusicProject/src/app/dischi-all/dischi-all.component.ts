import { Component, OnInit } from '@angular/core';
import { RestApiService } from "../shared/rest-api.service";
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-dischi-all',
  templateUrl: './dischi-all.component.html',
  styleUrls: ['./dischi-all.component.css']
})

export class DischiAllComponent implements OnInit {
  Dischi: any = [];
  constructor(
    public restApi: RestApiService,
    public actRoute: ActivatedRoute,
  ) { }

  ngOnInit() {
    this.loadDischi();
  }

  loadDischi() {
    return this.restApi.getDischi().subscribe((data: {}) => {
    this.Dischi = data;
    })
    }
    deleteDisco(id) {
      if (window.confirm('Are you sure, you want to delete?')){
      this.restApi.deleteDisco(id).subscribe(data => {
      this.loadDischi();
      })
      }
      } 
}
