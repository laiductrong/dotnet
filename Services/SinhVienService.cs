using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services
{
    public class SinhVienService : ISinhVienService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _imapper;
        public SinhVienService(DataContext dataContext, IMapper imapper)
        {
            _dataContext = dataContext;
            _imapper = imapper;
        }

        public async Task<ServiceReponse<List<GetSinhVien>>> AddSinhVien(AddSinhVien addSinhVien)
        {
            var serviceReponse = new ServiceReponse<List<GetSinhVien>>();
            try
            {
                var checkLop = await _dataContext.Lops.FirstOrDefaultAsync(x => x.Id == addSinhVien.lopId);
                if (checkLop is not null)
                {
                    var sinhVien = new SinhVien();
                    sinhVien.tenSV = addSinhVien.tenSV;
                    sinhVien.gioiTinh = addSinhVien.gioiTinh;
                    sinhVien.ngaySinh = addSinhVien.ngaySinh;
                    sinhVien.lop = checkLop;
                    await _dataContext.AddAsync(sinhVien);
                    await _dataContext.SaveChangesAsync();
                    serviceReponse.Data = (await _dataContext.SinhViens.Include(x => x.lop).ToListAsync()).Select(x => _imapper.Map<GetSinhVien>(x)).ToList();
                    serviceReponse.Message = "success";
                }
                else
                {
                    serviceReponse.Data = null;
                    serviceReponse.Message = "Add SinhVien Fail";
                }
            }
            catch (System.Exception)
            {

                throw;
            }
            return serviceReponse;
        }

        public async Task<ServiceReponse<List<GetSinhVien>>> DeleteSinhVien(int id)
        {
            var serviceReponse = new ServiceReponse<List<GetSinhVien>>();
            var sinhVien = await _dataContext.SinhViens.Include(x => x.lop).FirstOrDefaultAsync(x => x.Id == id);
            try
            {
                if (sinhVien is not null)
                {
                    _dataContext.SinhViens.Remove(sinhVien);
                    await _dataContext.SaveChangesAsync();
                    serviceReponse.Data = (await _dataContext.SinhViens.Include(x => x.lop).ToListAsync()).Select(x => _imapper.Map<GetSinhVien>(x)).ToList();
                    serviceReponse.Message = "Delete SinhVien ID = " + id + " success";
                }
                else
                {
                    serviceReponse.Data = null;
                    serviceReponse.Message = "Delete SinhVien ID = " + id + " fail";
                }
            }
            catch (System.Exception)
            {

                throw;
            }
            return serviceReponse;
        }

        public async Task<ServiceReponse<GetSinhVien>> GetSinhVien(int id)
        {
            var serviceReponse = new ServiceReponse<GetSinhVien>();
            try
            {
                var sinhVien = await _dataContext.SinhViens.Include(x => x.lop).FirstOrDefaultAsync(x => x.Id == id);
                if (sinhVien is not null)
                {
                    serviceReponse.Data = _imapper.Map<GetSinhVien>(sinhVien);
                    serviceReponse.Message = " Find SinhVien ID = " + id + " Success";
                }
                else
                {
                    serviceReponse.Data = null;
                    serviceReponse.Message = " Find SinhVien ID = " + id + "Fail";
                }
            }
            catch (System.Exception)
            {

                throw;
            }
            return serviceReponse;
        }

        public async Task<ServiceReponse<List<GetSinhVien>>> GetSinhViens()
        {
            var serviceReponse = new ServiceReponse<List<GetSinhVien>>();
            var data = await _dataContext.SinhViens.Include(x => x.lop).ToListAsync();
            serviceReponse.Data = (data).Select(x => _imapper.Map<GetSinhVien>(x)).ToList();
            serviceReponse.Message = "success";
            return serviceReponse;
        }

        public async Task<ServiceReponse<List<GetSinhVien>>> UpdateSinhVien(UpdateSinhVien updateSinhVien)
        {
            var serviceReponse = new ServiceReponse<List<GetSinhVien>>();
            try
            {
                var checkSinhVien = await _dataContext.SinhViens.Include(x => x.lop).FirstOrDefaultAsync(x => x.Id == updateSinhVien.Id);
                var checkLop = await _dataContext.Lops.Include(x => x.khoa).FirstOrDefaultAsync(x => x.Id == updateSinhVien.lopId);
                if (checkLop is not null && checkSinhVien is not null)
                {
                    checkSinhVien.tenSV = updateSinhVien.tenSV;
                    checkSinhVien.gioiTinh = updateSinhVien.gioiTinh;
                    checkSinhVien.ngaySinh = updateSinhVien.ngaySinh;
                    checkSinhVien.lop = checkLop;
                    await _dataContext.SaveChangesAsync();
                    serviceReponse.Data = (await _dataContext.SinhViens.Include(x => x.lop).ToListAsync()).Select(x => _imapper.Map<GetSinhVien>(x)).ToList();
                    serviceReponse.Message = "update SinhVien success";
                }
                else
                {
                    serviceReponse.Data = null;
                    serviceReponse.Message = "Update SinhVien Fail";
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