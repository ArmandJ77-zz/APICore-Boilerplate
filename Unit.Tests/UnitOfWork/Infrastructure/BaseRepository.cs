using NUnit.Framework;
using Unit.Tests.UnitOfWork.Entities;
using Unit.Tests.UnitOFWork.ObjectMothers;
using UnitOfWork;

namespace Unit.Tests.UnitOfWork.Infrastructure
{

    public class BaseRepository
    {
        public InMemoryContext db;

        public Repository<Blog> BlogRepository { get; set; }
        public Repository<Post> PostRepository { get; set; }

        [SetUp]
        public void InitTests()
        {
            db = new InMemoryContext();
            AddObjectMothers();
            db.SaveChanges();
            BuildRepos();
            var count = BlogRepository.Count();
        }

        [TearDown]
        public void Dispose()
        {
            ClearDb();
            db.Dispose();
            db = null;
        }

        private void ClearDb()
        {
            var blogs = BlogRepository.GetAll();
            foreach (var blog in blogs)
            {
                BlogRepository.Delete(blog);
                db.SaveChanges();
            }
        }

        private void BuildRepos()
        {
            BlogRepository = new Repository<Blog>(db);
            PostRepository = new Repository<Post>(db);
        }

        private void AddObjectMothers()
        {
            db.AddRange(BlogObjectMother.GetBlogs());
        }
    }
}
