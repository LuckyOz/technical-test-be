
using Microsoft.EntityFrameworkCore;

namespace Apps.Models.Context
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base (options)
        {
            
        }
    }
}
