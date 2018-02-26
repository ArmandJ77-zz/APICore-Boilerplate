using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Repositories;
using System.Threading.Tasks;
using Unit.Tests.UnitOfWork.Infrastructure;
using Unit.Tests.UnitOFWork.ObjectMothers;

namespace Unit.Tests.UnitOfWork.UOWTests
{
    [TestFixture]
    public class InsertUowTests : BaseUnitOfWork
    {
        [Test]
        public void Uow_InsertBlog_SuccessfullSave()
        {
            
            Uow.GetRepository<Blog>().Insert(BlogObjectMother.NewBlogNoPosts);
            Uow.SaveChanges();

            var result = Uow.GetRepository<Blog>().GetFirstOrDefault(predicate: x =>
                x.Title == BlogObjectMother.NewBlogNoPosts.Title);

            Assert.That(result.Title, Is.EqualTo(BlogObjectMother.NewBlogNoPosts.Title));
        }

        [Test]
        public void Uow_InsertBlogWithPosts_SuccessfullSave()
        {
            Uow.GetRepository<Blog>().Insert(BlogObjectMother.NewBlog);
            Uow.SaveChanges();

            var result = Uow.GetRepository<Blog>().GetFirstOrDefault(predicate: x =>
                x.Title == BlogObjectMother.NewBlog.Title,
                include: i => i.Include(x => x.Posts));

            Assert.That(result.Title, Is.EqualTo(BlogObjectMother.NewBlogNoPosts.Title));
            Assert.That(result.Posts, Is.Not.Null);
        }

        [Test]
        public async Task UowAsyncInsert_MultipleBlogWithPosts_SuccessfullSave()
        {
            var blogs = BlogObjectMother.BuildBlogs(100);

            foreach (var blog in blogs)
            {
                Uow.GetRepository<Blog>().Insert(blog);
                await Uow.SaveChangesAsync();
            }

            var result = Uow.GetRepository<Blog>().GetFirstOrDefault(predicate: x =>
                    x.Title.Contains("MultiInsert"),
                include: i => i.Include(x => x.Posts));

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Posts, Is.Not.Null);
        }

        [Test]
        public async Task UowAsyncInsert_SingleBlogWithPosts_SuccessfullSave()
        {
            Uow.GetRepository<Blog>().Insert(BlogObjectMother.NewAsyncBlog);
            await Uow.SaveChangesAsync();

            var result = Uow.GetRepository<Blog>().GetFirstOrDefault(predicate: x =>
                    x.Title == BlogObjectMother.NewAsyncBlog.Title,
                include: i => i.Include(x => x.Posts));

            Assert.That(result.Title, Is.EqualTo(BlogObjectMother.NewAsyncBlog.Title));
            Assert.That(result.Posts, Is.Not.Null);
        }
    }
}
