using Microsoft.EntityFrameworkCore;
using Spark_Project.Models;

namespace Spark_Project.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        // Models go here

        public DbSet<Payment> Payments { get; set; }
       
    }
}
