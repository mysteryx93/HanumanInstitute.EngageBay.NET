namespace HanumanInstitute.EngageBayApi.Models;

public class ApiOwner : ApiObject
{
    public long? DomainId { get; set; }
    public string? Email { get; set; }
    public string? PasswordDecrypted { get; set; }
    public string? Name { get; set; }
    public DateTime? CreatedTime { get; set; }
    public DateTime? UpdatedTime { get; set; }
    public bool? IsAdmin { get; set; }
    public bool? IsVerified { get; set; }
    public bool? IsOwner { get; set; }
    public string? JobTitle { get; set; }
    public string? Role { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Language { get; set; }
    public string? TimeZone { get; set; }
    public int? TimeZoneOffset { get; set; }
    public DateTime? LoggedinTime { get; set; }
    public string? MiscInfo { get; set; }
    public bool? IsSignupProcessCompleted { get; set; }
    public string? ProfileImgUrl { get; set; }
    public string? Category { get; set; }
    [JsonPropertyName("signupSource")]
    public string? SignupSource { get; set; }
}
