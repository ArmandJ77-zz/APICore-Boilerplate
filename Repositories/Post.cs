using Repositories.Infrastructure;

namespace Repositories
{
    public class Post : BaseRepository
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public long BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
