namespace FullAPI.Cinema.Models
{
    public class RoleModel
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public bool IsDeleted { get; set; }
        public List<RoleActivityModel>? Activities { get; set; }
    }
}
