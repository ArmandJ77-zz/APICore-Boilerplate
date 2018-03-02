using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Repositories;
using TestObjects.ObjectMothers;
using Unit.Tests.UnitOfWork.Infrastructure;

namespace Unit.Tests.UnitOfWork.RepositoryTests
{
    [TestFixture]
    public class InsertRepositoryTests : BaseRepository
    {
        [Test]
        public void InsertRepository_Blog_SuccessfullSave()
        {
            BlogRepository.Insert(BlogObjectMother.aDefaultBlog().ToRepository());
            db.SaveChanges();

            var result = BlogRepository.GetFirstOrDefault(predicate: x =>
                x.Title == BlogObjectMother.aDefaultBlog().Title);

            Assert.That(result.Title, Is.EqualTo(BlogObjectMother.aDefaultBlog().Title));
        }

        [Test]
        public void InsertRepository_BlogWithPosts_SuccessfullSave()
        {
            BlogRepository.Insert(BlogObjectMother.aDefaultBlogWithPost().ToRepository());
            db.SaveChanges();

            var result = BlogRepository.GetFirstOrDefault(predicate: x =>
                x.Title == BlogObjectMother.aDefaultBlog().Title,
                include: i => i.Include(x => x.Posts));

            Assert.That(result.Title, Is.EqualTo(BlogObjectMother.aDefaultBlogWithPost().Title));
            Assert.That(result.Posts, Is.Not.Null);
        }

        [Test]
        public async Task AsyncInsertRepository_MultipleBlogWithPosts_SuccessfullSave()
        {
            var blogs = new List<Blog>();

            for (int i = 0; i < 100; i++)
            {
                blogs.Add(BlogObjectMother
                    .aDefaultBlog()
                    .WithTile($"Test Blog MultiInsert {i}")
                    .ToRepository());
            }

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
            BlogRepository.Insert(BlogObjectMother
                .aDefaultBlogWithPost()
                .WithTile("Async Blog Test")
                .ToRepository());

            await db.SaveChangesAsync();

            var result = BlogRepository.GetFirstOrDefault(predicate: x =>
                    x.Title == "Async Blog Test",
                include: i => i.Include(x => x.Posts));

            Assert.That(result.Title, Is.EqualTo("Async Blog Test"));
            Assert.That(result.Posts, Is.Not.Null);
        }
    }
}
