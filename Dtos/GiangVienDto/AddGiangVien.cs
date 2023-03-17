using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dtos.GiangVienDto
{
    public class AddGiangVien
    {
        public string tenGV { get; set; } = string.Empty;
        public string chuyenNganh { get; set; } = string.Empty;
        public int khoaId { get; set; }
    }
}