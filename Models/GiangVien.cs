using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class GiangVien
    {
        public int Id { get; set; }
        public string tenGV { get; set; } = string.Empty;
        public string chuyenNganh { get; set; } = string.Empty;
        public virtual Khoa khoa { get; set; }
    }
}