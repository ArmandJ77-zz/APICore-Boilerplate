using System.Linq;
using NUnit.Framework;
using Unit.Tests.UnitOfWork.Infrastructure;

namespace Unit.Tests.UnitOfWork.RepositoryTests
{
    [TestFixture]
    public class GetAllRepositoryTests : BaseRepository
    {
        [Test]
        public void RepositoryGet_GetAll_ListOfBlogs()
        {
            var result = BlogRepository.GetAll()
                .ToList();

            Assert.That(result.Count, Is.GreaterThan(0));
        }
    }
}
