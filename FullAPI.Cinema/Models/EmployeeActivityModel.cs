using FullAPI.Cinema.Data;

namespace FullAPI.Cinema.Models
{
    public class EmployeeActivityModel
    {
        public required int ActivityId { get; set; }
        public required int RoleId { get; set; }
        public required string RoleName { get; set; }
        public required int ShowId { get; set; }
        public DateTime ShowStartTime { get; set; }
        public DateTime ShowEndTime { get; set; }
        public int ShowRoomId { get; set; }
        public required string ShowRoomName { get; set; }
    }
}
