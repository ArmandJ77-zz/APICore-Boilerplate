using Domain.Infrastructure;
using Domain.Posts.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Blogs.DTO
{
    public class CreateBlogDto : BaseDto
    {
        [Required]
        public string Url { get; set; }
        [Required]
        public string Title { get; set; }

        public List<CreatePostDto> Posts { get; set; }
    }
}
