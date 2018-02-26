using NUnit.Framework;
using Unit.Tests.UnitOfWork.Infrastructure;
using Unit.Tests.UnitOFWork.ObjectMothers;

namespace Unit.Tests.UnitOfWork.RepositoryTests
{
    [TestFixture]
    public class UpdateRepositoryTests : BaseRepository
    {
        [Test]
        public void RepositoryUpdate_Blog_UpdatedBlog()
        {
            var blog = BlogObjectMother.NewBlog;
            BlogRepository.Insert(blog);
            db.SaveChanges();

            var insertResult = BlogRepository.Find(blog.Id);
            Assert.That(insertResult, Is.Not.Null);

            blog.Hits = 99;
            BlogRepository.Update(blog);
            var updateResult = BlogRepository.Find(blog.Id);
            Assert.That(updateResult.Hits, Is.EqualTo(99));
        }
    }
}
