using Domain.Posts.DTO;
using Repositories;

namespace TestObjects.Builders.PostBuilder
{
    public class PostBuilder
    {
        public static readonly string DefaultTitle = "Default Blog Post";
        public static readonly string DefaultContent = "Default Content";
        public static readonly Blog DefaultBlog = null;

        public long Id { get; set; }
        public string Title = DefaultTitle;
        public string Content = DefaultContent;
        public long BlogId { get; set; }
        public Blog Blog = DefaultBlog;
        
        private PostBuilder() { }

        public static PostBuilder aPost()
            => new PostBuilder();

        public PostBuilder WithTitle(string title)
        {
            this.Title = title;
            return this;
        }

        public PostBuilder WithContent(string content)
        {
            this.Content = content;
            return this;
        }

        public PostBuilder WithBlogId(long id)
        {
            this.BlogId = id;
            return this;
        }

        public PostBuilder WithBlog(Blog blog)
        {
            this.Blog = blog;
            return this;
        }

        public Post ToRepository()
            => new Post()
            {
                Id = this.Id,
                BlogId = this.BlogId,
                Blog = this.Blog,
                Content = this.Content,
                Title = this.Title
            };

        public PostDto ToDto()
            => new PostDto()
            {
                Id = this.Id,
                BlogId = this.BlogId,
                Content = this.Content,
                Title = this.Title
            };
    }
}
