// services/base.service.ts
import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { UserModel } from '../shared/models/user.model';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  protected http: HttpClient;
  protected baseUrl: string;

  constructor(http: HttpClient) {
    this.http = http;
    this.baseUrl = `${environment.apiUrl}/users`;
  }
  
  getAll(): Observable<UserModel[]> {
    return this.http.get<UserModel[]>(this.baseUrl);
  }
}
