using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dtos.LopDto
{
    public class UpdateLop
    {
        public int Id { get; set; }
        public string TenLop { get; set; } = string.Empty;
        public int khoaId { get; set; }
    }
}