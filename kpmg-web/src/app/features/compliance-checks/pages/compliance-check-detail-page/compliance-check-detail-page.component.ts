import { Component } from '@angular/core';

import { ComplianceCheckDetailComponent } from '../../components/compliance-check-detail/compliance-check-detail.component'

@Component({
  selector: 'app-compliance-check-detail-page',
  templateUrl: './compliance-check-detail-page.component.html',
  styleUrls: ['./compliance-check-detail-page.component.css'],
  standalone: true,
  imports: [ComplianceCheckDetailComponent]
})
export class ComplianceCheckDetailPageComponent {}
