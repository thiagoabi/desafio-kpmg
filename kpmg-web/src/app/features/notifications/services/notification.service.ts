import { Injectable, NgZone } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, Observable, of } from 'rxjs';
import { NotificationModel } from '../models/notification.model';
import { environment } from '../../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {
  protected baseUrl: string;

  constructor(private http: HttpClient, private zone: NgZone) {    
    this.baseUrl = `${environment.apiUrl}/notifications`;
  }

  public getNotifications(userId: string): Observable<NotificationModel[]> {
    const url = `${this.baseUrl}/stream/${userId}`;

    return new Observable(observer => {
      const eventSource = new EventSource(url);

      eventSource.onmessage = event => {
        this.zone.run(() => {
          const data = JSON.parse(event.data);

          observer.next(data);
        });
      };

      eventSource.onerror = error => {
        this.zone.run(() => {
          observer.error(error);
        });
      };

      return () => {
        eventSource.close();
      };
    });
  }

  setRead(id: string): Observable<any> {
    const url = `${this.baseUrl}/read/${id}`;
    this.http.put<void>(url, null);
    return of();
  }

  protected handleError(error: any): Observable<never> {
    console.error('Erro na requisição:', error);
    throw error;
  }
}
