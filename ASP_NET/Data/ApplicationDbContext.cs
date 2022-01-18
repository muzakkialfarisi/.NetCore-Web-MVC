using ASP_NET.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } //mengambil data dari sqlserver, jan lupa add di .cs
    }
}
