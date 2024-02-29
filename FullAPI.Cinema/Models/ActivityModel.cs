using FullAPI.Cinema.Data;

namespace FullAPI.Cinema.Models
{
    public class ActivityModel
    {
        public required int Id { get; set; }
        public required int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? EmployeeSurname { get; set; }
        public required int RoleId { get; set; }
        public string? RoleDescription { get; set; }
        public required int ShowId { get; set; }
        public DateTime? ShowStartTime { get; set; }
        public DateTime? ShowEndTime { get; set; }
        public required int MovieRoomId { get; set; }
        public string? MovieRoomName { get; set; }
    }
}
