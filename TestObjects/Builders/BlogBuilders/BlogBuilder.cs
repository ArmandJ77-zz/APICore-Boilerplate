using Repositories;
using System.Collections.Generic;
using Domain.Blogs.DTO;

namespace TestObjects.Builders.BlogBuilders
{
    public class BlogBuilder
    {
        
        private static readonly string DefaultUrl = "http://qwerty.com";
        private static readonly string DefaultTitle = "QWERTY";
        private static readonly int DefaultHits = 7;
        private static readonly bool DefaultIsDeleted = false;
        private static List<PostBuilder.PostBuilder> DefaultPosts = new List<PostBuilder.PostBuilder>();

        public long Id { get; set; }
        public string Url = DefaultUrl;
        public string Title = DefaultTitle;
        public int Hits = DefaultHits;
        public bool IsDeleted = DefaultIsDeleted;
        public List<PostBuilder.PostBuilder> Posts = DefaultPosts;

        private BlogBuilder() { }

        public static BlogBuilder aBlog()
            => new BlogBuilder();

        public BlogBuilder WithId(long id)
        {
            this.Id = id;
            return this;
        }

        public BlogBuilder WithUrl(string url)
        {
            this.Url = url;
            return this;
        }

        public BlogBuilder WithTile(string title)
        {
            this.Title = title;
            return this;
        }

        public BlogBuilder WithHits(int hits)
        {
            this.Hits = hits;
            return this;
        }

        public BlogBuilder WithIsDeleted(bool isDeleted)
        {
            this.IsDeleted = isDeleted;
            return this;
        }

        public BlogBuilder WithPosts(List<PostBuilder.PostBuilder> posts)
        {
            this.Posts = posts;
            return this;
        }

        public Blog ToRepository()
        {
            var blog = new Blog()
            {
                Title = this.Title,
                Id = this.Id,
                Hits = this.Hits,
                IsDeleted = this.IsDeleted,
                Url = this.Url
            };

            this.Posts.ForEach(x => blog.Posts.Add(x.ToRepository()));

            return blog;
        }

        public BlogDto ToDto()
        {
            var blog = new BlogDto()
            {
                Title = this.Title,
                Id = this.Id,
                Hits = this.Hits,
                Url = this.Url
            };

            this.Posts.ForEach(x => blog.Posts.Add(x.ToDto()));

            return blog;
        }
    }
}
