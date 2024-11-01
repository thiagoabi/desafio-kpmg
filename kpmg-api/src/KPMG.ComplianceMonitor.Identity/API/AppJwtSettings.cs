namespace KPMG.ComplianceMonitor.Infra.CrossCutting.Identity.API;

public class AppJwtSettings
{
    public string SecretKey { get; set; }
    public int Expiration { get; set; } = 1;
    public string Issuer { get; set; } = "KPMG.ComplianceMonitor.Api";
    public string Audience { get; set; } = "Api";
}