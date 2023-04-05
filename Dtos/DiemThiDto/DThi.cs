using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dtos.DiemThiDto
{
    public class DThi
    {
        public SinhVien tenSinhVien { get; set; }
        public MonHoc tenMonHoc { get; set; }
        public int lanThi { get; set; }
        public float diem { get; set; } = 0;
    }
}