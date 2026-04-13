using Microsoft.EntityFrameworkCore;

namespace quanlikhoahoc.Models
{
    public class ApplicationDbContext : DbContext
    {
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<KhoaHoc> KhoaHocs { get; set; }
        public DbSet<SinhVien> SinhViens { get; set; }
        public DbSet<DangKy> DangKys { get; set; }
    }
}