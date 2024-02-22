using System.ComponentModel.DataAnnotations;

namespace FullAPI.Cinema.Models
{
    public class MovieModel
    {
        public required int Id { get; set; }
        [RegularExpression("^(tt[0-9]{7})$")]
        public required string ImdbId { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required int Duration { get; set; }
        public int? LimitationId { get; set; }
        public string? Limitation { get; set; }
        public List<ItemModel>? Techonlogies { get; set; }
        public List<MovieShowModel>? Shows { get; set; }
    }
}
