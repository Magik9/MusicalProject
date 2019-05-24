import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { RestApiService } from '../shared/rest-api.service';
//import { GetListComponent } from '../get-list/get-list.component';

@Component({
  selector: 'app-post-create',
  host: {
    class:'flex'
},
  templateUrl: './post-create.component.html',
  styleUrls: ['./post-create.component.css']
})
export class PostCreateComponent implements OnInit {
  @Input() branoDetails = {Titolo:'', Band:'', Disco:'', Anno:1990, Durata:0}
  constructor(
    public restApi: RestApiService, 
    public router: Router,
    //public getComponent: GetListComponent
  ) { }

  ngOnInit() {

  }

  addBrano() {
    this.restApi.createBrano(this.branoDetails).subscribe((data: {}) => {
      this.router.navigate(['/get-list'])
    })
    }

}
