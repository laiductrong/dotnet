using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dtos.DiemThiDto
{
    public class GetDiemThi
    {
        public string tenSinhVien { get; set; }
        public string tenMonHoc { get; set; }
        public int lanThi { get; set; }
        public float diem { get; set; } = 0;
    }
}