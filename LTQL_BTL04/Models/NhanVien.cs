using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LTQL_BTL04.Models
{
    [Table("NhanVien")]
    public class NhanVien
    {
        [Key]
        [StringLength(20)]
        public string MaNV { get; set; }
        [Required]
        public string TenNV { get; set; }
        [Required, MinLength(10), MaxLength(11)]
        public string SoDienThoai { get; set; }
        [Required]
        public string DiaChi { get; set; }
        [Required]
        public string NSinh { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}