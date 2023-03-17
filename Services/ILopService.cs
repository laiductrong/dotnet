using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services
{
    public interface ILopService
    {
        Task<ServiceReponse<List<GetLop>>> GetLops();
        Task<ServiceReponse<GetLop>> GetLopByID(int id);
        Task<ServiceReponse<List<GetLop>>> AddLop(AddLop newLop);
        Task<ServiceReponse<List<GetLop>>> UpdateLop(UpdateLop newLop);
        Task<ServiceReponse<List<GetLop>>> DeleteLop(int id);
    }
}