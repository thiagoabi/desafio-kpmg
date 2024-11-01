import { Component, Input, OnInit } from '@angular/core';
import { IncidentResponse } from '../../models/incident.model';
import { ActivatedRoute } from '@angular/router';
import { IncidentService } from '../../services/incident.service';
import { SharedModule } from '@shared/modules/shared.module';

@Component({
  selector: 'app-incident-detail',
  templateUrl: './incident-detail.component.html',
  styleUrls: ['./incident-detail.component.css'],
  standalone: true,
  imports: [SharedModule]
})
export class IncidentDetailComponent implements OnInit {
  @Input() incident?: IncidentResponse;

  constructor(
    private route: ActivatedRoute,
    private service: IncidentService
  ) { }

  ngOnInit(): void {
  }

  loadIncident(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.service.getById(id).subscribe(response => {
        this.incident = response;
      });
    }
  }
}