using NUnit.Framework;
using Repositories;
using System.Linq;
using Unit.Tests.UnitOfWork.Infrastructure;

namespace Unit.Tests.UnitOfWork.UOWTests
{
    [TestFixture]
    public class GetAllUowTests : BaseUnitOfWork
    {
        [Test]
        public void Uow_GetAll_ListOfBlogs()
        {
            var result = Uow.GetRepository<Blog>().GetAll()
                .ToList();

            Assert.That(result.Count, Is.GreaterThan(0));
        }
    }
}
