using Domain.Blogs.DTO;
using FluentValidation;

namespace Domain.Blogs.Validation
{
    public class CreateBlogDtoValidator : AbstractValidator<CreateBlogDto>
    {
        public CreateBlogDtoValidator()
        {
            RuleFor(r => r.Title).NotEmpty();
            RuleFor(r => r.Url).NotEmpty();
        }
    }
}
