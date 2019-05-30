import { Component, OnInit } from '@angular/core';
import { RestApiService } from "../shared/rest-api.service";

@Component({
  selector: 'app-brani-all',
  templateUrl: './brani-all.component.html',
  styleUrls: ['./brani-all.component.css']
})
export class BraniAllComponent implements OnInit {
  Brani: any = [];
  constructor(
    public restApi: RestApiService,
  ) { }

  ngOnInit() {
    this.loadBrani();
  }

loadBrani() {
return this.restApi.getBrani().subscribe((data: {}) => {
this.Brani = data;
})
}
deleteBrano(id) {
    if (window.confirm('Are you sure, you want to delete?')){
    this.restApi.deleteBrano(id).subscribe(data => {
    this.loadBrani()
    })
    }
    }  
}
