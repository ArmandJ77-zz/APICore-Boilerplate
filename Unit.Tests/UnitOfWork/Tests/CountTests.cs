using NUnit.Framework;
using Unit.Tests.UnitOfWork.Entities;
using Unit.Tests.UnitOfWork.Infrastructure;
using UnitOfWork;

namespace Unit.Tests.UnitOfWork.Tests
{
    [TestFixture]
    public class CountTests : BaseRepository
    {
        public CountTests()
        {
            
        }
        [Test]
        public void GetFromRpository_Blog_CountOfBlogs()
        {
            var repo = new Repository<Blog>(db);

            var count = repo.Count();

            Assert.That(count, Is.EqualTo(22));
        }
    }
}
