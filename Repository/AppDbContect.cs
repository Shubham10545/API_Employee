using Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace Repository
{
    public class AppDbContect: DbContext
    {
        public AppDbContect(DbContextOptions con) : base(con) { }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<FileUpload> FileUpload { get; set; }
       
     }
}
