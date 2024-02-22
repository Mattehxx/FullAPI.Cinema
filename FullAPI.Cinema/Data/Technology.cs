namespace FullAPI.Cinema.Data
{
    public class Technology
    {
        public required int TechnologyId { get; set; }
        public required string Name { get; set; }
        public string? TechnologyType { get; set; }
        public List<MovieRoom>? MovieRooms { get; set; }
        public List<Movie>? Movies { get; set; }
    }
}
