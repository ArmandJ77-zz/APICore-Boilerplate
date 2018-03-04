using Domain.Infrastructure;

namespace Domain.Posts.DTO
{
    public class CreatePostDto: BaseDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
