using FullAPI.Cinema.Data;

namespace FullAPI.Cinema.Models
{
    public class ShowActivityModel
    {
        public required int ActivityId { get; set; }
        public required int EmployeeId { get; set; }
        public required string EmployeeName { get; set; }
        public required string EmployeeSurname { get; set; }
        public required int RoleId { get; set; }
        public required string RoleName { get; set; }
    }
}
