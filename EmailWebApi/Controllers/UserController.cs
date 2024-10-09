using Microsoft.AspNetCore.Authorization;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Services.Dtos.User.Create;
using Services.Services.Abstraction;
using Services.Authentication;
using System.Security.Claims;

namespace EmailWebApi.Controllers
{   
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ILogger<UserController> _logger;
        public UserController(IUserService userService, IPasswordHasher passwordHasher, ILogger<UserController> logger, IAuthenticationService authenticationService)
        {
            _userService = userService;
            _passwordHasher = passwordHasher;
            _logger = logger;
            _authenticationService = authenticationService;
        }

        [Route("create")]
        [HttpPost]
        public ActionResult CreateNewUser([FromBody] CreateUserDto user)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _userService.Create(user);
                    return Ok();
                }

                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                if (ex.Message == "Invalid credentials")
                {
                    return new JsonResult("The user with this credentials already exists");
                }
                else
                {
                    const string message = ("Error occurred.");
                    _logger.LogError(ex, message);
                    return StatusCode((int)HttpStatusCode.BadRequest, new { ex.Message });
                }

            }
        }

        [Route("Login")]
        [HttpPost]
        public ActionResult LoginUser([FromBody] AppUserAuthRequestDto auth)
        {
            try
            {
                return new JsonResult(_authenticationService.Authenticate(auth.Email, auth.Password));
            }
            catch (Exception ex)
            {
                const string message = ("Error occurred.");
                _logger.LogError(ex, message);
                return StatusCode((int)HttpStatusCode.BadRequest, new { ex.Message });
            }
        }

        [Route("hash/password")]
        [HttpPost]
        public ActionResult HaPass([FromBody] string plainText)
        {
            try
            {
                return new JsonResult(_passwordHasher.HashPassword(plainText));
            }
            catch (Exception ex)
            {
                const string message = ("Error occurred.");
                _logger.LogError(ex, message);
                return StatusCode((int)HttpStatusCode.BadRequest, new { ex.Message });
            }
        }
    }
}
