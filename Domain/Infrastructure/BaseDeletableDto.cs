namespace Domain.Infrastructure
{
    public class BaseDeletableDto
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
