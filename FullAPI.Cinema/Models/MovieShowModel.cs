namespace FullAPI.Cinema.Models
{
    public class MovieShowModel
    {
        public required int Id { get; set; }
        public required DateTime StartTime { get; set; }
        public required DateTime EndTime { get; set; }
        public bool IsDeleted { get; set; }
        public required int MovieRoomId { get; set; }
        public required string MovieRoomName { get; set; }
    }
}
