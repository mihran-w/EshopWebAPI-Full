using EshopWeb.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace EshopWebAPI.Context
{
    public class MyDbContext:DbContext
    {

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        public DbSet<Users> users { get; set; }
        public DbSet<Product> products { get; set; }
    }
}
