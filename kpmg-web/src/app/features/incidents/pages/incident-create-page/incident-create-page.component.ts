import { Component } from '@angular/core';
import { IncidentCreateComponent } from '../../components/incident-create/incident-create.component'

@Component({
  selector: 'app-incident-create-page',
  templateUrl: './incident-create-page.component.html',
  styleUrls: ['./incident-create-page.component.css'],
  standalone: true,
  imports: [IncidentCreateComponent]
})
export class IncidentCreatePageComponent {}
