using Microsoft.WindowsAzure.Storage.Blob;
using NUnit.Framework;
using Unit.Tests.UnitOfWork.Infrastructure;
using Unit.Tests.UnitOFWork.ObjectMothers;

namespace Unit.Tests.UnitOfWork.Tests
{
    [TestFixture]
    public class UpdateTests : BaseRepository
    {
        [Test]
        public void Update_Blog_UpdatedBlog()
        {
            var blog = BlogObjectMother.NewBlog;
            BlogRepository.Insert(blog);
            db.SaveChanges();

            var insertResult = BlogRepository.Find(blog.BlogId);
            Assert.That(insertResult, Is.Not.Null);

            blog.Hits = 99;
            BlogRepository.Update(blog);
            var updateResult = BlogRepository.Find(blog.BlogId);
            Assert.That(updateResult.Hits, Is.EqualTo(99));
        }
    }
}
