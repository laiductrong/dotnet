using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services
{
    public interface IGiangVienService
    {
        Task<ServiceReponse<List<GetGiangVien>>> GetGiangVien();
        Task<ServiceReponse<GetGiangVien>> GetByID(int id);
        Task<ServiceReponse<List<GetGiangVien>>> AddGiangVien(AddGiangVien newGiangVien);
        Task<ServiceReponse<List<GetGiangVien>>> UpdateGiangVien(UpdateGiangVien newGiangVien);
        Task<ServiceReponse<List<GetGiangVien>>> DeleteGiangVien(int id);
    }
}