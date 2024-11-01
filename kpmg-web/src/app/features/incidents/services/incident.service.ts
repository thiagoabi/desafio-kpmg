import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { BaseService } from '@app/services/base.service';
import { IncidentRequest, IncidentResponse } from '../models/incident.model';

@Injectable({
  providedIn: 'root'
})
export class IncidentService extends BaseService<IncidentRequest, IncidentResponse> {
  constructor(http: HttpClient) {
    super(http, 'incidents');
  }
}
