using FullAPI.Cinema.Data;

namespace FullAPI.Cinema.Models
{
    public class LimitationModel
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public bool IsDeleted { get; set; }
        public List<LimitationMovieModel>? Movies { get; set; }
    }
}
