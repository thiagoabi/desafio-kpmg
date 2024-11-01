import { Component } from '@angular/core';
import { ComplianceCheckCreateComponent } from '../../components/compliance-check-create/compliance-check-create.component'

@Component({
  selector: 'app-compliance-check-create-page',
  templateUrl: './compliance-check-create-page.component.html',
  styleUrls: ['./compliance-check-create-page.component.css'],
  standalone: true,
  imports: [ComplianceCheckCreateComponent]
})
export class ComplianceCheckCreatePageComponent {}
