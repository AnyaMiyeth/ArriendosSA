
import { InmuebleViewModel } from '../inmueble/viewModel/inmueble-view-model';
import { Injectable, Inject } from '@angular/core';

import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { tap, catchError } from 'rxjs/operators';
import { HandleErrorService } from '../@base/services/handle-error.service';

@Injectable({
  providedIn: 'root'
})
export class InmuebleService {
  baseUrl: string;

  constructor(private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleErrorService) {
    this.baseUrl = baseUrl;  }

  post(inmueble: InmuebleViewModel): Observable<InmuebleViewModel > {
    return this.http.post<InmuebleViewModel>(this.baseUrl + 'api/Inmuebles', inmueble)
      .pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<InmuebleViewModel>('Registro de Inmueble', null))
      );
  }

  get(): Observable<InmuebleViewModel []> {
    return this.http.get<InmuebleViewModel[]>(this.baseUrl + 'api/Inmuebles')
      .pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<InmuebleViewModel []>('Consulta Inmuebles', null))
      );
  }

  getBynumeroInmueble(numeroMatricula: string): Observable<InmuebleViewModel > {
    return this.http.get<InmuebleViewModel>(this.baseUrl + 'api/Inmuebles/' + numeroMatricula)
      .pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<InmuebleViewModel >('Consulta de Inmueble por numero de Matricula', null))
      );
  }


}
