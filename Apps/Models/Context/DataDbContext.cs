
using Apps.Models.Db;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Apps.Models.Context
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {

        }

        public DbSet<Test01> Test01 { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test01>().HasData(
                new Test01()
                {
                    Id = 1,
                    Nama = "Test01",
                    Status = 1,
                    Created = DateTime.ParseExact("2024-01-01 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture)
                },
                new Test01()
                {
                    Id = 2,
                    Nama = "Test02",
                    Status = 1,
                    Created = DateTime.ParseExact("2024-01-01 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture)
                },
                new Test01()
                {
                    Id = 3,
                    Nama = "Test03",
                    Status = 1,
                    Created = DateTime.ParseExact("2024-01-01 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture)
                },
                new Test01()
                {
                    Id = 4,
                    Nama = "Test04",
                    Status = 1,
                    Created = DateTime.ParseExact("2024-01-01 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture)
                },
                new Test01()
                {
                    Id = 5,
                    Nama = "Test05",
                    Status = 1,
                    Created = DateTime.ParseExact("2024-01-01 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture)
                },
                new Test01()
                {
                    Id = 6,
                    Nama = "Test06",
                    Status = 1,
                    Created = DateTime.ParseExact("2024-01-01 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture)
                },
                new Test01()
                {
                    Id = 7,
                    Nama = "Test07",
                    Status = 1,
                    Created = DateTime.ParseExact("2024-01-01 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture)
                },
                new Test01()
                {
                    Id = 8,
                    Nama = "Test08",
                    Status = 1,
                    Created = DateTime.ParseExact("2024-01-01 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture)
                },
                new Test01()
                {
                    Id = 9,
                    Nama = "Test09",
                    Status = 1,
                    Created = DateTime.ParseExact("2024-01-01 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture)
                },
                new Test01()
                {
                    Id = 10,
                    Nama = "Test10",
                    Status = 1,
                    Created = DateTime.ParseExact("2024-01-01 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture)
                },
                new Test01()
                {
                    Id = 11,
                    Nama = "Test11",
                    Status = 1,
                    Created = DateTime.ParseExact("2024-01-01 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture)
                },
                new Test01()
                {
                    Id = 12,
                    Nama = "Test12",
                    Status = 1,
                    Created = DateTime.ParseExact("2024-01-01 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture)
                },
                new Test01()
                {
                    Id = 13,
                    Nama = "Test13",
                    Status = 1,
                    Created = DateTime.ParseExact("2024-01-01 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture)
                },
                new Test01()
                {
                    Id = 14,
                    Nama = "Test14",
                    Status = 1,
                    Created = DateTime.ParseExact("2024-01-01 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture)
                },
                new Test01()
                {
                    Id = 15,
                    Nama = "Test15",
                    Status = 1,
                    Created = DateTime.ParseExact("2024-01-01 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture)
                },
                new Test01()
                {
                    Id = 16,
                    Nama = "Test16",
                    Status = 1,
                    Created = DateTime.ParseExact("2024-01-01 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture)
                },
                new Test01()
                {
                    Id = 17,
                    Nama = "Test17",
                    Status = 1,
                    Created = DateTime.ParseExact("2024-01-01 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture)
                },
                new Test01()
                {
                    Id = 18,
                    Nama = "Test18",
                    Status = 1,
                    Created = DateTime.ParseExact("2024-01-01 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture)
                },
                new Test01()
                {
                    Id = 19,
                    Nama = "Test19",
                    Status = 1,
                    Created = DateTime.ParseExact("2024-01-01 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture)
                },
                new Test01()
                {
                    Id = 20,
                    Nama = "Test20",
                    Status = 1,
                    Created = DateTime.ParseExact("2024-01-01 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture)
                },
                new Test01()
                {
                    Id = 21,
                    Nama = "Test21",
                    Status = 1,
                    Created = DateTime.ParseExact("2024-01-01 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture)
                },
                new Test01()
                {
                    Id = 22,
                    Nama = "Test22",
                    Status = 1,
                    Created = DateTime.ParseExact("2024-01-01 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture)
                },
                new Test01()
                {
                    Id = 23,
                    Nama = "Test23",
                    Status = 1,
                    Created = DateTime.ParseExact("2024-01-01 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture)
                },
                new Test01()
                {
                    Id = 24,
                    Nama = "Test24",
                    Status = 1,
                    Created = DateTime.ParseExact("2024-01-01 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture)
                },
                new Test01()
                {
                    Id = 25,
                    Nama = "Test25",
                    Status = 1,
                    Created = DateTime.ParseExact("2024-01-01 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture)
                }
            );
        }
    }
}
