using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Repositories;
using System.Threading.Tasks;
using TestObjects.ObjectMothers;
using Unit.Tests.UnitOfWork.Infrastructure;

namespace Unit.Tests.UnitOfWork.UOWTests
{
    [TestFixture]
    public class InsertUowTests : BaseUnitOfWork
    {
        [Test]
        public void Uow_InsertBlog_SuccessfullSave()
        {
            Uow.GetRepository<Blog>().Insert(BlogObjectMother
                .aDefaultBlog()
                .ToRepository());

            Uow.SaveChanges();

            var result = Uow.GetRepository<Blog>().GetFirstOrDefault(predicate: x =>
                x.Title == BlogObjectMother.aDefaultBlog().Title);

            Assert.That(result.Title, Is.EqualTo(BlogObjectMother.aDefaultBlog().Title));
        }

        [Test]
        public void Uow_InsertBlogWithPosts_SuccessfullSave()
        {
            Uow.GetRepository<Blog>().Insert(BlogObjectMother
                .aDefaultBlog()
                .ToRepository());

            Uow.SaveChanges();

            var result = Uow.GetRepository<Blog>().GetFirstOrDefault(predicate: x =>
                x.Title == BlogObjectMother.aDefaultBlog().Title,
                include: i => i.Include(x => x.Posts));

            Assert.That(result.Title, Is.EqualTo(BlogObjectMother.aDefaultBlog().Title));
            Assert.That(result.Posts, Is.Not.Null);
        }

        [Test]
        public async Task UowAsyncInsert_MultipleBlogWithPosts_SuccessfullSave()
        {
            var blogs = BlogObjectMother.aListOfBlogsAndPosts("MultiInsert Blog");

            foreach (var blog in blogs)
            {
                Uow.GetRepository<Blog>().Insert(blog);
                await Uow.SaveChangesAsync();
            }

            var result = Uow.GetRepository<Blog>().GetFirstOrDefault(predicate: x =>
                    x.Title.Contains("MultiInsert Blog"),
                include: i => i.Include(x => x.Posts));

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Posts, Is.Not.Null);
        }

        [Test]
        public async Task UowAsyncInsert_SingleBlogWithPosts_SuccessfullSave()
        {
            Uow.GetRepository<Blog>().Insert(BlogObjectMother.aDefaultBlog().ToRepository());

            await Uow.SaveChangesAsync();

            var result = Uow.GetRepository<Blog>().GetFirstOrDefault(predicate: x =>
                    x.Title == BlogObjectMother.aDefaultBlog().Title,
                include: i => i.Include(x => x.Posts));

            Assert.That(result.Title, Is.EqualTo(BlogObjectMother.aDefaultBlog().Title));
            Assert.That(result.Posts, Is.Not.Null);
        }
    }
}
