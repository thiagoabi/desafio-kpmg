import {  EnumIncidentType, EnumSeverityLevel } from '@shared/enumerators/enumerators';
import { BaseResponseModel } from '@shared/models/base-response.model';

export interface IncidentRequest {
  userId: string;
  incidentType: EnumIncidentType;
  severityLevel: EnumSeverityLevel;
  description: string;
  incidentDate: Date;
  isResolved: boolean;
  resolutionDate: Date;
  resolutionDetails: string;
}

export interface IncidentResponse extends BaseResponseModel {
  userName: string;
  incidentType: EnumIncidentType;
  severityLevel: EnumSeverityLevel;
  description: string;
  incidentDate: Date;
  isResolved: boolean;
  resolutionDate: Date;
  resolutionDetails: string;
}