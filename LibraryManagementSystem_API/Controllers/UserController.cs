using LibraryManagementSystem_API.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Helper;
using Shared.Models.DTOS;

namespace LibraryManagementSystem_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [AllowAnonymous, HttpPost]
        public async Task<ActionResult<ServiceResponse<UserRequestDTO>>> SignIn([FromBody] UserRequestDTO loginRequest)
        {
            var response = await _userService.SignIn(loginRequest);
            return Ok(response);
        }
    }
}
