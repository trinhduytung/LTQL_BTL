using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LTQL_BTL04.Models
{
    [Table("CTHD")]
    public class CTHD
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string MaHD { get; set; }
        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string MaMH { get; set; }
        [Required]
        public int SoLuong { get; set; }
        [Required]
        public float DonGia { get; set; }
        public float GiamGia { get; set; }
        public virtual HoaDon HoaDon { get; set; }
        public virtual MatHang MatHang { get; set; }
    }
}