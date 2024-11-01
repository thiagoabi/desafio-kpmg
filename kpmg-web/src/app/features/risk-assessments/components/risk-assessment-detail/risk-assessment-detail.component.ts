import { Component, Input, OnInit } from '@angular/core';
import { RiskAssessment } from '../../models/risk-assessment.model';
import { ActivatedRoute } from '@angular/router';
import { RiskAssessmentService } from '../../services/risk-assessment.service';

@Component({
  selector: 'app-risk-assessment-detail',
  templateUrl: './risk-assessment-detail.component.html',
  styleUrls: ['./risk-assessment-detail.component.css'],
  standalone: true,
  imports: []
})
export class RiskAssessmentDetailComponent implements OnInit {
  data?: RiskAssessment;

  constructor(
    private route: ActivatedRoute,
    private service: RiskAssessmentService
  ) {}

  ngOnInit(): void {
    this.loadRiskAssessment();
  }

  loadRiskAssessment(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.service.getRiskAssessmentById(id).subscribe(response => {
        this.data = response;
      });
    }
  }
}
