using System.ComponentModel.DataAnnotations;

namespace quanlikhoahoc.Models
{
    public class SinhVien
    {
        [Key]
        public int SinhVienId { get; set; }

        [Required]
        public string? HoTen { get; set; } 

        
        public virtual ICollection<DangKy>? DangKys { get; set; }
    }
}
