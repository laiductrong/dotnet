using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dtos.SinhVienDto
{
    public class GetSinhVien
    {
        public int Id { get; set; }
        public string tenSV { get; set; } = string.Empty;
        public bool gioiTinh { get; set; }
        public DateTime ngaySinh { get; set; }
        public string tenLop { get; set; } = string.Empty;
    }
}