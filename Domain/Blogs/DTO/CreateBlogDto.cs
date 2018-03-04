using Domain.Infrastructure;
using Domain.Posts.DTO;
using System.Collections.Generic;

namespace Domain.Blogs.DTO
{
    public class CreateBlogDto : BaseDto
    {
        public string Url { get; set; }
        public string Title { get; set; }

        public List<CreatePostDto> Posts { get; set; }
    }
}
