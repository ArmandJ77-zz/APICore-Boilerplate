using System.Collections.Generic;
using Domain.Blogs.DTO;
using Integration.Tests.Infrastructure;
using Integration.Tests.Infrastructure.Utils;
using NUnit.Framework;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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
                .ToDto();

            var response = await _client.PostAsJsonAsync($"{Endpoint}/Create", createDto);
            var result = await response.Content.Deserialize<long>();
            Assert.That(result, Is.GreaterThan(0));
        }

        [Test]
        public async Task BlogController_Delete_IdofDeletedResult()
        {
            var response = await _client.DeleteAsync("/api/blog/delete?id=1");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.Deserialize<long>();

            Assert.That(result, Is.EqualTo(1));

            var getResponse = await _client.GetAsync("/api/blog/Get?id=1");

            Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public async Task BlogController_Get_Id()
        {
            var blogs = await _client.GetAsync("/api/blog/List");
            blogs.EnsureSuccessStatusCode();

            var blogsResult = await blogs.Content.Deserialize<List<BlogDto>>();

            var response = await _client.GetAsync($"/api/blog/Get?id={blogsResult.FirstOrDefault().Id}");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.Deserialize<BlogDto>();

            Assert.That(result.Id, Is.EqualTo(blogsResult.FirstOrDefault().Id));
        }

        [Test]
        public async Task BlogController_GetDefault_IPagedList()
        {
            var response = await _client.GetAsync("/api/blog/PagedList");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.Deserialize<PagedList<BlogDto>>();

            Assert.That(result.Items.Count, Is.GreaterThan(1));
            Assert.That(result.TotalCount, Is.GreaterThan(1));
            Assert.That(result.PageSize, Is.GreaterThan(1));
        }

        [Test]
        public async Task BlogController_Get_IPagedList()
        {
            var response = await _client.GetAsync("/api/blog/PagedList?pageSize=2&pageIndex=1");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.Deserialize<PagedList<BlogDto>>();

            Assert.That(result.Items, Is.Not.Null);
            Assert.That(result.TotalCount, Is.GreaterThan(1));
            Assert.That(result.PageSize, Is.EqualTo(2));
            Assert.That(result.PageIndex, Is.EqualTo(1));
        }
    }
}
