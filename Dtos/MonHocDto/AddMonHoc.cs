using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dtos.MonHocDto
{
    public class AddMonHoc
    {
        public string tenMH { get; set; } = string.Empty;
        public int soTiet { get; set; }
    }
}