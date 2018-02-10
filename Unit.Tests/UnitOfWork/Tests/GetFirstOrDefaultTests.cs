using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Unit.Tests.UnitOfWork.Entities;
using Unit.Tests.UnitOfWork.Infrastructure;

namespace Unit.Tests.UnitOfWork.Tests
{
    [TestFixture]
    public class GetFirstOrDefaultTests : BaseRepository
    {
        [Test]
        [Description("Gets the FirstOrDefault value Where title = QWERTY including Posts orderd by DESC")]
        public void FirstOrDefault_Blogs_FirstBlogOrderByDescWithPosts()
        {
            var result = BlogRepository.GetFirstOrDefault(predicate: x => x.Title == "QWERTY",
                orderBy: o => o.OrderByDescending(d => d.Hits),
                include: i => i.Include(a => a.Posts));

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Hits, Is.EqualTo(55));
            Assert.That(result.Posts, Is.Not.Null);
        }

        [Test]
        [Description("Gets the FirstOrDefault value Where title = ASDF including Posts orderd by DESC select first post")]
        public void FirstOrDefault_Blog_FirstPost()
        {
            var result = BlogRepository.GetFirstOrDefault(
                predicate: x => x.Title == "ASDF",
                orderBy: o => o.OrderByDescending(d => d.Hits),
                selector: s => s.Posts.FirstOrDefault(),
                include: i => i.Include(a => a.Posts));

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<Post>());
        }
    }
}
