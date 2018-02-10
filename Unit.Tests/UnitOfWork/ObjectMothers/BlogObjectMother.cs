using System.Collections.Generic;
using Unit.Tests.UnitOfWork.Entities;
using Unit.Tests.UnitOfWork.ObjectMothers;

namespace Unit.Tests.UnitOFWork.ObjectMothers
{
    public static class BlogObjectMother
    {
        public static List<Blog> GetBlogs()
            => new List<Blog>
            {
                new Blog{Title = "QWERTY", Hits = 7, Posts = new List<Post>{ new Post { Title="The Days of QWERTY",Content="Lorem Ipsum"} } },
                new Blog{Title = "ASDF", Hits = 2,Posts = new List<Post>{ new Post { Title="ASDF for the win!",Content="asdf has arrived"} } },
                new Blog{Title = "ASDF", Hits = 1,Posts = new List<Post>{ new Post { Title="ASDF for the win!",Content="asdf has arrived"} } },
                new Blog{Title = "ASDF", Hits = 2, Posts = new List<Post>{ new Post { Title="ASDF for the win!",Content="asdf has arrived"} } },
                new Blog{Title = "QWERTY", Hits = 7,Posts = new List<Post>{ new Post { Title="The Days of QWERTY",Content="Lorem Ipsum"} } },
                new Blog{Title = "QWERTY", Hits = 1,Posts = new List<Post>{ new Post { Title="QWERTY For the win!",Content="Lorem Ipsum"} } },
                new Blog{Title = "QWERTY", Hits = 55,Posts = new List<Post>{ new Post { Title= "QWERTY For the win!", Content="Lorem Ipsum"} } },
                new Blog{Title = "ASDF", Hits = 1, Posts = new List<Post>{ new Post { Title="ASDF for the win!",Content="asdf has arrived"} } },
                new Blog{Title = "QWERTY", Hits = 7,Posts = new List<Post>{ new Post { Title= "QWERTY For the win!", Content="Lorem Ipsum"} } },
                new Blog{Title = "ASDF", Hits = 2, Posts = new List<Post>{ new Post { Title="ASDF for the win!",Content="asdf has arrived"} } },
                new Blog{Title = "QWERTY", Hits = 7,Posts = new List<Post>{ new Post { Title= "QWERTY For the win!", Content="Lorem Ipsum"} } },
                new Blog{Title = "ASDF", Hits = 9, Posts = new List<Post>{ new Post { Title="ASDF for the win!",Content="asdf has arrived"} } },
                new Blog{Title = "QWERTY", Hits = 3,Posts = new List<Post>{ new Post { Title="The Days of QWERTY",Content="Lorem Ipsum"} } },
                new Blog{Title = "ASDF", Hits = 5, Posts = new List<Post>{ new Post { Title="ASDF for the win!",Content="asdf has arrived"} } },
                new Blog{Title = "QWERTY", Hits = 6,Posts = new List<Post>{ new Post { Title= "QWERTY For the win!", Content="Lorem Ipsum"} } },
                new Blog{Title = "ASDF", Hits = 1, Posts = new List<Post>{ new Post { Title="ASDF for the win!",Content="asdf has arrived"} } },
                new Blog{Title = "QWERTY", Hits = 2,Posts = new List<Post>{ new Post { Title= "QWERTY For the win!", Content="Lorem Ipsum"} } },
                new Blog{Title = "ASDF", Hits = 2, Posts = new List<Post>{ new Post { Title="ASDF for the win!",Content="asdf has arrived"} } },
                new Blog{Title = "QWERTY", Hits = 3,Posts = new List<Post>{ new Post { Title="The Days of QWERTY",Content="Lorem Ipsum"} } },
                new Blog{Title = "ASDF", Hits = 2, Posts = new List<Post>{ new Post { Title="ASDF for the win!",Content="asdf has arrived"} } },
                new Blog{Title = "QWERTY", Hits = 6,Posts = new List<Post>{ new Post { Title="The Days of QWERTY",Content="Lorem Ipsum"} } },
                new Blog{Title = "ASDF", Hits = 1, Posts = new List<Post>{ new Post { Title="ASDF for the win!",Content="asdf has arrived"} } },
            };

        public static Blog NewBlog => new Blog
        {
            Title = "New Blog",
            Hits = 24,
            Url = "http://qwerty.com/Testing Insert Blog",
            Posts = new List<Post> { PostsObjectMother.Post }
        };

        public static Blog BlogA => new Blog
        {
            Title = "BlogA",
            Hits = 3,
            Url = "http://qwerty.com/bloga",
            Posts = new List<Post> { PostsObjectMother.Post }
        };

        public static Blog BlogB => new Blog
        {
            Title = "BlogB",
            Hits = 55,
            Url = "http://qwerty.com/blogb",
            Posts = new List<Post> { PostsObjectMother.Post }
        };

        public static Blog NewBlogNoPosts => new Blog
        {
            Title = "New Blog",
            Hits = 24,
            Posts = null,
            Url = "http://qwerty.com/Testing Insert Blog"

        };
    }
}
