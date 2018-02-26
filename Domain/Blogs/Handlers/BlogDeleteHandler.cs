//using AutoMapper;
//using Domain.Infrastructure.BaseHandlers;
//using Domain.Infrastructure.CustomExceptions;
//using Repositories;
//using System.Threading.Tasks;
//using UnitOfWork;

//namespace Domain.Blogs.Handlers
//{
//    public class BlogDeleteHandler : BaseDeleteHandler<Blog>
//    {
//        public BlogDeleteHandler(IMapper map, IUnitOfWork uow) : base(map, uow)
//        {
//        }

//        public override async Task<int> ExecuteAsync(int id)
//            => await Task.Run(() =>
//            {
//                var entity = Uow.GetRepository<Blog>().Find(id);

//                if (entity == null)
//                    throw new NotFoundException();

//                Uow.GetRepository<Blog>().Delete(entity);
//                Uow.SaveChanges();
//                return id;
//            });
//    }
//}
