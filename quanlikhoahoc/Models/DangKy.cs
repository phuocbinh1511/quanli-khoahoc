using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace quanlikhoahoc.Models
{
    public class DangKy
    {
        [Key]
        public int DangKyId { get; set; }

        public int SinhVienId { get; set; }
        public int KhoaHocId { get; set; }

    
        [ForeignKey("SinhVienId")]
        public virtual SinhVien? SinhVien { get; set; }

        [ForeignKey("KhoaHocId")]
        public virtual KhoaHoc? KhoaHoc { get; set; }
    }
}