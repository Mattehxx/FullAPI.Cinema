namespace FullAPI.Cinema.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public bool IsDeleted { get; set; }
        public List<EmployeeActivityModel>? Activities { get; set; }
    }
}
