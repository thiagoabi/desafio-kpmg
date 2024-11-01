import { Component, OnInit } from '@angular/core';
import { ComplianceCheck } from '../../models/compliance-check.model';
import { ComplianceCheckService } from '../../services/compliance-check.service';

@Component({
  selector: 'app-compliance-check-list',
  templateUrl: './compliance-check-list.component.html',
  styleUrls: ['./compliance-check-list.component.css'],
  standalone: true,
  imports: []
})
export class ComplianceCheckListComponent implements OnInit {
  data: ComplianceCheck[] = [];

  constructor(private service: ComplianceCheckService) {}

  ngOnInit(): void {
    this.loadComplianceChecks();
  }

  loadComplianceChecks(): void {
    this.service.getComplianceChecks().subscribe(response => {
      this.data = response;
    });
  }
}
