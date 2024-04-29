using LibraryManagementSystem_API.Services.BookService;
using Microsoft.AspNetCore.Mvc;
using Shared.Helper;
using Shared.Models;
using Shared.Models.DTOS;

namespace LibraryManagementSystem_API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<BookDTO>>> GetAll()
        {
            var response = await _bookService.GetBookAsync();
            return Ok(response);
        }
        [HttpGet("get/{bookId:int}")]
        public async Task<ActionResult<ServiceResponse<Author>>> GetById(int bookId)
        {
            var response = await _bookService.GetBookByIdAsync(bookId);
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<BookDTO>>> Create([FromBody] BookDTO book)
        {
            var response = await _bookService.CreateBookAsync(book);
            return Ok(response);
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<BookDTO>>> Update([FromBody] BookDTO book)
        {
            var response = await _bookService.UpdateBookAsync(book);
            return Ok(response);
        }
        [HttpDelete("Delete/{bookId:int}")]
        public async Task<ActionResult<ServiceResponse<BookDTO>>> Delete(int bookId)
        {
            var response = await _bookService.DeleteBookAsync(bookId);
            return Ok(response);
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<BookList>>> GetBookList()
        {
            var response = await _bookService.GetBookList();
            return Ok(response);
        }
    }
}
