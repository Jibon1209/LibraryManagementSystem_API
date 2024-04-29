using LibraryManagementSystem_API.Data;
using Microsoft.EntityFrameworkCore;
using Shared.Helper;
using Shared.Models;

namespace LibraryManagementSystem_API.Services.MemberService
{
    public class MemberService : IMemberService
    {
        private readonly ApplicationDbContext _dbContext;

        public MemberService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ServiceResponse<Member>> CreateMemberAsync(Member member)
        {
            var response = new ServiceResponse<Member>();
            try
            {
                await _dbContext.Members.AddAsync(member);
                await _dbContext.SaveChangesAsync();
                response.Message = ResponseMessage.SaveSuccess;
                response.Data = member;
            }
            catch (Exception ex)
            {

                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<Member>> DeleteMemberAsync(int memberId)
        {
            var response = new ServiceResponse<Member>();
            try
            {
                var member = await _dbContext.Members.FindAsync(memberId);
                if (member == null)
                {
                    response.IsSuccess = false;
                    response.Message = ResponseMessage.NotFound;
                }
                else
                {
                    _dbContext.Members.Remove(member);
                    await _dbContext.SaveChangesAsync();
                    response.Message = ResponseMessage.DeleteSuccess;
                }
            }
            catch (Exception ex)
            {

                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<Member>>> GetMemberAsync()
        {
            var response = new ServiceResponse<IEnumerable<Member>>();
            try
            {
                var member = await _dbContext.Members.ToListAsync();
                if (member == null || !member.Any())
                {
                    response.IsSuccess = false;
                    response.Message = ResponseMessage.NotFound;
                }
                else
                {
                    response.Message = ResponseMessage.DataLoaded;
                    response.Data = member;
                }
            }
            catch (Exception ex)
            {

                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<Member>> GetMemberByIdAsync(int memberId)
        {
            var response = new ServiceResponse<Member>();
            try
            {
                var member = await _dbContext.Members.FindAsync(memberId);
                if (member == null)
                {
                    response.IsSuccess = false;
                    response.Message = ResponseMessage.NotFound;
                }
                else
                {
                    response.Message = ResponseMessage.DataLoaded;
                    response.Data = member;
                }
            }
            catch (Exception ex)
            {

                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<Shared.Models.DTOS.MemberList>>> GetMemberList()
        {
            var response = new ServiceResponse<IEnumerable<Shared.Models.DTOS.MemberList>>();
            try
            {
                var members = await _dbContext.Members.ToListAsync();

                if (members == null || !members.Any())
                {
                    response.IsSuccess = false;
                    response.Message = ResponseMessage.NotFound;
                }
                else
                {
                    var memberListDTOs = members.Select(member => new Shared.Models.DTOS.MemberList
                    {
                        MemberID = member.MemberID,
                        MemberName = $"{member.FirstName} {member.LastName}",
                    });

                    response.Message = ResponseMessage.DataLoaded;
                    response.Data = memberListDTOs;
                }
            }
            catch (Exception ex)
            {

                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<Member>> UpdateMemberAsync(Member member)
        {
            var response = new ServiceResponse<Member>();
            try
            {
                _dbContext.Members.Update(member);
                await _dbContext.SaveChangesAsync();
                response.Message = ResponseMessage.UpdateSuccess;
                response.Data = member;
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
