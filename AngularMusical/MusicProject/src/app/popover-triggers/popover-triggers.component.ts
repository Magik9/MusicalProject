import { Component, Input, OnInit } from '@angular/core';
import { RestApiService } from "../shared/rest-api.service";
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-popover-triggers',
  templateUrl: './popover-triggers.component.html',
  styleUrls: ['./popover-triggers.component.css']
})
export class PopoverTriggersComponent implements OnInit {
  @Input() disco: any;
  Brani: any = [];

  constructor(
    public restApi: RestApiService,
    public actRoute: ActivatedRoute
  ) {}

  ngOnInit() {
    this.loadBraniDisco(this.disco.Id);
  }
  loadBraniDisco(discoId)
  {
    this.restApi.getBraniDisco(discoId).subscribe((data: {}) => {
      this.Brani = data;
  })
  }
}
