using FullAPI.Cinema.Data;

namespace FullAPI.Cinema.Models
{
    public class TechnologyMovieRoomModel
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required int CleanTimeMins { get; set; }
        public bool IsDeleted { get; set; }
    }
}
