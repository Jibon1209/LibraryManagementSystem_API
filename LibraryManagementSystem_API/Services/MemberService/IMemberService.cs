using Shared.Helper;
using Shared.Models;
using Shared.Models.DTOS;

namespace LibraryManagementSystem_API.Services.MemberService
{
    public interface IMemberService
    {
        Task<ServiceResponse<IEnumerable<Member>>> GetMemberAsync();
        Task<ServiceResponse<Member>> GetMemberByIdAsync(int memberId);
        Task<ServiceResponse<Member>> CreateMemberAsync(Member member);
        Task<ServiceResponse<Member>> UpdateMemberAsync(Member member);
        Task<ServiceResponse<Member>> DeleteMemberAsync(int memberId);
        Task<ServiceResponse<IEnumerable<MemberList>>> GetMemberList();
    }
}
