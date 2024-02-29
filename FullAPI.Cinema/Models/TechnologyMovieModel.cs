namespace FullAPI.Cinema.Models
{
    public class TechnologyMovieModel
    {
        public required int Id { get; set; }
        public required string ImdbId { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required int Duration { get; set; }
        public bool IsDeleted { get; set; }
        public int? LimitationId { get; set; }
    }
}
