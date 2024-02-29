using FullAPI.Cinema.Data;

namespace FullAPI.Cinema.Models
{
    public class RoleActivityModel
    {
        public required int Id { get; set; }
        public required int EmployeeId { get; set; }
        public required string EmployeeName { get; set; }
        public required string EmployeeSurname { get; set; }
        public required int ShowId { get; set; }
        public required DateTime ShowStartTime { get; set; }
        public required DateTime ShowEndTime { get; set; }
        public required int MovieRoomId { get; set; }
        public required string MovieRoomName { get; set; }
    }
}
