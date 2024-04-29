using AutoMapper;
using LibraryManagementSystem_API.Data;
using Microsoft.EntityFrameworkCore;
using Shared.Helper;
using Shared.Models;
using Shared.Models.DTOS;

namespace LibraryManagementSystem_API.Services.BorrowedBookService
{
    public class BorrowedBookService : IBorrowedBookService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public BorrowedBookService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<BorrowedBookDTO>> CreateBorrowedBookAsync(BorrowedBookDTO borrowedBookDTO)
        {
            var response = new ServiceResponse<BorrowedBookDTO>();

            try
            {
                var entity = _mapper.Map<BorrowedBook>(borrowedBookDTO);

                await _dbContext.BorrowedBooks.AddAsync(entity);

                await _dbContext.SaveChangesAsync();

                response.Message = ResponseMessage.SaveSuccess;
                response.Data = borrowedBookDTO; 
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }


        public async Task<ServiceResponse<BorrowedBookDTO>> DeleteBorrowedBookAsync(int borrowedBookId)
        {
            var response = new ServiceResponse<BorrowedBookDTO>();

            try
            {
                var borrowedBook = await _dbContext.BorrowedBooks
                    .FirstOrDefaultAsync(b => b.BorrowID == borrowedBookId);

                if (borrowedBook == null)
                {
                    response.IsSuccess = false;
                    response.Message = ResponseMessage.NotFound;
                    return response;
                }

                _dbContext.BorrowedBooks.Remove(borrowedBook);
                await _dbContext.SaveChangesAsync();

                response.Message = ResponseMessage.DeleteSuccess;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<IEnumerable<BorrowedBookDTO>>> GetBorrowedBookAsync()
        {
            var response = new ServiceResponse<IEnumerable<BorrowedBookDTO>>();
            try
            {
                var borrowedBooks = await _dbContext.BorrowedBooks
                    .Include(b => b.Member)
                    .Include(C => C.Book)
                    .ToListAsync();

                var bookDTOs = borrowedBooks.Select(book => new BorrowedBookDTO
                {
                    BorrowID = book.BorrowID,
                    BorrowDate = book.BorrowDate,
                    MemberId = book.MemberId,
                    MemberFullName = $"{book.Member?.FirstName} {book.Member?.LastName}",
                    ReturnDate = book.ReturnDate,
                    BookId = book.BookId,
                    Title = book.Book?.Title,
                    Status = book.Status
                });

                if (bookDTOs == null || !bookDTOs.Any())
                {
                    response.IsSuccess = false;
                    response.Message = ResponseMessage.NotFound;
                }
                else
                {
                    response.Message = ResponseMessage.DataLoaded;
                    response.Data = bookDTOs;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<BorrowedBookDTO>> GetBorrowedBookByIdAsync(int borrowedBookId)
        {
            var response = new ServiceResponse<BorrowedBookDTO>();

            try
            {
                var borrowedBook = await _dbContext.BorrowedBooks
                    .Include(b => b.Member)
                    .Include(b => b.Book)
                    .FirstOrDefaultAsync(b => b.BorrowID == borrowedBookId);

                if (borrowedBook == null)
                {
                    response.IsSuccess = false;
                    response.Message = ResponseMessage.NotFound;
                    return response;
                }

                var borrowedBookDTO = _mapper.Map<BorrowedBookDTO>(borrowedBook);

                response.Data = borrowedBookDTO;
                response.Message = ResponseMessage.DataLoaded;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }


        public async Task<ServiceResponse<BorrowedBookDTO>> UpdateBorrowedBookAsync(BorrowedBookDTO borrowedBook)
        {
            var response = new ServiceResponse<BorrowedBookDTO>();

            try
            {
                var borrowedBookUpdate = await _dbContext.BorrowedBooks.FindAsync(borrowedBook.BorrowID);

                if (borrowedBook == null)
                {
                    response.IsSuccess = false;
                    response.Message = ResponseMessage.NotFound;
                    return response;
                }

                borrowedBookUpdate.BorrowDate = borrowedBook.BorrowDate;
                borrowedBookUpdate.MemberId = borrowedBook.MemberId;
                borrowedBookUpdate.ReturnDate = borrowedBook.ReturnDate;
                borrowedBookUpdate.BookId = borrowedBook.BookId;
                borrowedBookUpdate.Status = borrowedBook.Status;

                await _dbContext.SaveChangesAsync();

                var updatedBorrowedBookDto = _mapper.Map<BorrowedBookDTO>(borrowedBook);

                response.Data = updatedBorrowedBookDto;
                response.Message = ResponseMessage.UpdateSuccess;
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
