using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;
using System.Web;

namespace LTQL_BTL04.Models
{
    
    [Table("MatHang")]
    public class MatHang
    {
        [Key]
        [StringLength(20)]
        public string MaMH { get; set; }
        [Required]
        public string TenMH { get; set; }
        public float DonGia { get; set; }
        
        public string HinhAnh { get; set; }
        public string TenLoaiMH { get; set; }
        public virtual LoaiHang LoaiHang { get; set; }


        public virtual ICollection<CTHD> CTHDs { get; set; }
    }
}