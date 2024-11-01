import { Pipe, PipeTransform } from '@angular/core';
import { EnumIncidentType, EnumRiskCategory, EnumSeverityLevel, EnumLikelihood, EnumRiskAssessmentStatus } from '@shared/enumerators/enumerators';

@Pipe({
  name: 'enumDescription'
})
export class EnumDescriptionPipe implements PipeTransform {
  private enumDescriptions: { [key: string]: { [key: number]: string } } = {
    EnumIncidentType: {
      [EnumIncidentType.None]: 'Nenhum',
      [EnumIncidentType.HardwareFailure]: 'Falha de Hardware',
      [EnumIncidentType.SoftwareBug]: 'Erro de Software',
      [EnumIncidentType.NetworkIssue]: 'Problema de Rede',
      [EnumIncidentType.SecurityBreach]: 'Violação de Segurança',
      [EnumIncidentType.UserError]: 'Erro do Usuário',
      [EnumIncidentType.DataLoss]: 'Perda de Dados',
      [EnumIncidentType.ServiceOutage]: 'Interrupção de Serviço',
      [EnumIncidentType.ComplianceIssue]: 'Problema de Conformidade'
    },
    EnumRiskCategory: {
      [EnumRiskCategory.None]: 'Nenhum',
      [EnumRiskCategory.Operational]: 'Operacional',
      [EnumRiskCategory.Security]: 'Segurança',
      [EnumRiskCategory.Compliance]: 'Conformidade'
    },
    EnumSeverityLevel: {
      [EnumSeverityLevel.None]: 'Nenhum',
      [EnumSeverityLevel.Low]: 'Baixo',
      [EnumSeverityLevel.Medium]: 'Médio',
      [EnumSeverityLevel.High]: 'Alto'
    },
    EnumLikelihood: {
      [EnumLikelihood.None]: 'Nenhum',
      [EnumLikelihood.Rare]: 'Raro',
      [EnumLikelihood.Likely]: 'Provável',
      [EnumLikelihood.AlmostCertain]: 'Quase Certo'
    },
    EnumRiskAssessmentStatus: {
      [EnumRiskAssessmentStatus.None]: 'Nenhum',
      [EnumRiskAssessmentStatus.Open]: 'Aberto',
      [EnumRiskAssessmentStatus.Mitigated]: 'Mitigado'
    }
  };

  transform(value: number, enumType: string): string {
    return this.enumDescriptions[enumType]?.[value] || 'Desconhecido';
  }
}
