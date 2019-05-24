import { Component, OnInit } from '@angular/core';
import { RestApiService } from "../shared/rest-api.service";
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-update-element',
  host: {
    class:'flex'
},
  templateUrl: './update-element.component.html',
  styleUrls: ['./update-element.component.css']
})
export class UpdateElementComponent implements OnInit {
  id = this.actRoute.snapshot.params['id'];
  Brano: any = {};
  constructor(
    public restApi: RestApiService,
    public actRoute: ActivatedRoute,
    public router: Router
  ) { }

  ngOnInit() {
    this.restApi.getBrano(this.id).subscribe((data: {}) => {
    this.Brano = data;
  })
  }

  updateBrano() {
    if(window.confirm('Are you sure, you want to update?')){
    this.restApi.updateBrano(this.id, this.Brano).subscribe(data => {
      this.router.navigate(['/get-list'])
  })
  }
  }

}
