using System.Linq;
using NUnit.Framework;
using Repositories;
using Unit.Tests.UnitOFWork.ObjectMothers;
using UnitOfWork;

namespace Unit.Tests.UnitOfWork.Infrastructure
{
    public class BaseUnitOfWork
    {
        public IUnitOfWork Uow { get; set; }

        public Repository<Blog> BlogRepository { get; set; }
        public Repository<Post> PostRepository { get; set; }

        [SetUp]
        public void InitTests()
        {
            Uow = new UnitOfWork<InMemoryContext>(new InMemoryContext());
            
            AddObjectMothers();
            Uow.SaveChanges();
        }

        [TearDown]
        public void Dispose()
        {
            ClearDb();
            Uow.Dispose();
            Uow = null;
        }

        private void ClearDb()
        {
            Uow.GetRepository<Blog>().GetAll().ToList().ForEach(blog => Uow.GetRepository<Blog>().Delete(blog));
            Uow.SaveChanges();
        }

        private void AddObjectMothers()
        {
            Uow.GetRepository<Blog>().Insert(BlogObjectMother.GetBlogs());
        }
    }
}