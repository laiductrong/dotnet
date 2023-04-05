using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services
{
    public interface IDiemThiService
    {
        Task<ServiceReponse<List<GetDiemThi>>> GetDiemThis();
        Task<ServiceReponse<List<GetDiemThi>>> GetDiemThi(int idSV, int idMH);
        Task<ServiceReponse<List<GetDiemThi>>> GetDiemThiBySV(int idSV);
        Task<ServiceReponse<List<GetDiemThi>>> GetDiemThiByMH(int idMH);
        Task<ServiceReponse<List<GetDiemThi>>> AddDiemThi(AddDiemThi addDiemThi);
        Task<ServiceReponse<List<GetDiemThi>>> DeleteDiemThi(UpdateDiemThi updateDiemThi);
        Task<ServiceReponse<List<GetDiemThi>>> UpdateDiemThi(UpdateDiemThi updateDiemThi);
    }
}