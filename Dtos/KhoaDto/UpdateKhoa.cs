using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dtos.KhoaDto
{
    public class UpdateKhoa
    {
        public int Id { get; set; }
        public string tenKhoa { get; set; } = string.Empty;
    }
}