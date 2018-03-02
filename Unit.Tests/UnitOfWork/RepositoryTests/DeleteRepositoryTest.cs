using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;
using TestObjects.ObjectMothers;
using Unit.Tests.UnitOfWork.Infrastructure;

namespace Unit.Tests.UnitOfWork.RepositoryTests
{
    [TestFixture]
    public class DeleteRepositoryTest : BaseRepository
    {
        [Test]
        public void RepositoryDelete_Blog_Null()
        {
            var blog = BlogObjectMother
                .aDefaultBlogWithPost()
                .ToRepository();

            BlogRepository.Insert(blog);
            db.SaveChanges();

            var insertResult = BlogRepository.GetFirstOrDefault(predicate: x =>
                x.Title == BlogObjectMother
                .aDefaultBlogWithPost()
                .Title);

            Assert.That(insertResult.Title, Is.EqualTo(BlogObjectMother
                .aDefaultBlogWithPost()
                .Title));

            BlogRepository.Delete(blog);
            db.SaveChanges();

            var deleteResult = BlogRepository.Find(blog.Id);

            Assert.That(deleteResult, Is.Null);
        }

        [Test]
        public void RepositoryCascadeDelete_BlogPosts_Null()
        {
            var blog = BlogObjectMother
                .aDefaultBlogWithPost()
                .ToRepository();

            BlogRepository.Insert(blog);
            db.SaveChanges();

            var insertResult = BlogRepository.GetFirstOrDefault(predicate: x =>
                    x.Title == BlogObjectMother.aDefaultBlogWithPost().Title,
                    include: i => i.Include(x => x.Posts));

            Assert.That(insertResult.Title, Is.EqualTo(BlogObjectMother.aDefaultBlogWithPost().Title));
            Assert.That(insertResult.Posts, Is.Not.Null);

            var postCount = PostRepository.Count();

            Assert.That(postCount, Is.GreaterThan(0));

            BlogRepository.Delete(blog);
            db.SaveChanges();

            var deleteResult = BlogRepository.Find(blog.Id);

            var postResult = PostRepository.Find(blog.Posts.FirstOrDefault().Id);

            Assert.That(deleteResult, Is.Null);
            //Only the parent was marked for deletion not the child 
            //As the delete operation is set to soft Delete by default
            Assert.That(postResult, Is.Null);

        }
    }
}
