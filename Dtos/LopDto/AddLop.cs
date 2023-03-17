using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dtos.LopDto
{
    public class AddLop
    {
        public string TenLop { get; set; } = string.Empty;
        public int khoaId { get; set; }
    }
}