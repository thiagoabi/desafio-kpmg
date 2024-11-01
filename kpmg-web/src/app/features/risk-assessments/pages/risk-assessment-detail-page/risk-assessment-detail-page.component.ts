import { Component } from '@angular/core';
import { RiskAssessmentDetailComponent } from '../../components/risk-assessment-detail/risk-assessment-detail.component';

@Component({
  selector: 'app-risk-assessment-detail-page',
  templateUrl: './risk-assessment-detail-page.component.html',
  styleUrls: ['./risk-assessment-detail-page.component.css'],
  standalone: true,
  imports: [RiskAssessmentDetailComponent]
})
export class RiskAssessmentDetailPageComponent {}
