using Shared.Helper;
using Shared.Models;

namespace LibraryManagementSystem_API.Services.AuthorService
{
    public interface IAuthorService
    {
        Task<ServiceResponse<IEnumerable<Author>>> GetAuthorAsync();
        Task<ServiceResponse<Author>> GetAuthorByIdAsync(int authorId);
        Task<ServiceResponse<Author>> CreateAuthorAsync(Author author);
        Task<ServiceResponse<Author>> UpdateAuthorAsync(Author author);
        Task<ServiceResponse<Author>> DeleteAuthorAsync(int authorId);
    }
}
