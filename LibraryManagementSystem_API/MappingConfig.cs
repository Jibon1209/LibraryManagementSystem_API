using AutoMapper;
using Shared.Models;
using Shared.Models.DTOS;

namespace LibraryManagementSystem_API
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<BorrowedBook, BorrowedBookDTO>()
    .ForMember(dest => dest.MemberFullName, opt => opt.MapFrom(src => $"{src.Member.FirstName} {src.Member.LastName}"))
    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Book.Title));

            CreateMap<BorrowedBookDTO, BorrowedBook>();
            CreateMap<Book, BookList>();

        }
    }
}
