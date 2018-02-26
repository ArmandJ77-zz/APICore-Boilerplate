using AutoMapper;
using Domain.Blogs.DTO;
using Domain.Infrastructure.BaseHandlers;
using Repositories;
using System.Threading.Tasks;
using UnitOfWork;

namespace Domain.Blogs.Handlers
{
    public class BlogCreateHandler : BaseCreateHandler<BlogDto>
    {
        public BlogCreateHandler(IMapper map, IUnitOfWork uow) : base(map, uow)
        {
        }

        public override async Task<long> ExecuteAsync(BlogDto creationDto)
            => await Task.Run(() =>
            {
                var blog = Mapper.Map<BlogDto, Blog>(creationDto);
                Uow.GetRepository<Blog>().Insert(blog);
                Uow.SaveChanges();
                return blog.Id;
            });
    }
}
