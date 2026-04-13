using System.ComponentModel.DataAnnotations;

namespace quanlikhoahoc.Models
{
    public class KhoaHoc
    {
        [Key]
        public int KhoaHocId { get; set; }

        [Required]
        public string? TenKhoaHoc { get; set; } 

        
        public virtual ICollection<DangKy>? DangKys { get; set; }
    }
}