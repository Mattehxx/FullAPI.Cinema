namespace FullAPI.Cinema.Data
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public bool IsDeleted { get; set; } = false;
        public List<Activity>? Activities { get; set; }
    }
}
