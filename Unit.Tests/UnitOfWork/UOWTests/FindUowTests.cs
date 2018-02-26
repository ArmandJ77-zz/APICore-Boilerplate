using NUnit.Framework;
using Repositories;
using Unit.Tests.UnitOfWork.Infrastructure;

namespace Unit.Tests.UnitOfWork.UOWTests
{
    [TestFixture]
    public class FindUowTests : BaseUnitOfWork
    {
        [Test]
        [Description("Gets the Blog by PrimaryKey")]
        public void Uow_GetBlog_ByPrimaryKey()
        {
            var testBlog = Uow.GetRepository<Blog>().GetFirstOrDefault();

            var result = Uow.GetRepository<Blog>().Find(testBlog.Id);

            Assert.That(result, Is.Not.Null);
        }
    }
}
