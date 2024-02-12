namespace FullAPI.Cinema.Data
{
    public class Limitation
    {
        public required int LimitationId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public List<Movie>? Movies { get; set; }
    }
}
