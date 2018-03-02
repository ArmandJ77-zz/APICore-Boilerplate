using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Repositories;
using System.Linq;
using TestObjects.ObjectMothers;
using Unit.Tests.UnitOfWork.Infrastructure;

namespace Unit.Tests.UnitOfWork.UOWTests
{
    [TestFixture]
    public class GetFirstOrDefaultUowTests : BaseUnitOfWork
    {
        [Test]
        [Description("Gets the FirstOrDefault value Where title = QWERTY including Posts orderd by DESC")]
        public void Uow_FirstOrDefaultBlogs_FirstBlogOrderByDescWithPosts()
        {
            var result = Uow.GetRepository<Blog>().GetFirstOrDefault(predicate: x => x.Title == "QWERTY",
                orderBy: o => o.OrderByDescending(d => d.Hits),
                include: i => i.Include(a => a.Posts));

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Posts, Is.Not.Null);
        }

        [Test]
        [Description("Gets the FirstOrDefault value Where title = ASDF including Posts orderd by DESC select first post")]
        public void Uow_FirstOrDefaultBlog_FirstPost()
        {
            var blog = BlogObjectMother
                .aDefaultBlogWithPost()
                .WithTile("ASDF")
                .ToRepository();

            Uow.GetRepository<Blog>().Insert(blog);
            Uow.SaveChanges();

            var result = Uow.GetRepository<Blog>().GetFirstOrDefault(
                predicate: x => x.Title == "ASDF",
                orderBy: o => o.OrderByDescending(d => d.Hits),
                selector: s => s.Posts.FirstOrDefault(),
                include: i => i.Include(a => a.Posts));

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<Post>());
        }
    }
}
