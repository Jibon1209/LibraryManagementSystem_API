using Shared.Helper;
using Shared.Models.DTOS;

namespace LibraryManagementSystem_API.Services.BookService
{
    public interface IBookService
    {

        Task<ServiceResponse<IEnumerable<BookDTO>>> GetBookAsync();
        Task<ServiceResponse<BookDTO>> GetBookByIdAsync(int bookId);
        Task<ServiceResponse<BookDTO>> CreateBookAsync(BookDTO book);
        Task<ServiceResponse<BookDTO>> UpdateBookAsync(BookDTO book);
        Task<ServiceResponse<BookDTO>> DeleteBookAsync(int bookId);
        Task<ServiceResponse<IEnumerable<BookList>>> GetBookList();
    }
}
