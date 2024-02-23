using FullAPI.Cinema.Data;

namespace FullAPI.Cinema.Models
{
    public class MovieRoomModel
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required int CleanTimeMins { get; set; }
        public bool IsDeleted { get; set; }
        public List<ShowModel>? Shows { get; set; }
        public List<Technology>? Technologies { get; set; }
    }
}
