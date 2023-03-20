using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    [Keyless]
    // [PrimaryKey(nameof(sinhVienId), nameof(monHocId))]
    public class DiemThi
    {
        public SinhVien sinhVienId { get; set; }
        public MonHoc monHocId { get; set; }
        public int lanThi { get; set; }
        public float diem { get; set; } = 0;
    }
}