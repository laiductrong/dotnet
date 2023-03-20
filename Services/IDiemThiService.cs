using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services
{
    public interface IDiemThiService
    {
        Task<ServiceReponse<List<GetDiemThi>>> GetDiemThis();
        // Task<ServiceReponse<GetDiemThi>> GetDiemThi(int idSV, int idMH);
        // Task<ServiceReponse<List<DiemThi>>> GetDiemThiBySV(int idSv);
        // Task<ServiceReponse<List<DiemThi>>> GetDiemThiByMH(int idMH);
        Task<ServiceReponse<List<GetDiemThi>>> AddDiemThi(AddDiemThi addDiemThi);
        // Task<ServiceReponse<List<DiemThi>>> DeleteDiemThi(int idSV, int idMH);
        // Task<ServiceReponse<List<DiemThi>>> UpdateDiemThi(int idSV, int idMH);
        // Task<ServiceReponse<List<DiemThi>>> DeleteDiemThi(int idSV, int idMH);
    }
}