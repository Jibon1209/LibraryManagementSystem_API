using Shared.Helper;
using Shared.Models.DTOS;

namespace LibraryManagementSystem_API.Services.UserService
{
    public interface IUserService
    {
        public Task<ServiceResponse<UserRequestDTO>> SignIn(UserRequestDTO loginRequest);
    }
}
