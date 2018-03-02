using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Repositories;
using System.Linq;
using TestObjects.ObjectMothers;
using Unit.Tests.UnitOfWork.Infrastructure;

namespace Unit.Tests.UnitOfWork.RepositoryTests
{
    [TestFixture]
    public class GetFirstOrDefaultRepositoryTests : BaseRepository
    {
        [Test]
        [Description("Gets the FirstOrDefault value Where title = QWERTY including Posts orderd by DESC")]
        public void RepositoryFirstOrDefault_Blogs_FirstBlogOrderByDescWithPosts()
        {
            var result = BlogRepository.GetFirstOrDefault(predicate: x => x.Title == "QWERTY",
                orderBy: o => o.OrderByDescending(d => d.Hits),
                include: i => i.Include(a => a.Posts));

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Hits, Is.GreaterThan(0));
            Assert.That(result.Posts, Is.Not.Null);
        }

        [Test]
        [Description("Gets the FirstOrDefault value Where title = ASDF including Posts orderd by DESC select first post")]
        public void RepositoryFirstOrDefault_Blog_FirstPost()
        {
            db.Add(BlogObjectMother
                .aDefaultBlogWithPost()
                .WithTile("ASDF")
                .WithHits(999)
                .ToRepository());

            db.SaveChanges();

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
