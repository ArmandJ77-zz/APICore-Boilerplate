//using System.Linq;
//using Microsoft.EntityFrameworkCore;
//using NUnit.Framework;
//using Repositories;
//using Unit.Tests.UnitOfWork.Infrastructure;

//namespace Unit.Tests.UnitOfWork.Repositories
//{
//    [TestFixture]
//    public class InMemoryDBConfigurationTest : BaseUnitOfWorkTest
//    {
//        public InMemoryDBConfigurationTest()
//        {
//            var options = new DbContextOptionsBuilder<DatabaseContext>()
//                .UseInMemoryDatabase("EtlContextTestDB")
//                .Options;
//        }

//        [Test]
//        public void Get_FromBlog_ListOfBlog()
//        {
            

//            using (var ctx = new DatabaseContext(options))
//            {
//                ctx.Blog.Add(new Blog { Name = "TestingFromTests" });
//                ctx.SaveChanges();
//            }

//            using (var ctx = new DatabaseContext(options))
//            {
//                Assert.That(ctx.Blog.Count(), Is.EqualTo(1));
//            }
//        }

//    }
//}
