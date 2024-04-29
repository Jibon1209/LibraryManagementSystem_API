using Shared.Helper;
using Shared.Models.DTOS;

namespace LibraryManagementSystem_API.Services.BorrowedBookService
{
    public interface IBorrowedBookService
    {
        Task<ServiceResponse<IEnumerable<BorrowedBookDTO>>> GetBorrowedBookAsync();
        Task<ServiceResponse<BorrowedBookDTO>> GetBorrowedBookByIdAsync(int borrowedBookId);
        Task<ServiceResponse<BorrowedBookDTO>> CreateBorrowedBookAsync(BorrowedBookDTO borrowedBook);
        Task<ServiceResponse<BorrowedBookDTO>> UpdateBorrowedBookAsync(BorrowedBookDTO borrowedBook);
        Task<ServiceResponse<BorrowedBookDTO>> DeleteBorrowedBookAsync(int borrowedBookId);
        
    }
}
