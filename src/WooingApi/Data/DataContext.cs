using Microsoft.EntityFrameworkCore;
using WooingApi.Models;

namespace WooingApi.Data
{
    public class DataContext : DbContext
    {        
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }
        
        public DbSet<User> Users { get; set; }
    }
}