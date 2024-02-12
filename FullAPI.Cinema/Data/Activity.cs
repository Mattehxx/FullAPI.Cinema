namespace FullAPI.Cinema.Data
{
    public class Activity
    {
        public required int ActivityId { get; set; }
        public required int EmployeeId { get; set; }
        public required int RoleId { get; set; }
        public required int ShowId { get; set; }
        public required Employee Employee { get; set; }
        public required Role Role { get; set; }
        public required Show Show { get; set; }
    }
}
