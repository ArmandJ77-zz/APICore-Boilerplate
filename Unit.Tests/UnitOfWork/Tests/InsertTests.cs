using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Unit.Tests.UnitOfWork.Infrastructure;
using Unit.Tests.UnitOFWork.ObjectMothers;

namespace Unit.Tests.UnitOfWork.Tests
{
    [TestFixture]
    public class InsertTests : BaseRepository
    {
        [Test]
        public void Insert_Blog_SuccessfullSave()
        {
            BlogRepository.Insert(BlogObjectMother.NewBlogNoPosts);
            db.SaveChanges();

            var result = BlogRepository.GetFirstOrDefault(predicate: x =>
                x.Title == BlogObjectMother.NewBlogNoPosts.Title);

            Assert.That(result.Title, Is.EqualTo(BlogObjectMother.NewBlogNoPosts.Title));
        }

        [Test]
        public void Insert_BlogWithPosts_SuccessfullSave()
        {
            BlogRepository.Insert(BlogObjectMother.NewBlog);
            db.SaveChanges();

            var result = BlogRepository.GetFirstOrDefault(predicate: x =>
                x.Title == BlogObjectMother.NewBlog.Title,
                include: i => i.Include(x => x.Posts));

            Assert.That(result.Title, Is.EqualTo(BlogObjectMother.NewBlogNoPosts.Title));
            Assert.That(result.Posts, Is.Not.Null);
        }
    }
}
