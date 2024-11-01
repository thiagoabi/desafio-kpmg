import { Component, Input, OnInit } from '@angular/core';
import { ComplianceCheck } from '../../models/compliance-check.model';
import { ActivatedRoute } from '@angular/router';
import { ComplianceCheckService } from '../../services/compliance-check.service';
import { SharedModule } from '@shared/modules/shared.module';

@Component({
  selector: 'app-compliance-check-create',
  templateUrl: './compliance-check-create.component.html',
  styleUrls: ['./compliance-check-create.component.css'],
  standalone: true,
  imports: [SharedModule]
})
export class ComplianceCheckCreateComponent implements OnInit {
  data?: ComplianceCheck;

  constructor(
    private route: ActivatedRoute,
    private service: ComplianceCheckService
  ) {}

  ngOnInit(): void {
    this.loadComplianceCheck();
  }

  loadComplianceCheck(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.service.getComplianceCheckById(id).subscribe(response => {
        this.data = response;
      });
    }
  }
}
