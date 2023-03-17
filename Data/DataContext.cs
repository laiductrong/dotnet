using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Character> Characters => Set<Character>();
        public DbSet<Khoa> Khoas => Set<Khoa>();
        public DbSet<GiangVien> GiangViens => Set<GiangVien>();
        public DbSet<Lop> Lops => Set<Lop>();
    }
}