namespace FullAPI.Cinema.Data
{
    public class MovieRoom
    {
        public required int MovieRoomId { get; set; }
        public required string Name { get; set; }
        public required int CleanTimeMins { get; set; }
        public List<Show>? Shows { get; set; }
        public List<Technology>? Technologies { get; set; }
    }
}
