using AutoMapper;
using Domain.Posts.DTO;
using Repositories;

namespace Domain.Posts.Mappings
{
    public class PostMapper : Profile
    {
        public  PostMapper() 
        {
            CreateMap<PostDto,Post>()
                .ForMember(s => s.Id, d => d.MapFrom(p => p.Id))
                .ReverseMap()
                ;
        }
    }
}
