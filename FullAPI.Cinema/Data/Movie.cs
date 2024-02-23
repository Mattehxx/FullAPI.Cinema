namespace FullAPI.Cinema.Data
{
    public class Movie
    {
        public required int MovieId { get; set; }
        public required string ImdbId { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required int Duration { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int? LimitationId { get; set; }
        public Limitation? Limitation { get; set; }
        public List<Show>? Shows { get; set; }
        public List<Technology>? Technologies { get; set; }
    }
}
