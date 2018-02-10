using NUnit.Framework;
using Unit.Tests.UnitOfWork.Entities;
using Unit.Tests.UnitOFWork.ObjectMothers;
using UnitOfWork;

namespace Unit.Tests.UnitOfWork.Infrastructure
{
    public class BaseUnitOfWork
    {
        public IUnitOfWork UnitOfWork { get; set; }

        public Repository<Blog> BlogRepository { get; set; }
        public Repository<Post> PostRepository { get; set; }

        [SetUp]
        public void InitTests()
        {
            UnitOfWork = new UnitOfWork<InMemoryContext>(new InMemoryContext());
            
            AddObjectMothers();
            UnitOfWork.SaveChanges();
            //BuildRepos();
        }

        [TearDown]
        public void Dispose()
        {
            ClearDb();
            UnitOfWork.Dispose();
            UnitOfWork = null;
        }

        private void ClearDb()
        {
            //var blogs = BlogRepository.GetAll();
            //foreach (var blog in blogs)
            //{
            //    BlogRepository.Delete(blog);
            //    UnitOfWork.SaveChanges();
            //}
        }

        //private void BuildRepos()
        //{
        //    BlogRepository = new Repository<Blog>(db);
        //    PostRepository = new Repository<Post>(db);
        //}

        private void AddObjectMothers()
        {
            //var repo = UnitOfWork.GetRepository<Blog>();
            //repo.
            //UnitOfWork. .AddRange(BlogObjectMother.GetBlogs());
        }
    }
}