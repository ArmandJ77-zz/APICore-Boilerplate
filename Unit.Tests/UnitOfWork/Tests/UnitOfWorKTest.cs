using System.Diagnostics;
using System.Threading;
using NUnit.Framework;
using Unit.Tests.UnitOfWork.Entities;
using Unit.Tests.UnitOfWork.Infrastructure;
using Unit.Tests.UnitOFWork.ObjectMothers;

namespace Unit.Tests.UnitOfWork.Tests
{
    public class UnitOfWorKTest : BaseUnitOfWork
    {
        [Test]
        public void UnitOfWork_TestCase_ExpectedResult()
        {
            var watch = new Stopwatch();
            watch.Start();

            for (int i = 0; i < 100000; i++)
            {
                var blogA = BlogObjectMother.BlogA;
                UnitOfWork.GetRepository<Blog>().Insert(blogA);
                UnitOfWork.SaveChanges();

            }
            
            watch.Stop();
            var endTime = watch.Elapsed;
        }

        //[Test]
        //public void UnitOfWork_TestCase_ExpectedResult()
        //{
        //    var blogA = BlogObjectMother.BlogA;
        //    var blogB = BlogObjectMother.BlogB;

        //    UnitOfWork.GetRepository<Blog>().Insert(blogA);
        //    UnitOfWork.GetRepository<Blog>().Insert(blogB);
        //    UnitOfWork.SaveChanges();

        //    var resultA = UnitOfWork.GetRepository<Blog>().Find(blogA.BlogId);
        //    var resultB = UnitOfWork.GetRepository<Blog>().Find(blogB.BlogId);

        //    Assert.That(resultA.BlogId, Is.EqualTo(blogA.BlogId));
        //    Assert.That(resultB.BlogId, Is.EqualTo(blogB.BlogId));
        //}
    }
}
