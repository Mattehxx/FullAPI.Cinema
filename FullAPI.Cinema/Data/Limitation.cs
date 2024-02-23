namespace FullAPI.Cinema.Data
{
    public class Limitation
    {
        public required int LimitationId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public bool IsDeleted { get; set; } = false;
        public List<Movie>? Movies { get; set; }
    }
}
