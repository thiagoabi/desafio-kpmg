import { Component, OnInit } from '@angular/core';
import { RiskAssessment } from '../../models/risk-assessment.model';
import { RiskAssessmentService } from '../../services/risk-assessment.service';

@Component({
  selector: 'app-risk-assessment-list',
  templateUrl: './risk-assessment-list.component.html',
  styleUrls: ['./risk-assessment-list.component.css'],
  standalone: true,
  imports: []
})
export class RiskAssessmentListComponent implements OnInit {
  data: RiskAssessment[] = [];

  constructor(private service: RiskAssessmentService) {}

  ngOnInit(): void {
    this.loadRiskAssessments();
  }

  loadRiskAssessments(): void {
    this.service.getRiskAssessments().subscribe(response => {
      this.data = response;
    });
  }
}
