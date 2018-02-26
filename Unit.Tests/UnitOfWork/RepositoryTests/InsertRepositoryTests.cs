using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Unit.Tests.UnitOfWork.Infrastructure;
using Unit.Tests.UnitOFWork.ObjectMothers;

namespace Unit.Tests.UnitOfWork.RepositoryTests
{
    [TestFixture]
    public class InsertRepositoryTests : BaseRepository
    {
        [Test]
        public void InsertRepository_Blog_SuccessfullSave()
        {
            BlogRepository.Insert(BlogObjectMother.NewBlogNoPosts);
            db.SaveChanges();

            var result = BlogRepository.GetFirstOrDefault(predicate: x =>
                x.Title == BlogObjectMother.NewBlogNoPosts.Title);

            Assert.That(result.Title, Is.EqualTo(BlogObjectMother.NewBlogNoPosts.Title));
        }

        [Test]
        public void InsertRepository_BlogWithPosts_SuccessfullSave()
        {
            BlogRepository.Insert(BlogObjectMother.NewBlog);
            db.SaveChanges();

            var result = BlogRepository.GetFirstOrDefault(predicate: x =>
                x.Title == BlogObjectMother.NewBlog.Title,
                include: i => i.Include(x => x.Posts));

            Assert.That(result.Title, Is.EqualTo(BlogObjectMother.NewBlogNoPosts.Title));
            Assert.That(result.Posts, Is.Not.Null);
        }

        [Test]
        public async Task AsyncInsertRepository_MultipleBlogWithPosts_SuccessfullSave()
        {
            var blogs = BlogObjectMother.BuildBlogs(100);

            foreach (var blog in blogs)
            {
                db.Add(blog);
                await db.SaveChangesAsync();
            }

            var result = BlogRepository.GetFirstOrDefault(predicate: x =>
                    x.Title.Contains("MultiInsert"),
                include: i => i.Include(x => x.Posts));

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Posts, Is.Not.Null);
        }

        [Test]
        public async Task AsyncInsertRepository_SingleBlogWithPosts_SuccessfullSave()
        {
            BlogRepository.Insert(BlogObjectMother.NewAsyncBlog);
            await db.SaveChangesAsync();

            var result = BlogRepository.GetFirstOrDefault(predicate: x =>
                    x.Title == BlogObjectMother.NewAsyncBlog.Title,
                include: i => i.Include(x => x.Posts));

            Assert.That(result.Title, Is.EqualTo(BlogObjectMother.NewAsyncBlog.Title));
            Assert.That(result.Posts, Is.Not.Null);
        }
    }
}
