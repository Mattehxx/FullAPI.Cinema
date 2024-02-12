namespace FullAPI.Cinema.Data
{
    public class Technology
    {
        public required int TechnologyId { get; set; }
        public required string Name { get; set; }
        public List<RoomTechnology>? RoomTechnologies { get; set; }
        public List<MovieTechnology>? MovieTechnologies { get; set; }
    }
}
