using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Repositories;
using TestObjects.ObjectMothers;
using Unit.Tests.UnitOfWork.Infrastructure;

namespace Unit.Tests.UnitOfWork.UOWTests
{
    [TestFixture]
    public class DeleteUowTests : BaseUnitOfWork
    {
        [Test]
        public void Uow_DeleteBlog_Null()
        {
            //var initalCount = Uow.GetRepository<Blog>()
            //    .GetAll()
            //    .ToList()
            //    .Count;

            var blogInsert = BlogObjectMother
                .aDefaultBlog()
                .ToRepository();

            Uow.GetRepository<Blog>()
                .Insert(blogInsert);

            Uow.SaveChanges();

            var blogGet = Uow.GetRepository<Blog>().Find(blogInsert.Id);

            Assert.That(blogGet, Is.Not.Null);

            Uow.GetRepository<Blog>().Delete(blogGet);
            Uow.SaveChanges();

            //var initalCount2 = Uow.GetRepository<Blog>().GetAll().ToList().Count;

            var blogDelete = Uow.GetRepository<Blog>().Find(blogGet.Id);

            Assert.That(blogDelete, Is.Null);
        }

        [Test]
        public void Uow_CascadeDeleteBlogPosts_Null()
        {
            var blog = BlogObjectMother
                .aDefaultBlog()
                .WithTile("CascadeDelete")
                .ToRepository();

            Uow.GetRepository<Blog>()
                .Insert(blog);

            Uow.SaveChanges();

            var insertResult = Uow.GetRepository<Blog>().GetFirstOrDefault(predicate: x =>
                    x.Title == "CascadeDelete",
                include: i => i.Include(x => x.Posts));

            Assert.That(insertResult.Title, Is.EqualTo("CascadeDelete"));
            Assert.That(insertResult.Posts, Is.Not.Null);

            var postCount = Uow.GetRepository<Post>().Count();

            Assert.That(postCount, Is.GreaterThan(0));

            Uow.GetRepository<Blog>().Delete(blog);
            Uow.SaveChanges();

            var deleteResult = Uow.GetRepository<Blog>().Find(blog.Id);

            Assert.That(deleteResult, Is.Null);
        }
    }
}
