import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RiskAssessment } from '../models/risk-assessment.model';

@Injectable({
  providedIn: 'root'
})
export class RiskAssessmentService {
  private apiUrl = 'https://api.example.com/risk-assessments';

  constructor(private http: HttpClient) {}

  getRiskAssessments(): Observable<RiskAssessment[]> {
    return this.http.get<RiskAssessment[]>(this.apiUrl);
  }

  getRiskAssessmentById(id: string): Observable<RiskAssessment> {
    return this.http.get<RiskAssessment>(`${this.apiUrl}/${id}`);
  }
}
