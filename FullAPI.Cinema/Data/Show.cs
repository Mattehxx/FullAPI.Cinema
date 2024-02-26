namespace FullAPI.Cinema.Data
{
    public class Show
    {
        public required int ShowId { get; set; }
        public required float Price { get; set; }
        public required DateTime StartTime { get; set; }
        public required DateTime EndTime { get; set; }
        public bool IsDeleted { get; set; } = false;
        public required int MovieRoomId { get; set; }
        public required int MovieId { get; set; }
        public MovieRoom MovieRoom { get; set; }
        public Movie Movie { get; set; }
        public List<Activity>? Activities { get; set; }
    }
}
