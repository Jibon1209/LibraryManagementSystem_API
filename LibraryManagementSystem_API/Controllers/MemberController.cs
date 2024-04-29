using LibraryManagementSystem_API.Services.MemberService;
using Microsoft.AspNetCore.Mvc;
using Shared.Helper;
using Shared.Models;
using Shared.Models.DTOS;

namespace LibraryManagementSystem_API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<Member>>> GetAll()
        {
            var response = await _memberService.GetMemberAsync();
            return Ok(response);
        }

        [HttpGet("get/{memberId:int}")]
        public async Task<ActionResult<ServiceResponse<Member>>> GetById(int memberId)
        {
            var response = await _memberService.GetMemberByIdAsync(memberId);
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Member>>> Create([FromBody] Member member)
        {
            var response = await _memberService.CreateMemberAsync(member);
            return Ok(response);
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<Member>>> Update([FromBody] Member member)
        {
            var response = await _memberService.UpdateMemberAsync(member);
            return Ok(response);
        }
        [HttpDelete("Delete/{memberId:int}")]
        public async Task<ActionResult<ServiceResponse<Member>>> Delete(int memberId)
        {
            var response = await _memberService.DeleteMemberAsync(memberId);
            return Ok(response);
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<MemberList>>> GetMemberList()
        {
            var response = await _memberService.GetMemberList();
            return Ok(response);
        }
    }
}
