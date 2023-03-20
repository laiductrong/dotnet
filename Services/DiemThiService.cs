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
            var checkDiemThi = await _dataContext.DiemThis.Include(x => x.sinhVienId).Include(x => x.monHocId).FirstOrDefaultAsync(
                x => x.sinhVienId.Id == addDiemThi.sinhVienId && x.monHocId.Id == addDiemThi.monHocId
            );
            if (checkDiemThi is not null)
            {
                serviceReponse.Data = null;
                serviceReponse.Message = "Diem Exist";
                serviceReponse.Success = false;
            }
            else
            {
                var inforSV = await _dataContext.SinhViens.Include(x => x.lop).FirstOrDefaultAsync(x => x.Id == addDiemThi.sinhVienId);
                var inforMH = await _dataContext.MonHocs.FirstOrDefaultAsync(x => x.Id == addDiemThi.monHocId);
                var diem = new DiemThi();
                if (inforMH is not null && inforSV is not null)
                {
                    diem.monHocId = inforMH;
                    diem.sinhVienId = inforSV;
                    diem.lanThi = addDiemThi.lanThi;
                    diem.diem = addDiemThi.diem;
                    await _dataContext.DiemThis.AddAsync(diem);
                    await _dataContext.SaveChangesAsync();
                    var data = await _dataContext.DiemThis.Include(x => x.sinhVienId).Include(x => x.monHocId).ToListAsync();
                    serviceReponse.Data = (data).Select(x => _imapper.Map<GetDiemThi>(x)).ToList();
                    serviceReponse.Message = "Add Diem Success";
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
            var data = await _dataContext.DiemThis.Include(x => x.sinhVienId).Include(x => x.monHocId).ToListAsync();
            serviceReponse.Data = (data).Select(x => _imapper.Map<GetDiemThi>(x)).ToList();
            serviceReponse.Message = "Success";
            return serviceReponse;
        }

        // public Task<ServiceReponse<List<DiemThi>>> DeleteDiemThi(int idSV, int idMH)
        // {
        //     throw new NotImplementedException();
        // }

        // public Task<ServiceReponse<DiemThi>> GetDiemThi(int idSV, int idMH)
        // {
        //     throw new NotImplementedException();
        // }

        // public Task<ServiceReponse<List<DiemThi>>> GetDiemThiByMH(int idMH)
        // {
        //     throw new NotImplementedException();
        // }

        // public Task<ServiceReponse<List<DiemThi>>> GetDiemThiBySV(int idSv)
        // {
        //     throw new NotImplementedException();
        // }

        // public Task<ServiceReponse<List<DiemThi>>> GetDiemThis()
        // {
        //     throw new NotImplementedException();
        // }

        // public Task<ServiceReponse<List<DiemThi>>> UpdateDiemThi(int idSV, int idMH)
        // {
        //     throw new NotImplementedException();
        // }
    }
}