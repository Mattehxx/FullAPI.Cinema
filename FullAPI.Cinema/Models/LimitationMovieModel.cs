using FullAPI.Cinema.Data;

namespace FullAPI.Cinema.Models
{
    public class LimitationMovieModel
    {
        public required int Id { get; set; }
        public required string ImdbId { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required int Duration { get; set; }
        public bool IsDeleted { get; set; }
    }
}
