using Domain.Blogs.DTO;
using Integration.Tests.Infrastructure;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestObjects.Infrastructure.ControllerEndpoints;
using TestObjects.Infrastructure.Utils;
using TestObjects.ObjectMothers;
using UnitOfWork.PagedList;

namespace Integration.Tests.ControllerTests
{
    [TestFixture]
    public class BlogControllerTests : BaseIntegrationTest
    {
        public string Endpoint => "api/blog";

        [Test]
        public async Task BlogController_Insert_Id()
        {
            var createDto = BlogObjectMother
                .aDefaultBlog()
                .ToCreateDto();

            var response = await _client.PostAsJsonAsync(BlogControllerEndpoints.Create, createDto);
            var result = await response.Content.Deserialize<long>();
            Assert.That(result, Is.GreaterThan(0));
        }
            
        [Test]
        public async Task BlogController_InsertInvalidUrl_ValidationException()
        {
            var createDto = BlogObjectMother
                .aDefaultBlog()
                .WithUrl(null)
                .ToDto();
            try
            {
                var result = await _client.PostAsJsonAsync(BlogControllerEndpoints.Create, createDto);
            }
            catch (FluentValidation.ValidationException validationException)
            {
                StringAssert.Contains("Url", validationException.Message);
            }
        }

        [Test]
        public async Task BlogController_InsertInvalidTitle_ValidationException()
        {
            var createDto = BlogObjectMother
                .aDefaultBlog()
                .WithTile(null)
                .ToDto();
            try
            {
                await _client.PostAsJsonAsync(BlogControllerEndpoints.Create, createDto);
            }
            catch (FluentValidation.ValidationException validationException)
            {
                StringAssert.Contains("Title", validationException.Message);
            }
        }

        [Test]
        public async Task BlogController_Delete_IdofDeletedResult()
        {
            var blogs = await _client.GetAsync(BlogControllerEndpoints.List);
            blogs.EnsureSuccessStatusCode();
            var blogsResult = await blogs.Content.Deserialize<List<BlogDto>>();

            var response = await _client.DeleteAsync(BlogControllerEndpoints.Delete(blogsResult.FirstOrDefault().Id));
            response.EnsureSuccessStatusCode();

            var result = await response.Content.Deserialize<long>();

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public async Task BlogController_Get_Id()
        {
            var blogs = await _client.GetAsync(BlogControllerEndpoints.List);
            blogs.EnsureSuccessStatusCode();

            var blogsResult = await blogs.Content.Deserialize<List<BlogDto>>();

            var response = await _client.GetAsync(BlogControllerEndpoints.Get(blogsResult.FirstOrDefault().Id));
            response.EnsureSuccessStatusCode();

            var result = await response.Content.Deserialize<BlogDto>();

            Assert.That(result.Id, Is.EqualTo(blogsResult.FirstOrDefault().Id));
        }

        [Test]
        public async Task BlogController_Get_IPagedList()
        {
            var response = await _client.GetAsync(BlogControllerEndpoints.PagedList(2, 1));
            response.EnsureSuccessStatusCode();

            var result = await response.Content.Deserialize<PagedList<BlogDto>>();

            Assert.That(result.Items, Is.Not.Null);
            Assert.That(result.TotalCount, Is.GreaterThan(1));
            Assert.That(result.PageSize, Is.EqualTo(2));
            Assert.That(result.PageIndex, Is.EqualTo(1));
        }
    }
}
