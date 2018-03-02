using System.Collections.Generic;
using Repositories;
using TestObjects.Builders.BlogBuilders;
using TestObjects.Builders.PostBuilder;

namespace TestObjects.ObjectMothers
{
    public sealed class BlogObjectMother
    {
        public static BlogBuilder aDefaultBlog()
            => BlogBuilder.aBlog();

        public static BlogBuilder aDefaultBlogWithPost()
            => BlogBuilder.aBlog().WithPosts(new List<PostBuilder>
            {
                PostBuilder.aPost()
                    .WithTitle("Post 1"),
                PostBuilder.aPost()
                    .WithTitle("Post 2"),
                PostBuilder.aPost()
                    .WithTitle("Post 3"),
                PostBuilder.aPost()
                    .WithTitle("Post 4"),
                PostBuilder.aPost()
                    .WithTitle("Post 5"),
            });

        public static List<Blog> aListOfBlogsAndPosts(string name = "QWERTY")
        {
            var result = new List<Blog>();

            for (int i = 0; i < 10; i++)
            {
                result.Add(BlogBuilder
                    .aBlog()
                    .WithHits(i)
                    .WithTile(name)
                    .WithPosts(new List<PostBuilder>
                        {
                            PostBuilder.aPost()
                                .WithTitle("Post 1"),
                            PostBuilder.aPost()
                                .WithTitle("Post 2"),
                            PostBuilder.aPost()
                                .WithTitle("Post 3"),
                            PostBuilder.aPost()
                                .WithTitle("Post 4"),
                            PostBuilder.aPost()
                                .WithTitle("Post 5"),
                        })
                    .WithHits(i)
                    .ToRepository()
                        );
            }

            return result;
        }
    }
}
