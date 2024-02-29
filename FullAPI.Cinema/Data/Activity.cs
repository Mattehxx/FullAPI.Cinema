namespace FullAPI.Cinema.Data
{
    public class Activity
    {
        public required int ActivityId { get; set; }
        public required int EmployeeId { get; set; }
        public required int RoleId { get; set; }
        public required int ShowId { get; set; }
        public Employee Employee { get; set; }
        public Role Role { get; set; }
        public Show Show { get; set; }
    }
}
