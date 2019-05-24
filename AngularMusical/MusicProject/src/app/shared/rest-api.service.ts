import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Brano } from '../shared/brani';
import { Band } from '../shared/band';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { Disco } from './disco';
@Injectable({
providedIn: 'root'
})
export class RestApiService {
// Define API
apiURL = 'http://localhost:57490';
constructor(private http: HttpClient) { }
/*========================================
CRUD Methods for consuming RESTful API
=========================================*/
// Http Options
httpOptions = {
headers: new HttpHeaders({
'Content-Type': 'application/json'
})
}  
// HttpClient API get() method => Fetch employees list
getBrano(id): Observable<Brano> {
  return this.http.get<Brano>(this.apiURL + '/Brano/?id=' + id)
  .pipe(
  retry(1),
  catchError(this.handleError)
  )
  }  
getBrani(): Observable<Brano> {
return this.http.get<Brano>(this.apiURL + '/Brani')
.pipe(
retry(1),
catchError(this.handleError)
)
}
getDischi(): Observable<Disco> {
  return this.http.get<Disco>(this.apiURL + '/Dischi')
  .pipe(
  retry(1),
  catchError(this.handleError)
  )
  }
getBands(): Observable<Band> {
  return this.http.get<Band>(this.apiURL + '/Bands')
  .pipe(
  retry(1),
  catchError(this.handleError)
  )
  }
  createBrano(brano): Observable<Brano> {
    return this.http.post<Brano>(this.apiURL + '/AddBrano', JSON.stringify(brano), this.httpOptions)
    .pipe(
    retry(1),
    catchError(this.handleError)
  )
  }  
  deleteBrano(id){
    /*let headers: HttpHeaders = new HttpHeaders();
    headers = headers.append("Access-Control-Allow-Origin", "*");
    this.httpOptions.headers = headers;*/
    return this.http.delete<Brano>(this.apiURL + '/DeleteBrano/?id=' + id, this.httpOptions)
    .pipe(
    retry(1),
    catchError(this.handleError)
  )
  }
  updateBrano(id, brano): Observable<Brano> {
    return this.http.put<Brano>(this.apiURL + '/UpdateBrano/?id=' + id, JSON.stringify(brano), this.httpOptions)
    .pipe(
    retry(1),
    catchError(this.handleError)
  )
  }
handleError(error) {
  let errorMessage = '';
  if(error.error instanceof ErrorEvent) {
  // Get client-side error
  errorMessage = error.error.message;
  } else {
  // Get server-side error
  errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
  }
  window.alert(errorMessage);
  return throwError(errorMessage);
  }
}