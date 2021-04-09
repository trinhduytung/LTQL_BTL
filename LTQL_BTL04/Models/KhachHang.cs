using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LTQL_BTL04.Models
{
    [Table("KhachHang")]
    public partial class Khachhang
    {

        public Khachhang()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        [StringLength(10)]
        public string MaKH { get; set; }

        [StringLength(50)]
        public string TenKH { get; set; }

        [StringLength(100)]
        public string DiaChi { get; set; }

        [Required, MinLength(10), MaxLength(11)]
        public string DienThoai { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }
        public string Role { get; set; }

        [Required]
        public string password { get; set; }
        [NotMapped]
        [Required]
        [System.ComponentModel.DataAnnotations.Compare("password")]
        public string confirm_password { get; set; }


        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}