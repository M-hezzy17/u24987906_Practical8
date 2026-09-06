using Microsoft.EntityFrameworkCore;
using u24987906_Practical8.Models;

namespace u24987906_Practical8.Data
{
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) 
        { 
        }

        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<MaintenanceRecord> MaintenanceRecords { get; set; }
    }
}
