using NUnit.Framework;
using Unit.Tests.UnitOfWork.Infrastructure;

namespace Unit.Tests.UnitOfWork.Tests
{
    [TestFixture]
    public class FindTests : BaseRepository
    {
        [Test]
        [Description("Gets the Blog by PrimaryKey")]
        public void Get_Blog_By_PrimaryKey()
        {
            var  testBlog = BlogRepository.GetFirstOrDefault();
            var result = BlogRepository.Find(testBlog.BlogId);
            
            Assert.That(result, Is.Not.Null);
        }
    }
}
