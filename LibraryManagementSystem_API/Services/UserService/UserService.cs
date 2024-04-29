using LibraryManagementSystem_API.Data;
using Shared.Helper;
using Shared.Models.DTOS;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem_API.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;
        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ServiceResponse<UserRequestDTO>> SignIn(UserRequestDTO loginRequest)
        {
            var response = new ServiceResponse<UserRequestDTO>();

            var user = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.UserName == loginRequest.UserName && u.Password == loginRequest.Password);

            if (user == null)
            {
                response.IsSuccess = false;
                response.Message = ResponseMessage.InvalidUser;
            }
            else
            {
                var loginResponse = new UserRequestDTO
                {
                    UserName = user.UserName,
                    Password = user.Password,
                };
                response.Data = loginResponse;
                response.Message = ResponseMessage.LoginSuccess;
            }

            return response;
        }

    }
}
