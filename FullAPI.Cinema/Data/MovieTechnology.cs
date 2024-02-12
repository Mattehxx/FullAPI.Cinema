namespace FullAPI.Cinema.Data
{
    public class MovieTechnology
    {
        public required int MovieTechnologyId { get; set; }
        public required int MovieId { get; set; }
        public required int TechnologyId { get; set; }
        public required Movie Movie { get; set; }
        public required Technology Technology { get; set; }
    }
}
