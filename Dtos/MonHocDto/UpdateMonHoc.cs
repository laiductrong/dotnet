using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dtos.MonHocDto
{
    public class UpdateMonHoc
    {
        public int Id { get; set; }
        public string tenMH { get; set; } = string.Empty;
        public int soTiet { get; set; }
    }
}