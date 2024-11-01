export enum EnumIncidentType {
  None = 0,
  HardwareFailure = 1,
  SoftwareBug = 2,
  NetworkIssue = 3,
  SecurityBreach = 4,
  UserError = 5,
  DataLoss = 6,
  ServiceOutage = 7,
  ComplianceIssue = 8
}

export const EnumIncidentTypeLabelMapping: Record<EnumIncidentType, string> = {
  [EnumIncidentType.None]: 'Nenhum',
  [EnumIncidentType.HardwareFailure]: 'Falha de Hardware',
  [EnumIncidentType.SoftwareBug]: 'Erro de Software',
  [EnumIncidentType.NetworkIssue]: 'Problema de Rede',
  [EnumIncidentType.SecurityBreach]: 'Violação de Segurança',
  [EnumIncidentType.UserError]: 'Erro do Usuário',
  [EnumIncidentType.DataLoss]: 'Perda de Dados',
  [EnumIncidentType.ServiceOutage]: 'Interrupção de Serviço',
  [EnumIncidentType.ComplianceIssue]: 'Problema de Conformidade'
};

export enum EnumRiskCategory {
  None = 0,
  Operational = 1,
  Security = 2,
  Compliance = 3
}

export enum EnumSeverityLevel {
  None = 0,
  Low = 1,
  Medium = 2,
  High = 3
}

export const EnumSeverityLevelLabelMapping: Record<EnumSeverityLevel, string> = {
  [EnumSeverityLevel.None]: 'Nenhum',
  [EnumSeverityLevel.Low]: 'Baixo',
  [EnumSeverityLevel.Medium]: 'Médio',
  [EnumSeverityLevel.High]: 'Alto'
};

export enum EnumLikelihood {
  None = 0,
  Rare = 1,
  Likely = 2,
  AlmostCertain = 3
}

export enum EnumRiskAssessmentStatus {
  None = 0,
  Open = 1,
  Mitigated = 2
}



