namespace FullAPI.Cinema.Data
{
    public class Role
    {
        public int RoleId { get; set; }
        public required string Description { get; set; }
        public bool IsDeleted { get; set; } = false;
        public List<Activity>? Activities { get; set; }
    }
}
