using AutoMapper;
using Domain.Blogs.DTO;
using Domain.Infrastructure.BaseHandlers;
using Domain.Infrastructure.CustomExceptions;
using Repositories;
using System.Threading.Tasks;
using UnitOfWork;

namespace Domain.Blogs.Handlers
{
    public class BlogUpdateHandler : BaseUpdateHandler<BlogDto>
    {
        public BlogUpdateHandler(IMapper map, IUnitOfWork uow) : base(map, uow)
        {
        }

        public override async Task<long> ExecuteAsync(BlogDto updateDto)
            => await Task.Run(() =>
            {
                var origional = Uow.GetRepository<Blog>().Find(updateDto.Id);

                if (origional != null)
                {
                    var updated = Mapper.Map<BlogDto, Blog>(updateDto);

                    Uow.GetRepository<Blog>().Update(updated);
                    Uow.SaveChanges();
                    return updated.Id;
                }

                throw new NotFoundException();
            });
    }
}
