using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Khoa
    {
        public int Id { get; set; }
        public String tenKhoa { get; set; } = string.Empty;
        // public ICollection<GiangVien> GiangViens { get; set; }
    }
}