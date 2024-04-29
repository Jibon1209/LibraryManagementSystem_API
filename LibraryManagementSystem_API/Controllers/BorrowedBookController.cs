using LibraryManagementSystem_API.Services.BorrowedBookService;
using Microsoft.AspNetCore.Mvc;
using Shared.Helper;
using Shared.Models.DTOS;

namespace LibraryManagementSystem_API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class BorrowedBookController : ControllerBase
    {
        private readonly IBorrowedBookService _borrowedBookService;

        public BorrowedBookController(IBorrowedBookService borrowedBookService)
        {
            _borrowedBookService = borrowedBookService;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<BorrowedBookDTO>>> GetAll()
        {
            var response = await _borrowedBookService.GetBorrowedBookAsync();
            return Ok(response);
        }
        [HttpGet("get/{borrowedBookId:int}")]
        public async Task<ActionResult<ServiceResponse<BorrowedBookDTO>>> GetById(int borrowedBookId)
        {
            var response = await _borrowedBookService.GetBorrowedBookByIdAsync(borrowedBookId);
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<BorrowedBookDTO>>> Create([FromBody] BorrowedBookDTO borrowedBookDTO)
        {
            var response = await _borrowedBookService.CreateBorrowedBookAsync(borrowedBookDTO);
            return Ok(response);
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<BorrowedBookDTO>>> Update([FromBody] BorrowedBookDTO borrowedBookDTO)
        {
            var response = await _borrowedBookService.UpdateBorrowedBookAsync(borrowedBookDTO);
            return Ok(response);
        }
        [HttpDelete("Delete/{borrowedBookId:int}")]
        public async Task<ActionResult<ServiceResponse<BorrowedBookDTO>>> Delete(int borrowedBookId)
        {
            var response = await _borrowedBookService.DeleteBorrowedBookAsync(borrowedBookId);
            return Ok(response);
        }
    }
}
