using System.Collections.Generic;

namespace Unit.Tests.UnitOfWork.Entities
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public int Hits { get; set; }

        public List<Post> Posts { get; set; } = new List<Post>();
    }
}
