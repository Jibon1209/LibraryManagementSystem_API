using LibraryManagementSystem_API.Data;
using Microsoft.EntityFrameworkCore;
using Shared.Helper;
using Shared.Models;

namespace LibraryManagementSystem_API.Services.AuthorService
{
    public class AuthorService : IAuthorService
    {
        private readonly ApplicationDbContext _dbContext;

        public AuthorService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ServiceResponse<Author>> CreateAuthorAsync(Author author)
        {
            var response = new ServiceResponse<Author>();
            try
            {
                await _dbContext.Authors.AddAsync(author);
                await _dbContext.SaveChangesAsync();
                response.Message = ResponseMessage.SaveSuccess;
                response.Data = author;
            }
            catch (Exception ex)
            {

                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<Author>> DeleteAuthorAsync(int authorId)
        {
            var response = new ServiceResponse<Author>();
            try
            {
                var author = await _dbContext.Authors.FindAsync(authorId);
                if (author == null)
                {
                    response.IsSuccess = false;
                    response.Message = ResponseMessage.NotFound;
                }
                else
                {
                    _dbContext.Authors.Remove(author);
                    await _dbContext.SaveChangesAsync();
                    response.Message = ResponseMessage.DeleteSuccess;
                }
            }
            catch (Exception ex)
            {

                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<Author>>> GetAuthorAsync()
        {
            var response = new ServiceResponse<IEnumerable<Author>>();
            try
            {
                var author = await _dbContext.Authors.ToListAsync();
                if(author == null || !author.Any())
                {
                    response.IsSuccess = false;
                    response.Message = ResponseMessage.NotFound;
                }
                else
                {
                    response.Message = ResponseMessage.DataLoaded;
                    response.Data = author;
                }
            }
            catch (Exception ex)
            {

                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<Author>> GetAuthorByIdAsync(int authorId)
        {
            var response = new ServiceResponse<Author>();
            try
            {
                var author = await _dbContext.Authors.FindAsync(authorId);
                if (author == null)
                {
                    response.IsSuccess = false;
                    response.Message = ResponseMessage.NotFound;
                }
                else
                {
                    response.Message = ResponseMessage.DataLoaded;
                    response.Data = author;
                }
            }
            catch (Exception ex)
            {

                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<Author>> UpdateAuthorAsync(Author author)
        {
            var response = new ServiceResponse<Author>();
            try
            {
                 _dbContext.Authors.Update(author);
                await _dbContext.SaveChangesAsync();
                response.Message = ResponseMessage.UpdateSuccess;
                response.Data = author;
            }
            catch (Exception ex)
            {

                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
