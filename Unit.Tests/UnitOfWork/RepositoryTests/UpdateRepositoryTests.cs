using NUnit.Framework;
using TestObjects.ObjectMothers;
using Unit.Tests.UnitOfWork.Infrastructure;

namespace Unit.Tests.UnitOfWork.RepositoryTests
{
    [TestFixture]
    public class UpdateRepositoryTests : BaseRepository
    {
        [Test]
        public void RepositoryUpdate_Blog_UpdatedBlog()
        {
            var blog = BlogObjectMother
                .aDefaultBlog()
                .WithTile("Update Blog")
                .ToRepository();

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
