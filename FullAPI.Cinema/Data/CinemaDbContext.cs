using Microsoft.EntityFrameworkCore;

namespace FullAPI.Cinema.Data
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options) { }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Limitation> Limitations { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieRoom> MovieRooms { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<Technology> Technologies { get; set; }
    }
}
