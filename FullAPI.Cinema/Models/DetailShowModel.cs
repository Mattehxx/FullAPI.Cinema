using FullAPI.Cinema.Data;

namespace FullAPI.Cinema.Models
{
    public class DetailShowModel
    {
        public required int Id { get; set; }
        public required float Price { get; set; }
        public required DateTime StartTime { get; set; }
        public required DateTime EndTime { get; set; }
        public required int MovieRoomId { get; set; }
        public required string MovieRoomName { get; set; }
        public required int MovieId { get; set; }
        public required string MovieName { get; set; }
        public int? LimitationId { get; set; }
        public string? LimitationDescription { get; set; }
        public List<ShowActivityModel>? Activities { get; set; }
    }
}
