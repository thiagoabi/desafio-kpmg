import { Component } from '@angular/core';
import { IncidentListComponent } from '../../components/incident-list/incident-list.component'


@Component({
  selector: 'app-incident-list-page',
  templateUrl: './incident-list-page.component.html',
  styleUrls: ['./incident-list-page.component.css'],
  standalone: true,
  imports: [IncidentListComponent]
})
export class IncidentListPageComponent {}
