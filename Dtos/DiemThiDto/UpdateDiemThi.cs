using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dtos.DiemThiDto
{
    public class UpdateDiemThi
    {
        public int sinhVienId { get; set; }
        public int monHocId { get; set; }
        public int lanThi { get; set; }
        public float diem { get; set; } = 0;
    }
}