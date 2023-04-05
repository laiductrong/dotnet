using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services
{
    public class DiemThiService : IDiemThiService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _imapper;
        public DiemThiService(DataContext dataContext, IMapper imapper)
        {
            _dataContext = dataContext;
            _imapper = imapper;
        }
        public async Task<ServiceReponse<List<GetDiemThi>>> AddDiemThi(AddDiemThi addDiemThi)
        {
            var serviceReponse = new ServiceReponse<List<GetDiemThi>>();
            var checkDiemThi = await _dataContext.DiemThis.Where(x => x.sinhVienIdId == addDiemThi.sinhVienId && x.monHocIdId == addDiemThi.monHocId).Select(c =>
                                           new DiemThi
                                           {
                                               sinhVienIdId = c.sinhVienIdId,
                                               monHocIdId = c.monHocIdId,
                                               lanThi = c.lanThi,
                                               diem = c.diem
                                           }).ToListAsync();
            if (checkDiemThi is not null)
            {
                DiemThi d = new DiemThi();
                d.monHocIdId = addDiemThi.monHocId;
                d.sinhVienIdId = addDiemThi.sinhVienId;
                d.lanThi = checkDiemThi.Count + 1;
                d.diem = addDiemThi.diem;
                await _dataContext.DiemThis.AddAsync(d);
                await _dataContext.SaveChangesAsync();
                var data = await _dataContext.DiemThis.Select(
                                        c =>
                                           new DiemThi
                                           {
                                               sinhVienIdId = c.sinhVienIdId,
                                               monHocIdId = c.monHocIdId,
                                               lanThi = c.lanThi,
                                               diem = c.diem
                                           }).ToListAsync();
                serviceReponse.Data = getList(data);
            }
            else
            {
                var inforSV = await _dataContext.SinhViens.Include(x => x.lop).FirstOrDefaultAsync(x => x.Id == addDiemThi.sinhVienId);
                var inforMH = await _dataContext.MonHocs.FirstOrDefaultAsync(x => x.Id == addDiemThi.monHocId);
                var diem = new DiemThi();
                if (inforMH is not null && inforSV is not null)
                {
                    diem.monHocIdId = addDiemThi.monHocId;
                    diem.sinhVienIdId = addDiemThi.sinhVienId;
                    diem.lanThi = 1;
                    diem.diem = addDiemThi.diem;
                    await _dataContext.DiemThis.AddAsync(diem);
                    await _dataContext.SaveChangesAsync();
                    //get diem
                    var data = await _dataContext.DiemThis.Select(
                                        c =>
                                           new DiemThi
                                           {
                                               sinhVienIdId = c.sinhVienIdId,
                                               monHocIdId = c.monHocIdId,
                                               lanThi = c.lanThi,
                                               diem = c.diem
                                           }).ToListAsync();
                    serviceReponse.Data = getList(data);
                }
                else
                {
                    serviceReponse.Data = null;
                    serviceReponse.Message = "SinhVien not Exist Or MonHoc not Exist";
                    serviceReponse.Success = false;
                }
            }
            return serviceReponse;
        }

        public async Task<ServiceReponse<List<GetDiemThi>>> GetDiemThis()
        {
            var serviceReponse = new ServiceReponse<List<GetDiemThi>>();
            var data = await _dataContext.DiemThis.Select(
                                        c =>
                                           new DiemThi
                                           {
                                               sinhVienIdId = c.sinhVienIdId,
                                               monHocIdId = c.monHocIdId,
                                               lanThi = c.lanThi,
                                               diem = c.diem
                                           }).ToListAsync();
            serviceReponse.Data = getList(data);
            serviceReponse.Message = "Success";
            return serviceReponse;
        }
        public async Task<ServiceReponse<List<GetDiemThi>>> GetDiemThi(int idSV, int idMH)
        {
            var serviceReponse = new ServiceReponse<List<GetDiemThi>>();
            try
            {
                var data = await _dataContext.DiemThis.Where(x => x.sinhVienIdId == idSV && x.monHocIdId == idMH).Select(
                                        c =>
                                           new DiemThi
                                           {
                                               sinhVienIdId = c.sinhVienIdId,
                                               monHocIdId = c.monHocIdId,
                                               lanThi = c.lanThi,
                                               diem = c.diem
                                           }).ToListAsync();
                serviceReponse.Data = getList(data);
                serviceReponse.Message = "Success";
            }
            catch (System.Exception)
            {
                serviceReponse.Data = null;
                serviceReponse.Message = " Error";
            }
            return serviceReponse;
        }
        public List<GetDiemThi> getList(List<DiemThi> data)
        {
            var datas = new List<GetDiemThi>();
            foreach (DiemThi item in data)
            {
                if (item.lanThi != 0)
                {
                    GetDiemThi g = new GetDiemThi();
                    g.tenSinhVien = _dataContext.SinhViens.FirstOrDefault(x => x.Id == item.sinhVienIdId).tenSV;
                    g.tenMonHoc = _dataContext.MonHocs.FirstOrDefault(x => x.Id == item.monHocIdId).tenMH;
                    g.lanThi = item.lanThi;
                    g.diem = item.diem;
                    datas.Add(g);
                }
            }
            return datas;
        }

        public async Task<ServiceReponse<List<GetDiemThi>>> GetDiemThiBySV(int idSV)
        {
            var serviceReponse = new ServiceReponse<List<GetDiemThi>>();
            try
            {
                var data = await _dataContext.DiemThis.Where(x => x.sinhVienIdId == idSV).Select(
                                        c =>
                                           new DiemThi
                                           {
                                               sinhVienIdId = c.sinhVienIdId,
                                               monHocIdId = c.monHocIdId,
                                               lanThi = c.lanThi,
                                               diem = c.diem
                                           }).ToListAsync();
                serviceReponse.Data = getList(data);
                serviceReponse.Message = "Success";
            }
            catch (System.Exception)
            {
                serviceReponse.Data = null;
                serviceReponse.Message = " Error";
                return serviceReponse;
            }
            return serviceReponse;
        }
        public async Task<ServiceReponse<List<GetDiemThi>>> GetDiemThiByMH(int idMH)
        {
            var serviceReponse = new ServiceReponse<List<GetDiemThi>>();
            try
            {
                var data = await _dataContext.DiemThis.Where(x => x.monHocIdId == idMH).Select(
                                        c =>
                                           new DiemThi
                                           {
                                               sinhVienIdId = c.sinhVienIdId,
                                               monHocIdId = c.monHocIdId,
                                               lanThi = c.lanThi,
                                               diem = c.diem
                                           }).ToListAsync();
                serviceReponse.Data = getList(data);
                serviceReponse.Message = "Success";
            }
            catch (System.Exception)
            {
                serviceReponse.Data = null;
                serviceReponse.Message = " Error";
                return serviceReponse;
            }
            return serviceReponse;
        }

        public async Task<ServiceReponse<List<GetDiemThi>>> DeleteDiemThi(UpdateDiemThi updateDiemThi)
        {
            var serviceReponse = new ServiceReponse<List<GetDiemThi>>();
            bool checkDelete = false;
            try
            {
                var listUpdate = await _dataContext.DiemThis.Select(
                                            c =>
                                               new DiemThi
                                               {
                                                   sinhVienIdId = c.sinhVienIdId,
                                                   monHocIdId = c.monHocIdId,
                                                   lanThi = c.lanThi,
                                                   diem = c.diem
                                               }).ToListAsync();
                foreach (DiemThi item in listUpdate)
                {
                    if (item.monHocIdId == updateDiemThi.monHocId && item.sinhVienIdId == updateDiemThi.sinhVienId && item.lanThi == updateDiemThi.lanThi)
                    {
                        _dataContext.Remove(item);
                        await _dataContext.SaveChangesAsync();
                        checkDelete = true;
                        break;
                    }
                }
                if (checkDelete)
                {
                    serviceReponse.Data = getList(listUpdate);
                    serviceReponse.Message = "Delete success";
                }
                else
                {
                    serviceReponse.Data = null;
                    serviceReponse.Message = "Fail delete";
                    serviceReponse.Success = false;
                }


            }
            catch (System.Exception)
            {
                serviceReponse.Data = null;
                serviceReponse.Message = " Error";
                return serviceReponse;
            }
            return serviceReponse;
        }

        public async Task<ServiceReponse<List<GetDiemThi>>> UpdateDiemThi(UpdateDiemThi updateDiemThi)
        {
            var serviceReponse = new ServiceReponse<List<GetDiemThi>>();
            bool checkUpdate = false;
            try
            {
                var checkDiemThi = await _dataContext.DiemThis.Where(x => (x.sinhVienIdId == updateDiemThi.sinhVienId) && (x.monHocIdId == updateDiemThi.monHocId)).Select(c =>
                                           new DiemThi
                                           {
                                               sinhVienIdId = c.sinhVienIdId,
                                               monHocIdId = c.monHocIdId,
                                               lanThi = c.lanThi,
                                               diem = c.diem
                                           }).ToListAsync();
                List<DiemThi> newList = new List<DiemThi>();
                foreach (DiemThi item in checkDiemThi)
                {
                    if(item.lanThi==updateDiemThi.lanThi)
                    {
                        newList.Add(item);
                    }
                    else
                    {
                        // newList.Add(item);
                        continue;
                    }
                }
                
                // checkDiemThi.Add(new DiemThi
                //                            {
                //                                sinhVienIdId = updateDiemThi.sinhVienId,
                //                                monHocIdId = updateDiemThi.monHocId,
                //                                lanThi = updateDiemThi.lanThi,
                //                                diem = updateDiemThi.diem
                //                            });
                // var all = await _dataContext.DiemThis.Where(x => (x.sinhVienIdId == updateDiemThi.sinhVienId) && (x.monHocIdId == updateDiemThi.monHocId)).Select(c =>
                //                            new DiemThi
                //                            {
                //                                sinhVienIdId = c.sinhVienIdId,
                //                                monHocIdId = c.monHocIdId,
                //                                lanThi = c.lanThi,
                //                                diem = c.diem
                //                            }).ToListAsync();
                // _dataContext.DiemThis.RemoveRange(newList.ToList());
                // await _dataContext.SaveChangesAsync();
                await _dataContext.AddRangeAsync(newList);
                // _dataContext.SaveChanges();
                // await _dataContext.DiemThis.AddRangeAsync(newList);
                _dataContext.SaveChanges();
                serviceReponse.Data = (newList).Select(x => _imapper.Map<GetDiemThi>(x)).ToList();
                serviceReponse.Message = "success";
            }
            catch (System.Exception)
            {
                serviceReponse.Data = null;
                serviceReponse.Message = " Error";
                serviceReponse.Success = false;
                return serviceReponse;
            }
            return serviceReponse;
        }
    }
}