using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Repositories;
using System.Linq;
using System.Threading.Tasks;
using Unit.Tests.UnitOfWork.Infrastructure;

namespace Unit.Tests.UnitOfWork.UOWTests
{
    public class GetListUowTests : BaseUnitOfWork
    {
        [Test]
        [Description("Gets a list of blog where Title = QWERTY")]
        public void Uow_GetList_ListOfBlogsByPredicate()
        {
            var result = Uow.GetRepository<Blog>().GetList(predicate: x => x.Title == "QWERTY");
            Assert.That(result.Count, Is.GreaterThan(0));
        }

        [Test]
        [Description("Gets a list of blog where Title = QWERTY with a fixed pageSize")]
        public async Task Uow_GetListAsync_ListOfBlogsWithASetPageLimit()
        {
            var result = await Uow.GetRepository<Blog>().GetListAsync(predicate: x => x.Title == "QWERTY");

            Assert.That(result.Count, Is.GreaterThan(0));
        }

        [Test]
        [Description("Gets a list of blog where Hits < 7 select their posts")]
        public void Uow_GetList_WhereHitsLessThan7SelectPosts()
        {
            var result = Uow.GetRepository<Blog>().GetList(predicate: x => x.Hits < 7, selector: y => y.Posts);

            Assert.That(result.Count, Is.EqualTo(16));
            Assert.That(result.FirstOrDefault().FirstOrDefault(), Is.TypeOf<Post>());
        }

        [Test]
        [Description("Gets a list of blog where Hits < 7 select their posts")]
        public async Task Uow_GetListAsync_WhereHitsLessThan7SelectPosts()
        {
            var result = await Uow.GetRepository<Blog>()
                .GetListAsync(predicate: x => x.Hits < 7, selector: y => y.Posts);

            Assert.That(result.Count, Is.EqualTo(16));
            Assert.That(result.FirstOrDefault().FirstOrDefault(), Is.TypeOf<Post>());
        }

        [Test]
        [Description("Gets a list of blog where Title = QWERTY and including the Post child object")]
        public void Uow_ListAsync_ListOfBlogsByPredicateIncludePosts()
        {
            var result = Uow.GetRepository<Blog>().GetPagedList(predicate: x => x.Title == "QWERTY",
                include:
                source => source.Include(t => t.Posts));

            Assert.That(result.Items.Count, Is.GreaterThan(0));
            Assert.That(result.Items.FirstOrDefault().Posts, Is.Not.Null);
        }

        [Test]
        [Description("Gets a list of blog where Title = QWERTY and including the Post child object")]
        public async Task Uow_List_ListOfBlogsByPredicateIncludePosts()
        {
            var result = await Uow.GetRepository<Blog>().GetListAsync(predicate: x => x.Title == "QWERTY",
                include:
                source => source.Include(t => t.Posts));

            Assert.That(result.Count, Is.GreaterThan(0));
            Assert.That(result.FirstOrDefault().Posts, Is.Not.Null);
        }

        [Test]
        [Description(
            "Gets a list of blog where Title = ASDF including the Child object Post orderd by Hits in desc order")]
        public void Uow_List_ListOfBlogsAndPostsOrderdByTitleDesc()
        {
            var result = Uow.GetRepository<Blog>().GetPagedList(
                predicate: x => x.Title == "ASDF",
                include: source => source.Include(t => t.Posts),
                orderBy: blog => blog.OrderByDescending(x => x.Hits));

            Assert.That(result.Items.Count, Is.GreaterThan(0));
            Assert.That(result.Items.FirstOrDefault().Hits, Is.EqualTo(9));
        }
    
        [Test]
        [Description(
            "Gets a list of blog where Title = ASDF including the Child object Post orderd by Hits in desc order")]
        public async Task Uow_ListAsync_ListOfBlogsAndPostsOrderdByTitleDesc()
        {
            var result = await Uow.GetRepository<Blog>().GetListAsync(
                predicate: x => x.Title == "ASDF",
                include: source => source.Include(t => t.Posts),
                orderBy: blog => blog.OrderByDescending(x => x.Hits));

            Assert.That(result.Count, Is.GreaterThan(0));
            Assert.That(result.FirstOrDefault().Hits, Is.EqualTo(9));
        }
    }
}
