
using Apps.Models.Db;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Apps.Models.Context
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base (options)
        {
           
        }

        public DbSet<Test01> Test01 { get; set; }
    }
}
