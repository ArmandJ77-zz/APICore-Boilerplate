using System.Collections.Generic;
using Repositories.Infrastructure;
using UnitOfWork;

namespace Repositories
{
    public class Blog : BaseRepository, ISoftDeletable
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public int Hits { get; set; }
        public bool IsDeleted { get; set; }

        public List<Post> Posts { get; set; } = new List<Post>();
    }
}
