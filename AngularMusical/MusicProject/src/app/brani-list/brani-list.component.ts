import { Component, OnInit } from '@angular/core';
import { RestApiService } from "../shared/rest-api.service";
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-brani-list',
  templateUrl: './brani-list.component.html',
  styleUrls: ['./brani-list.component.css']
})
export class BraniListComponent implements OnInit {
  id = this.actRoute.snapshot.params['id'];
  Brani: any = [];
  constructor(
    public restApi: RestApiService,
    public actRoute: ActivatedRoute
  ) { }

  ngOnInit() {
    this.restApi.getBraniDisco(this.id).subscribe((data: {}) => {
      this.Brani = data;
  })
}

}
