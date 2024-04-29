using LibraryManagementSystem_API.Services.AuthorService;
using Microsoft.AspNetCore.Mvc;
using Shared.Helper;
using Shared.Models;

namespace LibraryManagementSystem_API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<Author>>> GetAll()
        {
            var response = await _authorService.GetAuthorAsync();
            return Ok(response);
        }

        [HttpGet("get/{authorId:int}")]
        public async Task<ActionResult<ServiceResponse<Author>>> GetById(int authorId)
        {
            var response = await _authorService.GetAuthorByIdAsync(authorId);
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Author>>> Create([FromBody] Author author)
        {
            var response = await _authorService.CreateAuthorAsync(author);
            return Ok(response);
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<Author>>> Update([FromBody] Author author)
        {
            var response = await _authorService.UpdateAuthorAsync(author);
            return Ok(response);
        }
        [HttpDelete("Delete/{authorId:int}")]
        public async Task<ActionResult<ServiceResponse<Author>>> Delete(int authorId)
        {
            var response = await _authorService.DeleteAuthorAsync(authorId);
            return Ok(response);
        }
    }
}
