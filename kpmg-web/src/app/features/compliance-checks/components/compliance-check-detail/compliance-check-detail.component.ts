import { Component, Input, OnInit } from '@angular/core';
import { ComplianceCheck } from '../../models/compliance-check.model';
import { ActivatedRoute } from '@angular/router';
import { ComplianceCheckService } from '../../services/compliance-check.service';

@Component({
  selector: 'app-compliance-check-detail',
  templateUrl: './compliance-check-detail.component.html',
  styleUrls: ['./compliance-check-detail.component.css'],
  standalone: true,
  imports: []
})
export class ComplianceCheckDetailComponent implements OnInit {
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
