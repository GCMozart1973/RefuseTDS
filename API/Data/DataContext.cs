using Api.Data.Entities;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User>  Users {get;set;}
        public DbSet<RefuseCompany> RefuseCompany { get; set; }
        public DbSet<RefuseLocation> RefuseLocation { get; set; }
        public DbSet<RefuseRegion> RefuseRegion { get; set; }
    }
}