using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class SinhVien
    {
        public int Id { get; set; }
        public string tenSV { get; set; } = string.Empty;
        public bool gioiTinh { get; set; } = true;
        public DateTime ngaySinh { get; set; }     
        public virtual Lop lop { get; set; }
    }
}