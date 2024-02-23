namespace FullAPI.Cinema.Data
{
    public class Technology
    {
        public required int TechnologyId { get; set; }
        public required string Name { get; set; }
        public string? TechnologyType { get; set; }
        public bool IsDeleted { get; set; } = false;
        public List<MovieRoom>? MovieRooms { get; set; }
        public List<Movie>? Movies { get; set; }
    }

    public class TechnologyJson
    {
        public string name { get; set; }
        public string type { get; set; }
    }

}
