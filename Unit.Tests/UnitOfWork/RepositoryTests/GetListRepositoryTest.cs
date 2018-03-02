using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Repositories;
using Unit.Tests.UnitOfWork.Infrastructure;

namespace Unit.Tests.UnitOfWork.RepositoryTests
{
    [TestFixture]
    public class GetListRepositoryTest : BaseRepository
    {
        [Test]
        [Description("Gets a list of blog where Title = QWERTY")]
        public void RepositoryGet_PagedList_ListOfBlogsByPredicate()
        {
            var result = BlogRepository.GetList(predicate: x => x.Title == "QWERTY");
            Assert.That(result.Count, Is.GreaterThan(0));
        }

        [Test]
        [Description("Gets a list of blog where Title = QWERTY")]
        public async Task RepositoryGet_AsyncPagedList_ListOfBlogsByPredicate()
        {
            var result = await BlogRepository.GetListAsync(predicate: x => x.Title == "QWERTY");
            Assert.That(result.Count, Is.GreaterThan(0));
        }

        [Test]
        [Description("Gets a list of blog where Hits < 7 select their posts")]
        public void RepositoryGet_PagedList_WhereHitsLessThan7SelectPosts()
        {
            var result = BlogRepository.GetPagedList(predicate: x => x.Hits < 7, selector: y => y.Posts);

            Assert.That(result.Items.Count, Is.GreaterThan(0));
            Assert.That(result.Items.FirstOrDefault().FirstOrDefault(), Is.TypeOf<Post>());
        }

        [Test]
        [Description("Gets a list of blog where Hits < 7 select their posts")]
        public async Task RepositoryGet_AsyncPagedList_WhereHitsLessThan7SelectPosts()
        {
            var result = await BlogRepository.GetListAsync(predicate: x => x.Hits < 7, selector: y => y.Posts);

            Assert.That(result.Count, Is.GreaterThan(0));
            Assert.That(result.FirstOrDefault().FirstOrDefault(), Is.TypeOf<Post>());
        }

        [Test]
        [Description("Gets a list of blog where Title = QWERTY and including the Post child object")]
        public void RepositoryGet_PagedList_ListOfBlogsByPredicateIncludePosts()
        {
            var result = BlogRepository.GetList(predicate: x => x.Title == "QWERTY",
            include: source => source.Include(t => t.Posts));

            Assert.That(result.Count, Is.GreaterThan(0));
            Assert.That(result.FirstOrDefault().Posts, Is.Not.Null);
        }

        [Test]
        [Description("Gets a list of blog where Title = QWERTY and including the Post child object")]
        public async Task RepositoryGet_AsyncPagedList_ListOfBlogsByPredicateIncludePosts()
        {
            var result = await BlogRepository.GetListAsync(predicate: x => x.Title == "QWERTY",
                include: source => source.Include(t => t.Posts));

            Assert.That(result.Count, Is.GreaterThan(0));
            Assert.That(result.FirstOrDefault().Posts, Is.Not.Null);
        }

        [Test]
        [Description("Gets a list of blog where Title = ASDF including the Child object Post orderd by Hits in desc order")]
        public void RepositoryGet_PagedList_ListOfBlogsAndPostsOrderdByTitleDesc()
        {
            var result = BlogRepository.GetList(
                predicate: x => x.Title == "ASDF",
                include: source => source.Include(t => t.Posts),
                orderBy: blog => blog.OrderByDescending(x => x.Hits));

            Assert.That(result.Count, Is.GreaterThan(0));
            Assert.That(result.FirstOrDefault().Hits, Is.GreaterThan(0));
        }


        [Description("Gets a list of blog where Title = ASDF including the Child object Post orderd by Hits in desc order")]
        public async Task RepositoryGet_AsyncPagedList_ListOfBlogsAndPostsOrderdByTitleDesc()
        {
            var result = await BlogRepository.GetListAsync(
                predicate: x => x.Title == "ASDF",
                include: source => source.Include(t => t.Posts),
                orderBy: blog => blog.OrderByDescending(x => x.Hits));

            Assert.That(result.Count, Is.GreaterThan(0));
            Assert.That(result.FirstOrDefault().Hits, Is.EqualTo(9));
        }
    }
}
