using Domain.Blogs.DTO;
using Domain.Infrastructure;

namespace Domain.Posts.DTO
{
    public class PostDto : BaseDto
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public long BlogId { get; set; }
        public BlogDto Blog { get; set; }
    }
}
