using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using WebApplication1.Common;
using WebApplication1.Model.Entity;

namespace WebApplication1.Data
{
    public class DatabaseContext : DbContext
    {
        string connectionString = "";
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DatabaseContext()
        {
        }
        public DatabaseFacade GetDatabase()
        {
            return base.Database;
        }
         public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Visitor> Visitor { get; set; }
        public new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<Visitor>().ToTable("T_Visitor");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           if(!optionsBuilder.IsConfigured)
            {
                connectionString = Constants.ConnectionString;
                optionsBuilder.UseSqlServer(connectionString);
            }
           base.OnConfiguring(optionsBuilder);
        }
    }
}
