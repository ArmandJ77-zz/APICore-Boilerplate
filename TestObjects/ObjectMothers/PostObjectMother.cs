using Repositories;
using System.Collections.Generic;
using TestObjects.Builders.PostBuilder;

namespace TestObjects.ObjectMothers
{
    public sealed class PostObjectMother
    {
        public static PostBuilder aDefaultPost()
            => PostBuilder.aPost();

        public static List<Post> aDefaultPostList()
            => new List<Post>
            {
                PostBuilder.aPost()
                    .WithTitle("Post 1")
                    .ToRepository(),
                PostBuilder.aPost()
                    .WithTitle("Post 2")
                    .ToRepository(),
                PostBuilder.aPost()
                    .WithTitle("Post 3")
                    .ToRepository(),
                PostBuilder.aPost()
                    .WithTitle("Post 4")
                    .ToRepository(),
                PostBuilder.aPost()
                    .WithTitle("Post 5")
                    .ToRepository(),
            };
    }
}
