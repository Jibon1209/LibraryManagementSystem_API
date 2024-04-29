using AutoMapper;
using LibraryManagementSystem_API.Data;
using Microsoft.EntityFrameworkCore;
using Shared.Helper;
using Shared.Models;
using Shared.Models.DTOS;

namespace LibraryManagementSystem_API.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public BookService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<BookDTO>> CreateBookAsync(BookDTO book)
        {
            var response = new ServiceResponse<BookDTO>();
            var entity = _mapper.Map<Book>(book);
            try
            {
                await _dbContext.Books.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                response.Message = ResponseMessage.SaveSuccess;
                response.Data = book;
            }
            catch (Exception ex)
            {

                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<BookDTO>> DeleteBookAsync(int bookId)
        {
            var response = new ServiceResponse<BookDTO>();
            try
            {
                var bookToDelete = await _dbContext.Books.FindAsync(bookId);
                if (bookToDelete == null)
                {
                    response.IsSuccess = false;
                    response.Message = ResponseMessage.NotFound;
                    return response;
                }

                _dbContext.Books.Remove(bookToDelete);
                await _dbContext.SaveChangesAsync();

                var deletedBookDTO = _mapper.Map<BookDTO>(bookToDelete);

                response.IsSuccess = true;
                response.Message = ResponseMessage.DeleteSuccess;
                response.Data = deletedBookDTO;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }


        public async Task<ServiceResponse<IEnumerable<BookDTO>>> GetBookAsync()
        {
            var response = new ServiceResponse<IEnumerable<BookDTO>>();
            try
            {
                var books = await _dbContext.Books
                    .Include(b => b.Author)
                    .ToListAsync();

                var bookDTOs = books.Select(book => new BookDTO
                {
                    BookID = book.BookID,
                    PublishedDate = book.PublishedDate,
                    Title = book.Title,
                    AvailableCopies = book.AvailableCopies,
                    ISBN = book.ISBN,
                    TotalCopies = book.TotalCopies,
                    AuthorID = book.AuthorID,
                    AuthorName = book.Author?.AuthorName 
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


        public async Task<ServiceResponse<BookDTO>> GetBookByIdAsync(int bookId)
        {
            var response = new ServiceResponse<BookDTO>();
            try
            {
                var book = await _dbContext.Books.FindAsync(bookId);
                if (book == null)
                {
                    response.IsSuccess = false;
                    response.Message = ResponseMessage.NotFound;
                    return response;
                }

                var bookDTO = _mapper.Map<BookDTO>(book);

                response.IsSuccess = true;
                response.Message = ResponseMessage.DataLoaded;
                response.Data = bookDTO;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<BookList>>> GetBookList()
        {
            var response = new ServiceResponse<IEnumerable<BookList>>();
            try
            {
                var books = await _dbContext.Books.ToListAsync();

                if (books == null || !books.Any())
                {
                    response.IsSuccess = false;
                    response.Message = ResponseMessage.NotFound;
                }
                else
                {
                    var bookListDTOs = _mapper.Map<IEnumerable<BookList>>(books);

                    response.Message = ResponseMessage.DataLoaded;
                    response.Data = bookListDTOs;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<BookDTO>> UpdateBookAsync(BookDTO book)
        {
            var response = new ServiceResponse<BookDTO>();
            try
            {
                var bookToUpdate = await _dbContext.Books.FindAsync(book.BookID);
                if (bookToUpdate == null)
                {
                    response.IsSuccess = false;
                    response.Message = ResponseMessage.NotFound;
                    return response;
                }

                bookToUpdate.PublishedDate = book.PublishedDate;
                bookToUpdate.Title = book.Title;
                bookToUpdate.AvailableCopies = book.AvailableCopies;
                bookToUpdate.ISBN = book.ISBN;
                bookToUpdate.TotalCopies = book.TotalCopies;
                bookToUpdate.AuthorID = book.AuthorID;

                _dbContext.Books.Update(bookToUpdate);
                await _dbContext.SaveChangesAsync();

                var updatedBookDTO = _mapper.Map<BookDTO>(bookToUpdate);

                response.IsSuccess = true;
                response.Message = ResponseMessage.UpdateSuccess;
                response.Data = updatedBookDTO;
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
