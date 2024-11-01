import { Component } from '@angular/core';
import { RiskAssessmentCreateComponent } from '../../components/risk-assessment-create/risk-assessment-create.component';


@Component({
  selector: 'app-risk-assessment-create-page',
  templateUrl: './risk-assessment-create-page.component.html',
  styleUrls: ['./risk-assessment-create-page.component.css'],
  standalone: true,
  imports: [RiskAssessmentCreateComponent]
})
export class RiskAssessmentCreatePageComponent {}
