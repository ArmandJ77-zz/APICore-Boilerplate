using NUnit.Framework;
using Unit.Tests.UnitOfWork.Infrastructure;

namespace Unit.Tests.UnitOfWork.RepositoryTests
{
    [TestFixture]
    public class FindRepositoryTests : BaseRepository
    {
        [Test]
        [Description("Gets the Blog by PrimaryKey")]
        public void RepositoryGet_Blog_By_PrimaryKey()
        {
            var  testBlog = BlogRepository.GetFirstOrDefault();
            var result = BlogRepository.Find(testBlog.Id);
            
            Assert.That(result, Is.Not.Null);
        }
    }
}
