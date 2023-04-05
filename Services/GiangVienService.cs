using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services
{
    public class GiangVienService : IGiangVienService
    {
        private readonly IMapper _imapper;
        private readonly DataContext _dataContext;
        public GiangVienService(IMapper imapper, DataContext dataContext)
        {
            _imapper = imapper;
            _dataContext = dataContext;
        }
        public async Task<ServiceReponse<List<GetGiangVien>>> AddGiangVien(AddGiangVien newGiangVien)
        {
            var serviceReponse = new ServiceReponse<List<GetGiangVien>>();
            //tìm khoa có trong database không
            var khoaOfGV = await _dataContext.Khoas.FirstOrDefaultAsync(x => x.Id == newGiangVien.khoaId);
            //khởi tạo giảng viên để thêm vào database
            var giangVien = new GiangVien();
            try
            {
                //check khoa
                if (khoaOfGV is not null)
                {
                    giangVien.Id = 0;
                    giangVien.tenGV = newGiangVien.tenGV;
                    giangVien.chuyenNganh = newGiangVien.chuyenNganh;
                    giangVien.khoa = khoaOfGV;
                    await _dataContext.GiangViens.AddAsync(giangVien);
                    await _dataContext.SaveChangesAsync();
                    serviceReponse.Data = (await _dataContext.GiangViens.Include(x => x.khoa).ToListAsync()).Select(x => _imapper.Map<GetGiangVien>(x)).ToList();
                    serviceReponse.Message = " Add GiangVien success";
                }
                else
                {
                    serviceReponse.Data = null;
                    serviceReponse.Message ="don't have Khoa with ID = "+ newGiangVien.khoaId;
                    serviceReponse.Success = false;
                }
                // await _dataContext.GiangViens.AddAsync(_imapper.Map<GiangVien>(newGiangVien));

            }
            catch (System.Exception)
            {

                throw;
            }
            return serviceReponse;
        }

        public async Task<ServiceReponse<List<GetGiangVien>>> DeleteGiangVien(int id)
        {
            var serviceReponse = new ServiceReponse<List<GetGiangVien>>();
            try
            {
                var giangVienDelete = await _dataContext.GiangViens.FirstOrDefaultAsync(x => x.Id == id);
                if (giangVienDelete is not null)
                {
                    _dataContext.GiangViens.Remove(giangVienDelete);
                    await _dataContext.SaveChangesAsync();
                    serviceReponse.Data = (await _dataContext.GiangViens.ToListAsync()).Select(x => _imapper.Map<GetGiangVien>(x)).ToList();
                    serviceReponse.Message = "Delete GiangVien id = " + id + " success";
                    return serviceReponse;
                }
                else
                {
                    serviceReponse.Data = null;
                    serviceReponse.Message = " Delete GiangVien id = " + id + " fail";
                    serviceReponse.Success = false;
                    return serviceReponse;
                }
            }
            catch (System.Exception)
            {
                serviceReponse.Data = null;
                serviceReponse.Message = " Delete GiangVien id = " + id + " fail";
                serviceReponse.Success = false;
                return serviceReponse;
            }
        }

        public async Task<ServiceReponse<GetGiangVien>> GetByID(int id)
        {
            var serviceReponse = new ServiceReponse<GetGiangVien>();
            var data = await _dataContext.GiangViens.Include(x => x.khoa).ToListAsync();
            var giangVienGet = await _dataContext.GiangViens.Include(x => x.khoa).FirstOrDefaultAsync(x => x.Id == id);
            if (giangVienGet is not null)
            {
                serviceReponse.Data = _imapper.Map<GetGiangVien>(giangVienGet);
                serviceReponse.Message = " find GiangVien id = " + id + " success";
            }
            else
            {
                serviceReponse.Data = null;
                serviceReponse.Message = " find GiangVien id = " + id + " fail";
                serviceReponse.Success = false;
            }
            return serviceReponse;
        }

        public async Task<ServiceReponse<List<GetGiangVien>>> GetGiangVien()
        {
            var serviceReponse = new ServiceReponse<List<GetGiangVien>>();
            try
            {
                // serviceReponse.Data = (await _dataContext.GiangViens.Include(x => x.).ToListAsync()).Select(x => _imapper.Map<GetGiangVien>(x)).ToList();
                // serviceReponse.Message = "Get GiangViens success";
                var data = await _dataContext.GiangViens.Include(x => x.khoa).ToListAsync();
                serviceReponse.Data = (data).Select(x => _imapper.Map<GetGiangVien>(x)).ToList();
                serviceReponse.Message = "Get GiangViens success";

            }
            catch (Exception e)
            {

                serviceReponse.Data = null;
                serviceReponse.Message = e.Message;
            }
            return serviceReponse;

        }

        public async Task<ServiceReponse<List<GetGiangVien>>> UpdateGiangVien(UpdateGiangVien newGiangVien)
        {
            var serviceReponse = new ServiceReponse<List<GetGiangVien>>();
            try
            {
                var gianVienUpdate = await _dataContext.GiangViens.Include(x => x.khoa).FirstOrDefaultAsync(x => x.Id == newGiangVien.Id);
                var khoaOfGV = await _dataContext.Khoas.FirstOrDefaultAsync(x => x.Id == newGiangVien.khoaId);
                if (gianVienUpdate is not null && khoaOfGV is not null)
                {
                    // var giangVien = new GiangVien();
                    gianVienUpdate.tenGV = newGiangVien.tenGV;
                    gianVienUpdate.chuyenNganh = newGiangVien.chuyenNganh;
                    gianVienUpdate.khoa = khoaOfGV;
                    await _dataContext.SaveChangesAsync();
                    serviceReponse.Data = (await _dataContext.GiangViens.Include(x => x.khoa).ToListAsync()).Select(x => _imapper.Map<GetGiangVien>(x)).ToList();
                    serviceReponse.Message = "update GiangVien success";
                    return serviceReponse;
                }
                else
                {
                    serviceReponse.Data = null;
                    serviceReponse.Message = "ID's GiangVien or ID's Khoa don't have in database!";
                    serviceReponse.Success = false;
                    return serviceReponse;
                }
            }
            catch (Exception e)
            {
                serviceReponse.Data = null;
                serviceReponse.Message = e.Message;
                return serviceReponse;
            }
        }
    }
}