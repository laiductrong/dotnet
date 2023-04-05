using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    // [Keyless]
    [PrimaryKey(nameof(sinhVienIdId), nameof(monHocIdId))]
    public class DiemThi
    {
        public int sinhVienIdId { get; set; }
        public int monHocIdId { get; set; }
        public int lanThi { get; set; }
        public float diem { get; set; } = 0;
    }
    // [Keyless]
    // public class DiemThi
    // {
    //     public SinhVien sinhVienId { get; set; }
    //     public MonHoc monHocId { get; set; }
    //     public int lanThi { get; set; }
    //     public float diem { get; set; } = 0;
    // }
}