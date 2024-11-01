import { Component } from '@angular/core';
import { IncidentDetailComponent } from '../../components/incident-detail/incident-detail.component'


@Component({
  selector: 'app-incident-detail-page',
  templateUrl: './incident-detail-page.component.html',
  styleUrls: ['./incident-detail-page.component.css'],
  standalone: true,
  imports: [IncidentDetailComponent]
})
export class IncidentDetailPageComponent {}
