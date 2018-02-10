using NUnit.Framework;
using System.Linq;
using Unit.Tests.UnitOfWork.Infrastructure;

namespace Unit.Tests.UnitOfWork.Tests
{
    [TestFixture]
    public class GetAllTests : BaseRepository
    {
        [Test]
        public void GetFromRepository_GetAll_ListOfBlogs()
        {
            var result = BlogRepository.GetAll()
                .ToList();

            Assert.That(result.Count, Is.GreaterThan(0));
        }
    }
}
