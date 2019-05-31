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
apiBands = 'http://localhost:57490/Bands/';
apiBrani = 'http://localhost:57490/Brani/';
apiDischi = 'http://localhost:57490/Dischi/';
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
  return this.http.get<Brano>(this.apiBrani + id)
  .pipe(
  retry(1),
  catchError(this.handleError)
  )
  }  
getBraniDisco(id): Observable<Brano> {
  return this.http.get<Brano>(this.apiBrani + 'Disco/' + id)
  .pipe(
  retry(1),
  catchError(this.handleError)
  )
  }  
getBrani(): Observable<Brano> {
return this.http.get<Brano>(this.apiBrani)
.pipe(
retry(1),
catchError(this.handleError)
)
}
getDischi(): Observable<Disco> {
  return this.http.get<Disco>(this.apiDischi)
  .pipe(
  retry(1),
  catchError(this.handleError)
  )
  }
getDischiBand(id): Observable<Disco> {
  return this.http.get<Disco>(this.apiDischi + 'Band/' + id)
  .pipe(
  retry(1),
  catchError(this.handleError)
  )
  }
getBands(): Observable<Band> {
  return this.http.get<Band>(this.apiBands)
  .pipe(
  retry(1),
  catchError(this.handleError)
  )
  }
  createBrano(brano): Observable<Brano> {
    return this.http.post<Brano>(this.apiBrani + 'Add', JSON.stringify(brano), this.httpOptions)
    .pipe(
    retry(1),
    catchError(this.handleError)
  )
  }  
  deleteBrano(id){
    /*let headers: HttpHeaders = new HttpHeaders();
    headers = headers.append("Access-Control-Allow-Origin", "*");
    this.httpOptions.headers = headers;*/
    return this.http.delete<Brano>(this.apiBrani + '/Delete/' + id, this.httpOptions)
    .pipe(
    retry(1),
    catchError(this.handleError)
  )
  }
  deleteDisco(id){
    return this.http.delete<Disco>(this.apiDischi + '/Delete/' + id, this.httpOptions)
    .pipe(
    retry(1),
    catchError(this.handleError)
  )
  }
  deleteBand(id){
    return this.http.delete<Band>(this.apiBands + '/Delete/' + id, this.httpOptions)
    .pipe(
    retry(1),
    catchError(this.handleError)
  )
  }
  updateBrano(brano): Observable<Brano> {
    return this.http.put<Brano>(this.apiBrani + 'Update', JSON.stringify(brano), this.httpOptions)
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