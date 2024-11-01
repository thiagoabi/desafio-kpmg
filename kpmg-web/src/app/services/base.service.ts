import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export abstract class BaseService<TRequest, TResponse> {
  protected http: HttpClient;
  protected baseUrl: string;

  constructor(http: HttpClient, endpoint: string) {
    this.http = http;
    this.baseUrl = `${environment.apiUrl}/${endpoint}`;
  }

  getAll(): Observable<TResponse[]> {
    return this.http.get<TResponse[]>(this.baseUrl);
  }

  getById(id: string): Observable<TResponse> {
    return this.http.get<TResponse>(`${this.baseUrl}/${id}`);
  }

  create(item: TRequest): Observable<void> {
    return this.http.post<void>(this.baseUrl, item).pipe(
      catchError(this.handleError)
    );
  }

  update(id: string | null, item: TRequest): Observable<void> {
    if (!id) {
      return of();
    }
    return this.http.put<void>(`${this.baseUrl}/${id}`, item).pipe(
      catchError(this.handleError)
    );
  }

  delete(id: string): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`).pipe(
      catchError(this.handleError)
    );
  }

  protected handleError(error: any): Observable<never> {
    console.error('Erro na requisição:', error);
    throw error; // Ou use alguma forma de manipulação específica, como retornar um Observable de erro
  }
}
