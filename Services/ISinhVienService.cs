using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services
{
    public interface ISinhVienService
    {
        Task<ServiceReponse<List<GetSinhVien>>> GetSinhViens();
        Task<ServiceReponse<GetSinhVien>> GetSinhVien(int id);
        Task<ServiceReponse<List<GetSinhVien>>> AddSinhVien(AddSinhVien addSinhVien);
        Task<ServiceReponse<List<GetSinhVien>>> DeleteSinhVien(int id);
        Task<ServiceReponse<List<GetSinhVien>>> UpdateSinhVien(UpdateSinhVien updateSinhVine);
    }
}