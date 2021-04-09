using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;
using System.Web;

namespace LTQL_BTL04.Models
{
    [Table("HoaDon")]
    public partial class HoaDon
    {
        public HoaDon()
        {
            CTHDs = new HashSet<CTHD>();
        }

        [Key]
        [StringLength(20)]
        public string MaHD { get; set; }
        [StringLength(20)]
        public string MaKH { get; set; }
        public string MaNV { get; set; }
        [Required]
        public DateTime NgayLapHD { get; set; }
        public virtual ICollection<CTHD> CTHDs { get; set; }
        public virtual Khachhang Khachhang { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}