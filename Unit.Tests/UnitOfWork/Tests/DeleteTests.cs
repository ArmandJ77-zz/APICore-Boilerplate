using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Unit.Tests.UnitOfWork.Infrastructure;
using Unit.Tests.UnitOFWork.ObjectMothers;

namespace Unit.Tests.UnitOfWork.Tests
{
    [TestFixture]
    public class DeleteTests : BaseRepository
    {
        [Test]
        public void Delete_Blog_Null()
        {
            var blog = BlogObjectMother.NewBlogNoPosts;
            BlogRepository.Insert(blog);
            db.SaveChanges();

            var insertResult = BlogRepository.GetFirstOrDefault(predicate: x =>
                x.Title == BlogObjectMother.NewBlog.Title);

            Assert.That(insertResult.Title, Is.EqualTo(BlogObjectMother.NewBlogNoPosts.Title));

            BlogRepository.Delete(blog);
            db.SaveChanges();

            var deleteResult = BlogRepository.Find(blog.BlogId);

            Assert.That(deleteResult, Is.Null);
        }

        [Test]
        public void CascadeDelete_BlogPosts_Null()
        {
            var blog = BlogObjectMother.NewBlog;
            BlogRepository.Insert(blog);
            db.SaveChanges();

            var insertResult = BlogRepository.GetFirstOrDefault(predicate: x =>
                    x.Title == BlogObjectMother.NewBlog.Title,
                    include: i => i.Include(x => x.Posts));

            Assert.That(insertResult.Title, Is.EqualTo(BlogObjectMother.NewBlogNoPosts.Title));
            Assert.That(insertResult.Posts, Is.Not.Null);

            var postCount = PostRepository.Count();

            Assert.That(postCount, Is.GreaterThan(0));

            BlogRepository.Delete(blog);
            db.SaveChanges();

            var deleteResult = BlogRepository.Find(blog.BlogId);

            var postResult = PostRepository.Find(blog.Posts.FirstOrDefault().PostId);

            Assert.That(deleteResult, Is.Null);
            Assert.That(postResult, Is.Null);

        }
    }
}
