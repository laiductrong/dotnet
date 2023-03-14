using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services
{
    public interface IKhoaService
    {
        Task<ServiceReponse<List<GetKhoa>>> getList();
        Task<ServiceReponse<GetKhoa>> GetByID(int id);
        Task<ServiceReponse<List<GetKhoa>>> AddKHoa(AddKhoa newKhoa);
        Task<ServiceReponse<GetKhoa>>  UpdateKhoa(UpdateKhoa newKhoa);
        Task<ServiceReponse<List<GetKhoa>>> DeleteKhoa (int id);
    }
}