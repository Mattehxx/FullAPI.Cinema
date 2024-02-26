namespace FullAPI.Cinema.Models
{
    public class ShowRoomModel
    {
        public required int Id { get; set; }
        public required float Price { get; set; }
        public required DateTime StartTime { get; set; }
        public required DateTime EndTime { get; set; }
        public required int MovieId { get; set; }
        public required int MovieDuration { get; set; }
        public required bool IsDeleted { get; set; }
    }
}
