using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Repositories;
using System.Linq;
using Unit.Tests.UnitOfWork.Infrastructure;

namespace Unit.Tests.UnitOfWork.UOWTests
{
    [TestFixture]
    public class GetPagedListUowTests : BaseUnitOfWork
    {
        [Test]
        [Description("Gets a Paged list of blog where Title = QWERTY")]
        public void Uow_GetPagedList_ListOfBlogsByPredicate()
        {
            var result = Uow.GetRepository<Blog>().GetPagedList(predicate: x => x.Title == "QWERTY");
            Assert.That(result.Items.Count, Is.GreaterThan(0));
        }

        [Test]
        [Description("Gets a Paged list of blog where Title = QWERTY with a fixed pageSize")]
        public void Uow_GetPagedList_ListOfBlogsWithASetPageLimit()
        {
            var result = Uow.GetRepository<Blog>().GetPagedList(predicate: x => x.Title == "QWERTY",
                pageSize: 2);

            Assert.That(result.Items.Count, Is.EqualTo(2));
        }

        [Test]
        [Description("Gets a Paged list of blog where Hits < 7 select their posts")]
        public void Uow_GetPagedList_WhereHitsLessThan7SelectPosts()
        {
            var result = Uow.GetRepository<Blog>().GetPagedList(predicate: x => x.Hits < 7, selector: y => y.Posts);

            Assert.That(result.Items.Count, Is.EqualTo(16));
            Assert.That(result.Items.FirstOrDefault().FirstOrDefault(), Is.TypeOf<Post>());
        }

        [Test]
        [Description("Gets a Paged list of blog where Title = QWERTY with a fixed pageSize starting at page 2")]
        public void Uow_PagedList_ListOfBlogsWithASetPageLimitSetToAFixedPage()
        {
            var result = Uow.GetRepository<Blog>().GetPagedList(
                pageSize: 10,
                pageIndex: 2);

            Assert.That(result.TotalPages, Is.EqualTo(3));
            Assert.That(result.PageIndex, Is.EqualTo(2));
            Assert.That(result.Items.Count, Is.EqualTo(2));
        }

        [Test]
        [Description("Gets a Paged list of blog where Title = QWERTY and including the Post child object")]
        public void Uow_PagedList_ListOfBlogsByPredicateIncludePosts()
        {
            var result = Uow.GetRepository<Blog>().GetPagedList(predicate: x => x.Title == "QWERTY",
            include:
            source => source.Include(t => t.Posts));

            Assert.That(result.Items.Count, Is.GreaterThan(0));
            Assert.That(result.Items.FirstOrDefault().Posts, Is.Not.Null);
        }

        [Test]
        [Description("Gets a Paged list of blog where Title = ASDF including the Child object Post orderd by Hits in desc order")]
        public void Uow_PagedList_ListOfBlogsAndPostsOrderdByTitleDesc()
        {
            var result = Uow.GetRepository<Blog>().GetPagedList(
                predicate: x => x.Title == "ASDF",
                include: source => source.Include(t => t.Posts),
                orderBy: blog => blog.OrderByDescending(x => x.Hits),
                pageSize: 5);

            Assert.That(result.Items.Count, Is.GreaterThan(0));
            Assert.That(result.Items.FirstOrDefault().Hits, Is.EqualTo(9));
        }
    }
}
