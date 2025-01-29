using Microsoft.EntityFrameworkCore;
using WebApp2.DAL.Models;

namespace WebApp2.DAL.Data
{
    public class AccountingDbContext : DbContext
    {
        public AccountingDbContext(DbContextOptions options) : base(options)

        {

        }



        public DbSet<Employee> Employees { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Department> Departments { get; set; }

    }
}
