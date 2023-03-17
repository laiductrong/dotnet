using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services
{
    public class KhoaService : IKhoaService
    {
        private readonly IMapper _imapper;
        private readonly DataContext _dataContext;

        public KhoaService(IMapper mapper, DataContext dataContext)
        {
            _imapper = mapper;
            _dataContext = dataContext;
        }
        public async Task<ServiceReponse<List<GetKhoa>>> AddKHoa(AddKhoa newKhoa)
        {
            var addNewKhoa = new Khoa();
            addNewKhoa.Id = 0;
            addNewKhoa.tenKhoa = newKhoa.tenKhoa;
            var serviceReponse = new ServiceReponse<List<GetKhoa>>();
            await _dataContext.Khoas.AddAsync(addNewKhoa);
            await _dataContext.SaveChangesAsync();
            // //get list
            var khoas = await _dataContext.Khoas.ToListAsync();
            //convert to list to push in serviceReponse.Data
            serviceReponse.Data = khoas.Select(x => _imapper.Map<GetKhoa>(x)).ToList();
            serviceReponse.Message = "add khoa success";
            return serviceReponse;
        }

        public async Task<ServiceReponse<List<GetKhoa>>> DeleteKhoa(int id)
        {
            var serviceReponse = new ServiceReponse<List<GetKhoa>>();
            try
            {
                var khoaDelete = await _dataContext.Khoas.FirstOrDefaultAsync(x => x.Id == id);
                if (khoaDelete is not null)
                {
                    _dataContext.Khoas.Remove(khoaDelete);
                    await _dataContext.SaveChangesAsync();
                    serviceReponse.Data = (await _dataContext.Khoas.ToArrayAsync()).Select(x => _imapper.Map<GetKhoa>(x)).ToList();
                    serviceReponse.Message = "Delete Khoa " + id + " success";
                    return serviceReponse;
                }
                else
                {
                    serviceReponse.Data = null;
                    serviceReponse.Message = "Delete Khoa " + id + " fail";
                    serviceReponse.Success = false;
                    return serviceReponse;
                }

            }
            catch (Exception e)
            {
                serviceReponse.Data = null;
                serviceReponse.Message = e.Message;
            }
            return serviceReponse;
        }

        public async Task<ServiceReponse<GetKhoa>> GetByID(int id)
        {
            var serviceReponse = new ServiceReponse<GetKhoa>();
            try
            {
                var khoa = await _dataContext.Khoas.FirstOrDefaultAsync(x => x.Id == id);
                if (khoa is not null)
                {
                    serviceReponse.Data = _imapper.Map<GetKhoa>(khoa);
                    serviceReponse.Message = "find khoa id = " + id + "success";
                    return serviceReponse;
                }
                else
                {
                    serviceReponse.Data = null;
                    serviceReponse.Message = "find khoa id = " + id + "fail";
                    serviceReponse.Success = false;
                }
            }
            catch (Exception e)
            {
                serviceReponse.Data = null;
                serviceReponse.Message = e.Message;
                serviceReponse.Success = false;
            }
            return serviceReponse;
        }

        public async Task<ServiceReponse<List<GetKhoa>>> getList()
        {
            var serviceReponse = new ServiceReponse<List<GetKhoa>>();
            serviceReponse.Data = ((await _dataContext.Khoas.ToListAsync()).Select(x => _imapper.Map<GetKhoa>(x)).ToList());
            serviceReponse.Message = "get List Khoa success";
            return serviceReponse;
        }

        public async Task<ServiceReponse<GetKhoa>> UpdateKhoa(UpdateKhoa newKhoa)
        {
            var khoa = await _dataContext.Khoas.FirstOrDefaultAsync(x => x.Id == newKhoa.Id);
            var serviceReponse = new ServiceReponse<GetKhoa>();
            try
            {
                if(khoa is null)
                {
                    throw new Exception("charater with id" + newKhoa.Id + " not foud");
                }
                khoa.tenKhoa = newKhoa.tenKhoa;
                await _dataContext.SaveChangesAsync();
                serviceReponse.Message = " update success";
                serviceReponse.Data = _imapper.Map<GetKhoa>(khoa);
            }
            catch(Exception e)
            {
                serviceReponse.Data = null;
                serviceReponse.Message = e.Message;
            }
            return serviceReponse;
        }
    }
}