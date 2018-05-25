using Domain.Infrastructure;
using Domain.Posts.DTO;
using System.Collections.Generic;

namespace Domain.Blogs.DTO
{
    public class BlogDto : BaseDto
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public List<PostDto> Posts { get; set; }
    }
}
