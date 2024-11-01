import { Component, Input, OnInit } from '@angular/core';
import { RiskAssessment } from '../../models/risk-assessment.model';
import { ActivatedRoute } from '@angular/router';
import { RiskAssessmentService } from '../../services/risk-assessment.service';
import { SharedModule } from '@shared/modules/shared.module';

@Component({
  selector: 'app-risk-assessment-create',
  templateUrl: './risk-assessment-create.component.html',
  styleUrls: ['./risk-assessment-create.component.css'],
  standalone: true,
  imports: [SharedModule]
})
export class RiskAssessmentCreateComponent implements OnInit {
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
