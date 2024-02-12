namespace FullAPI.Cinema.Data
{
    public class Movie
    {
        public required int MovieId { get; set; }
        public required string ImdbId { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public int? LimitationId { get; set; }
        public Limitation? Limitation { get; set; }
        public List<Show>? Shows { get; set; }
        public List<MovieTechnology>? MovieTechnologies { get; set; }
    }
}
