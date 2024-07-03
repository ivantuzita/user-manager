namespace UserManager.Domain.Models.Identity; 
public class JwtSettings {

    public required string Key { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public double DurationInMinutes { get; set; }
}
