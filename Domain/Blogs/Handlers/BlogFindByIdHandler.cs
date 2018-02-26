using AutoMapper;
using Domain.Infrastructure.BaseHandlers;
using Repositories;
using System.Threading.Tasks;
using Domain.Blogs.DTO;
using UnitOfWork;
using Domain.Infrastructure.CustomExceptions;

namespace Domain.Blogs.Handlers
{
    public class BlogFindByIdHandler : BaseFindByIdHandler<BlogDto>
    {
        public BlogFindByIdHandler(IMapper map, IUnitOfWork uow) : base(map, uow)
        {
        }

        public override async Task<BlogDto> ExecuteAsync(int id)
            => await Task.Run(() =>
            {
                var response = Uow.GetRepository<Blog>().Find(id);

                if (response == null)
                    throw new NotFoundException();

                return Mapper.Map<Blog, BlogDto>(response);
            });
    }
}
