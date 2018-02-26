using AutoMapper;
using Domain.Blogs.DTO;
using Repositories;
using UnitOfWork.PagedList;

namespace Domain.Blogs.Mappings
{
    public class BlogMapper : Profile
    {
        public BlogMapper()
        {
            CreateMap<BlogDto, Blog>()
                .ForMember(s => s.Id, d => d.MapFrom(p => p.Id))
                .ForMember(s => s.Posts, d => d.MapFrom(p => p.Posts))
                .ReverseMap()
                ;

            CreateMap<PagedList<Blog>, PagedList<BlogDto>>()
                .ReverseMap()
                ;
        }
    }
}
