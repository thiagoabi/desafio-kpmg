import { Component } from '@angular/core';
import { RiskAssessmentListComponent } from '../../components/risk-assessment-list/risk-assessment-list.component';

@Component({
  selector: 'app-risk-assessment-list-page',
  templateUrl: './risk-assessment-list-page.component.html',
  styleUrls: ['./risk-assessment-list-page.component.css'],
  standalone: true,
  imports: [RiskAssessmentListComponent]
})
export class RiskAssessmentListPageComponent {}
