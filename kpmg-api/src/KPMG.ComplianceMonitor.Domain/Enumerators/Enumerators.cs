namespace KPMG.ComplianceMonitor.Domain.Enumerators;

public enum EnumActionType
{
    None = 0,
    Login = 1,
    Create = 2,
    Update = 3,
    Delete = 4,
    Others = 5
}

public enum EnumComplianceCheckResult
{
    None = 0,
    Pass = 1,
    Fail = 2
}

public enum EnumComplianceType
{
    None = 0,
    GDPR = 1,
    ISO27001 = 2,
    Others = 3
}

public enum EnumIncidentType
{
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

public enum EnumSeverityLevel
{
    None = 0,
    Low = 1,
    Medium = 2,
    High = 3
}

public enum EnumImpactLevel
{
    None = 0,
    Low = 1,
    Medium = 2,
    High = 3
}

public enum EnumLikelihood
{
    None = 0,
    Rare = 1,
    Likely = 2,
    AlmostCertain = 3
}

public enum EnumRiskAssessmentStatus
{
    None = 0,
    Open = 1,
    Mitigated = 2
}

public enum EnumRiskCategory
{
    None = 0,
    Operational = 1,
    Security = 2,
    Compliance = 3
}

public enum EnumLogType
{
    None = 0,
    System = 1,
    External = 2,
    API = 3
}

public enum EnumSource
{
    None = 0,
    Firewall = 1,
    SIEM = 2,
    Antivirus = 3
}

