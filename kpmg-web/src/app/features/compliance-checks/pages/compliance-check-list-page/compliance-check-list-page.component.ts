import { Component } from '@angular/core';
import { ComplianceCheckListComponent } from '../../components/compliance-check-list/compliance-check-list.component'

@Component({
  selector: 'app-compliance-check-list-page',
  templateUrl: './compliance-check-list-page.component.html',
  styleUrls: ['./compliance-check-list-page.component.css'],
  standalone: true,
  imports: [ComplianceCheckListComponent]
})
export class ComplianceCheckListPageComponent {}
