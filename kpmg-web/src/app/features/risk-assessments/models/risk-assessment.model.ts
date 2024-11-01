import { BaseResponseModel } from '@shared/models/base-response.model'
import { EnumRiskCategory, EnumSeverityLevel, EnumLikelihood, EnumRiskAssessmentStatus } from '@shared/enumerators/enumerators';


export interface RiskAssessment extends BaseResponseModel {
  id: string;
  riskCategory?: EnumRiskCategory;
  riskDescription?: string;
  impactLevel?: EnumSeverityLevel;
  likelihood?: EnumLikelihood;
  mitigationPlan?: string;
  assessmentDate?: Date | null;
  status?: EnumRiskAssessmentStatus;
}
