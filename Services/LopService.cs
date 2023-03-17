using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services
{
    public class LopService : ILopService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _imapper;
        public LopService(DataContext dataContext, IMapper imapper)
        {
            _dataContext = dataContext;
            _imapper = imapper;
        }
        public async Task<ServiceReponse<List<GetLop>>> AddLop(AddLop newLop)
        {
            var serviceReponse = new ServiceReponse<List<GetLop>>();
            var checkKhoa = await _dataContext.Khoas.FirstOrDefaultAsync(x => x.Id == newLop.khoaId);
            try
            {
                if (checkKhoa is not null)
                {
                    var lop = new Lop();
                    lop.Id = 0;
                    lop.TenLop = newLop.TenLop;
                    lop.khoa = checkKhoa;
                    await _dataContext.AddAsync(lop);
                    await _dataContext.SaveChangesAsync();
                    serviceReponse.Data = (await _dataContext.Lops.Include(x=> x.khoa).ToListAsync()).Select(x => _imapper.Map<GetLop>(x)).ToList();
                    serviceReponse.Message = "Add Lop success";
                }
                else
                {
                    serviceReponse.Data = null;
                    serviceReponse.Message ="don't have Khoa with ID = "+ newLop.khoaId;
                    serviceReponse.Success = false;
                }
            }
            catch (System.Exception)
            {

                throw;
            }
            return serviceReponse;
        }

        public async Task<ServiceReponse<List<GetLop>>> DeleteLop(int id)
        {
            var serviceReponse = new ServiceReponse<List<GetLop>>();
            var data = await _dataContext.Lops.FirstOrDefaultAsync(x => x.Id == id);
            if (data is not null)
            {
                _dataContext.Lops.Remove(data);
                await _dataContext.SaveChangesAsync();
                serviceReponse.Data = (await _dataContext.Lops.Include(x => x.khoa).ToListAsync()).Select(x => _imapper.Map<GetLop>(x)).ToList();
                serviceReponse.Message = "Delete Lop ID = " + id + "success";
            }
            else
            {
                serviceReponse.Data = null;
                serviceReponse.Message = "Delete Lop ID = " + id + "fail";
                serviceReponse.Success = false;
            }
            return serviceReponse;
        }

        public async Task<ServiceReponse<GetLop>> GetLopByID(int id)
        {
            var serviceReponse = new ServiceReponse<GetLop>();
            var data = await _dataContext.Lops.Include(x => x.khoa).FirstOrDefaultAsync(x => x.Id == id);
            if (data is not null)
            {
                serviceReponse.Data = _imapper.Map<GetLop>(data);
                serviceReponse.Message = "Find Lop with ID = " + id + " success";
            }
            else
            {
                serviceReponse.Data = null;
                serviceReponse.Message = "Find Lop with ID = " + id + " fail";
            }
            return serviceReponse;
        }

        public async Task<ServiceReponse<List<GetLop>>> GetLops()
        {
            var serviceReponse = new ServiceReponse<List<GetLop>>();
            var data = await _dataContext.Lops.Include(x => x.khoa).ToListAsync();
            serviceReponse.Data = (data).Select(x => _imapper.Map<GetLop>(x)).ToList();
            serviceReponse.Message = "Get Lops success";
            return serviceReponse;
        }

        public async Task<ServiceReponse<List<GetLop>>> UpdateLop(UpdateLop newLop)
        {
            var serviceReponse = new ServiceReponse<List<GetLop>>();
            try
            {
                var checkIdLop = await _dataContext.Lops.Include(x => x.khoa).FirstOrDefaultAsync(x => x.Id == newLop.Id);
                var checkIdKhoa = await _dataContext.Khoas.FirstOrDefaultAsync(x => x.Id == newLop.khoaId);
                if (checkIdLop is not null && checkIdLop is not null)
                {
                    var updateLop = new Lop();
                    checkIdLop.TenLop = newLop.TenLop;
                    checkIdLop.khoa = checkIdKhoa;
                    await _dataContext.SaveChangesAsync();
                    serviceReponse.Data = (await _dataContext.Lops.Include(x=> x.khoa).ToListAsync()).Select(x => _imapper.Map<GetLop>(x)).ToList();
                    serviceReponse.Message = "Update Lop ID = " + newLop.Id + " success";
                }
                else
                {
                    serviceReponse.Data = null;
                    serviceReponse.Message = "Update Lop ID = " + newLop.Id + " fail";
                }
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return serviceReponse;
        }
    }
}