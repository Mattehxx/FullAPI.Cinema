using FullAPI.Cinema.Data;

namespace FullAPI.Cinema.Models
{
    public class TechnologyModel
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public string? TechnologyType { get; set; }
        public bool IsDeleted { get; set; }
        public List<TechnologyMovieRoomModel>? MovieRooms { get; set; }
        public List<TechnologyMovieModel>? Movies { get; set; }
    }
}
