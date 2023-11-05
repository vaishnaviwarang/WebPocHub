using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebPOCHub.DataAccessLayer;
using WebPOCHub.Models;
using WebPOCHub.API.Jwt;

namespace WebPOCHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthentcationController : ControllerBase
    {
        private readonly IAuthenticationRepository _authRepo;
        private readonly ITokenManager _tokenRepo;
        public AuthentcationController(IAuthenticationRepository authRepo, ITokenManager tokenRepo)
        {
            _authRepo = authRepo;
            _tokenRepo = tokenRepo;
        }
        [HttpPost("RegisterUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Create(User model)
        {
            var encryptedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);
            model.Password = encryptedPassword;
            var result = _authRepo.RegisterUsers(model);
            if(result > 0)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost("CheckCredentials")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<AuthResponse> GetDetails(User model)
        {
            var authenticatedUser = _authRepo.CheckCredentials(model);
            if(authenticatedUser == null)
            {
                return NotFound();
            }
            if(authenticatedUser != null && !BCrypt.Net.BCrypt.Verify(model.Password, authenticatedUser.Password))
            {
                return BadRequest("Incorrect Password!Please check your password!");
            }
            var roleName = _authRepo.GetUserRole(authenticatedUser.RoleId);
            var authResponse = new AuthResponse()
            {
                IsAuthenticated = true,
                Role = roleName,
                Token = _tokenRepo.GenerateToken(authenticatedUser,roleName)
            };
            return Ok(authResponse);
        }
    }
}
