using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services
{
    public class MonHocService : IMonHocService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _imapper;
        public MonHocService(DataContext dataContext, IMapper imapper)
        {
            _dataContext = dataContext;
            _imapper = imapper;
        }

        public async Task<ServiceReponse<List<GetMonHoc>>> AddMonHoc(AddMonHoc addMonHoc)
        {
            var serviceReponse = new ServiceReponse<List<GetMonHoc>>();
            var monHoc = new MonHoc();
            monHoc.tenMH = addMonHoc.tenMH;
            monHoc.soTiet = addMonHoc.soTiet;
            await _dataContext.MonHocs.AddAsync(monHoc);
            await _dataContext.SaveChangesAsync();
            serviceReponse.Data = (await _dataContext.MonHocs.ToListAsync()).Select(x => _imapper.Map<GetMonHoc>(x)).ToList();
            serviceReponse.Message = "Add MonHoc Success";
            return serviceReponse;
        }

        public async Task<ServiceReponse<List<GetMonHoc>>> DeleteMonHoc(int id)
        {
            var serviceReponse = new ServiceReponse<List<GetMonHoc>>();
            var delete = await _dataContext.MonHocs.FirstOrDefaultAsync(x => x.Id == id);
            try
            {
                if (delete is not null)
                {
                    _dataContext.MonHocs.Remove(delete);
                    await _dataContext.SaveChangesAsync();
                    serviceReponse.Data = (await _dataContext.MonHocs.ToListAsync()).Select(x => _imapper.Map<GetMonHoc>(x)).ToList();
                    serviceReponse.Message = "Add MonHoc Success";
                }
                else
                {
                    serviceReponse.Data = null;
                    serviceReponse.Message = "Delete MonHoc Fail";
                    serviceReponse.Success = false;
                }
            }
            catch (System.Exception)
            {

                throw;
            }
            return serviceReponse;
        }

        public async Task<ServiceReponse<GetMonHoc>> GetMonHoc(int id)
        {
            var serviceReponse = new ServiceReponse<GetMonHoc>();
            var monHoc = await _dataContext.MonHocs.FirstOrDefaultAsync(x => x.Id == id);
            try
            {
                if (monHoc is not null)
                {
                    serviceReponse.Data = _imapper.Map<GetMonHoc>(monHoc);
                    serviceReponse.Message = "Find MonHoc ID = " + id + " success";
                }
                else
                {
                    serviceReponse.Data = null;
                    serviceReponse.Message = "Find MonHoc ID = " + id + " fail";
                    serviceReponse.Success = false;
                }
            }
            catch (System.Exception)
            {

                throw;
            }
            return serviceReponse;
        }

        public async Task<ServiceReponse<List<GetMonHoc>>> GetMonHocs()
        {
            var serviceReponse = new ServiceReponse<List<GetMonHoc>>();
            var data = await _dataContext.MonHocs.ToListAsync();
            serviceReponse.Data = (data).Select(x => _imapper.Map<GetMonHoc>(x)).ToList();
            serviceReponse.Message = "success";
            return serviceReponse;
        }

        public async Task<ServiceReponse<List<GetMonHoc>>> UpdateMonHoc(UpdateMonHoc updateMonHoc)
        {
            var serviceReponse = new ServiceReponse<List<GetMonHoc>>();
            var monHoc = await _dataContext.MonHocs.FirstOrDefaultAsync(x => x.Id == updateMonHoc.Id);
            try
            {
                if (monHoc is not null)
                {
                    monHoc.tenMH = updateMonHoc.tenMH;
                    monHoc.soTiet = updateMonHoc.soTiet;
                    await _dataContext.SaveChangesAsync();
                    serviceReponse.Data = (await _dataContext.MonHocs.ToListAsync()).Select(x => _imapper.Map<GetMonHoc>(x)).ToList();
                    serviceReponse.Message = "Update MonHoc Success";
                }
                else
                {
                    serviceReponse.Data = null;
                    serviceReponse.Message = "Update MonHoc fail";
                    serviceReponse.Success = false;
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