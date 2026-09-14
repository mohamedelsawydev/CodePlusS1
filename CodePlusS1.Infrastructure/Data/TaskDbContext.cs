
using CodePlusS1.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CodePlusS1.Infrastructure.Data
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        //write onmodelconfigurations










    }
}
