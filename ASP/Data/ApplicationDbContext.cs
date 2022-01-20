using ASP.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.DataAccess
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } //mengambil data dari sqlserver, jan lupa add di .cs
    }
}
