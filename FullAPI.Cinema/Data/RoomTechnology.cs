namespace FullAPI.Cinema.Data
{
    public class RoomTechnology
    {
        public required int RoomTechnologyId { get; set; }
        public required int MovieRoomId { get; set; }
        public required int TechnologyId { get; set; }
        public required MovieRoom MovieRoom { get; set; }
        public required Technology Technology { get; set; }
    }
}
