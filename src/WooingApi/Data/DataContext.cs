using Microsoft.EntityFrameworkCore;

namespace WooingApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}