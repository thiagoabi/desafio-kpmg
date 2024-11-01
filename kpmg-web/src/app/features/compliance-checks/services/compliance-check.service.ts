import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ComplianceCheck } from '../models/compliance-check.model';

@Injectable({
  providedIn: 'root'
})
export class ComplianceCheckService {
  private apiUrl = 'https://api.example.com/compliance-checks';

  constructor(private http: HttpClient) {}

  getComplianceChecks(): Observable<ComplianceCheck[]> {
    return this.http.get<ComplianceCheck[]>(this.apiUrl);
  }

  getComplianceCheckById(id: string): Observable<ComplianceCheck> {
    return this.http.get<ComplianceCheck>(`${this.apiUrl}/${id}`);
  }
}
