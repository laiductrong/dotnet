using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services
{
    public interface IMonHocService
    {
        Task<ServiceReponse<List<GetMonHoc>>> GetMonHocs();
        Task<ServiceReponse<GetMonHoc>> GetMonHoc(int id);
        Task<ServiceReponse<List<GetMonHoc>>> AddMonHoc(AddMonHoc addMonHoc);
        Task<ServiceReponse<List<GetMonHoc>>> UpdateMonHoc(UpdateMonHoc updateMonHoc);
        Task<ServiceReponse<List<GetMonHoc>>> DeleteMonHoc(int id);
    }
}