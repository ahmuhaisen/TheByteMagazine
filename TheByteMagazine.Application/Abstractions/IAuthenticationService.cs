using TheByteMagazine.Application.DTOs.Authentication;

namespace TheByteMagazine.Application.Abstractions;


public interface IAuthenticationService
{
    Task<AuthenticationResponse> RegisterAsync(RegisterRequest request);
    Task<AuthenticationResponse> LoginAsync(LoginRequest request);
}
