using BasicMessenger.Application.Services.Authentication;
using BasicMessenger.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BasicMessenger.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase {
    private readonly IAuthService _authService;
    
    public AuthenticationController(IAuthService authService) {
        _authService = authService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request) {
        var authResult = _authService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password
        );
        
        var response = new AuthResponse(
            authResult.Id,
            authResult.FirstName,
            authResult.LastName,
            authResult.Email,
            authResult.Password,
            authResult.Password
        );
        
        return Ok(response);
    }

    public IActionResult Login(LoginRequest request) {
        var authResult = _authService.Login(
            request.Email,
            request.Password
        );

        var response = new AuthResponse(
            authResult.Id,
            authResult.FirstName,
            authResult.LastName,
            authResult.Email,
            authResult.Password,
            authResult.Password
        );

        return Ok(response);
    }
}