using NUnit.Framework;
using Repositories;
using Unit.Tests.UnitOfWork.Infrastructure;

namespace Unit.Tests.UnitOfWork.UOWTests
{
    [TestFixture]
    public class CountUowTests : BaseUnitOfWork
    {
        [Test]
        public void Uow_Blog_CountOfBlogs()
        {
            var count = Uow.GetRepository<Blog>().Count();
            Assert.That(count, Is.EqualTo(22));
        }
    }
}
