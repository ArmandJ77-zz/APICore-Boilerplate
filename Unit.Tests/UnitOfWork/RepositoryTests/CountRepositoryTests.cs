using NUnit.Framework;
using Repositories;
using Unit.Tests.UnitOfWork.Infrastructure;
using UnitOfWork;

namespace Unit.Tests.UnitOfWork.RepositoryTests
{
    [TestFixture]
    public class CountRepositoryTests : BaseRepository
    {
        [Test]
        public void RepositoryGet_Blog_CountOfBlogs()
        {
            var repo = new Repository<Blog>(db);

            var count = repo.Count();

            Assert.That(count, Is.GreaterThan(0));
        }
    }
}
