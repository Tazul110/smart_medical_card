using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using student_medical_card.Models.LogIn;
using student_medical_card.Service.LoginServ.Interfaces;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace student_medical_card.Controllers.LoginController
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private readonly IGetUserByEmailServ _userServ;


        public LoginController(IConfiguration configuration, IGetUserByEmailServ user)
        {
            _config = configuration;
            _userServ = user;

        }

        private string GenerateToken(User user, bool isRefreshToken = false)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.userEmail),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                // Add additional claims if needed
            };

            var expirationMinutes = Convert.ToDouble(_config[isRefreshToken ? "Jwt:RefreshTokenExpirationInMinutes" : "Jwt:TokenExpirationInMinutes"]);

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(expirationMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }



        /*private string GenerateAccessToken(string refreshToken)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var handler = new JwtSecurityTokenHandler();
            var refreshTokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
                ValidIssuer = _config["Jwt:Issuer"],
                ValidAudience = _config["Jwt:Audience"],
                ClockSkew = TimeSpan.Zero
            };

            SecurityToken securityToken;
            var principal = handler.ValidateToken(refreshToken, refreshTokenValidationParameters, out securityToken);*/

        // ... (existing code)

        // Existing code...

        private IActionResult GenerateAccessToken(string refreshToken)
        {
            SqlConnection connection = new SqlConnection(_config.GetConnectionString("CrudConnection"));
            IActionResult response = Unauthorized();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var handler = new JwtSecurityTokenHandler();
            var refreshTokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
                ValidIssuer = _config["Jwt:Issuer"],
                ValidAudience = _config["Jwt:Audience"],
                ClockSkew = TimeSpan.Zero
            };

            SecurityToken securityToken;
            var principal = handler.ValidateToken(refreshToken, refreshTokenValidationParameters, out securityToken);

            var userEmailClaim = principal?.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
            var userIdClaim = principal?.FindFirst(JwtRegisteredClaimNames.Jti)?.Value;

            var user = new User
            {
                userEmail = userEmailClaim ?? "default@email.com",
                // You may need to extract other user properties from claims
            };

            Debug.WriteLine($"UserEmail22: {user?.userEmail}");

            var authenticatedUser = _userServ.AuthenticateUser(user?.userEmail);

            if (authenticatedUser != null)
            {
                var accessToken = GenerateToken(authenticatedUser);
                var refreshToken1 = GenerateToken(authenticatedUser, true);

                response = Ok(new { token = accessToken, refreshToken = refreshToken1, message = "valid credentials" });
            }
            else
            {
                response = BadRequest(new { message = "Try Again... Invalid user or Invalid password" });
            }

            return response;

          
        }

        [AllowAnonymous]
        [HttpPost("refresh")]
        public IActionResult RefreshToken([FromBody] RefreshRequest request)
        {
            var newAccessToken = GenerateAccessToken(request.RefreshToken);

            return Ok(newAccessToken);
        }




        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(User user)
        {
            SqlConnection connection = new SqlConnection(_config.GetConnectionString("CrudConnection"));
            IActionResult response = Unauthorized();

            var authenticatedUser = _userServ.AuthenticateUser( user.userEmail);

            if (authenticatedUser != null)
            {
                var accessToken = GenerateToken(authenticatedUser);
                var refreshToken = GenerateToken(authenticatedUser, true);

                response = Ok(new { token = accessToken, refreshToken = refreshToken, message = "valid credentials" });
            }
            else
            {
                response = BadRequest(new { message = "Try Again... Invalid user or Invalid password" });
            }

            return response;
        }




    }
}
