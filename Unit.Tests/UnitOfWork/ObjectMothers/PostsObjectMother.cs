using Unit.Tests.UnitOfWork.Entities;

namespace Unit.Tests.UnitOfWork.ObjectMothers
{
    public static class PostsObjectMother
    {
        public static Post Post  => new Post
        {
            Title = "How to find qwerty?",
            Content = "qwerty here it is",
        };
    }
}
