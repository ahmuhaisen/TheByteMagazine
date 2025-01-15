namespace TheByteMagazine.Application.DTOs.Authentication;


public class AuthenticationResponse
{
    public string? Message { get; set; }
    public bool IsAuthenticated { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }


    public string? Token { get; set; }
    public DateTime ExpiresOn { get; set; }
}