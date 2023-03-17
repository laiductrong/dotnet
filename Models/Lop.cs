using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Lop
    {
        public int Id { get; set; }
        public string TenLop { get; set; } = string.Empty;
        public virtual Khoa khoa { get; set; }
    }
}