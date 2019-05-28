import { Component, OnInit } from '@angular/core';
import { RestApiService } from "../shared/rest-api.service";
@Component({
selector: 'app-get-list',
host: {
    class:'flex'
},
templateUrl: './get-list.component.html',
styleUrls: ['./get-list.component.css']
})
export class GetListComponent implements OnInit {
Brani: any = [];
Dischi: any = [];
Bands: any = [];
constructor(
public restApi: RestApiService
) { }
ngOnInit() {
this.loadBrani();
this.loadDischi();
this.loadBands();
}
// Get employees list
loadBrani() {
return this.restApi.getBrani().subscribe((data: {}) => {
this.Brani = data;
})
}
loadDischi() {
return this.restApi.getDischi().subscribe((data: {}) => {
this.Dischi = data;
})
}
loadBands() {
    return this.restApi.getBands().subscribe((data: {}) => {
    this.Bands = data;
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