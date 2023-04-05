using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
            CreateMap<Character, UpdateCharaterDto>();
            CreateMap<Khoa, GetKhoa>();
            CreateMap<Khoa, AddKhoa>();
            CreateMap<Khoa, UpdateKhoa>();
            CreateMap<GiangVien, GetGiangVien>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.tenGV, opt => opt.MapFrom(src => src.tenGV))
                .ForMember(dest => dest.chuyenNganh, opt => opt.MapFrom(src => src.chuyenNganh))
                .ForMember(dest => dest.khoaId, opt => opt.MapFrom(src => src.khoa.Id));
            CreateMap<GiangVien, AddGiangVien>()
                // .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.tenGV, opt => opt.MapFrom(src => src.tenGV))
                .ForMember(dest => dest.chuyenNganh, opt => opt.MapFrom(src => src.chuyenNganh))
                .ForMember(dest => dest.khoaId, opt => opt.MapFrom(src => src.khoa.Id));
            CreateMap<GiangVien, UpdateGiangVien>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.tenGV, opt => opt.MapFrom(src => src.tenGV))
                .ForMember(dest => dest.chuyenNganh, opt => opt.MapFrom(src => src.chuyenNganh))
                .ForMember(dest => dest.khoaId, opt => opt.MapFrom(src => src.khoa.Id));
            
            CreateMap<Lop, GetLop>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.TenLop, opt => opt.MapFrom(src => src.TenLop))
                .ForMember(dest => dest.khoaId, opt => opt.MapFrom(src => src.khoa.Id));
            CreateMap<Lop, AddLop>()
                // .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.TenLop, opt => opt.MapFrom(src => src.TenLop))
                .ForMember(dest => dest.khoaId, opt => opt.MapFrom(src => src.khoa.Id));
            CreateMap<Lop, UpdateLop>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.TenLop, opt => opt.MapFrom(src => src.TenLop))
                .ForMember(dest => dest.khoaId, opt => opt.MapFrom(src => src.khoa.Id));

            CreateMap<SinhVien, GetSinhVien>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.tenSV, opt => opt.MapFrom(src => src.tenSV))
                .ForMember(dest => dest.gioiTinh, opt => opt.MapFrom(src => src.gioiTinh))
                .ForMember(dest => dest.ngaySinh, opt => opt.MapFrom(src => src.ngaySinh))
                .ForMember(dest => dest.tenLop, opt => opt.MapFrom(src => src.lop.TenLop));
            CreateMap<SinhVien, AddSinhVien>()
                // .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.tenSV, opt => opt.MapFrom(src => src.tenSV))
                .ForMember(dest => dest.gioiTinh, opt => opt.MapFrom(src => src.gioiTinh))
                .ForMember(dest => dest.ngaySinh, opt => opt.MapFrom(src => src.ngaySinh))
                .ForMember(dest => dest.lopId, opt => opt.MapFrom(src => src.lop.Id));
            CreateMap<SinhVien, UpdateSinhVien>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.tenSV, opt => opt.MapFrom(src => src.tenSV))
                .ForMember(dest => dest.gioiTinh, opt => opt.MapFrom(src => src.gioiTinh))
                .ForMember(dest => dest.ngaySinh, opt => opt.MapFrom(src => src.ngaySinh))
                .ForMember(dest => dest.lopId, opt => opt.MapFrom(src => src.lop.Id));

            CreateMap<MonHoc, GetMonHoc>();
            CreateMap<MonHoc, AddMonHoc>();
                // .ForMember(dest => dest.tenMH, opt => opt.MapFrom(src => src.tenMH))
                // .ForMember(dest => dest.soTiet, opt => opt.MapFrom(src => src.soTiet));
            CreateMap<MonHoc, UpdateMonHoc>();

            CreateMap<DiemThi, GetDiemThi>()
                .ForMember(dest => dest.tenSinhVien, opt => opt.MapFrom(src=> src.sinhVienIdId))
                .ForMember(dest => dest.tenMonHoc, opt => opt.MapFrom(src=> src.monHocIdId))
                .ForMember(dest => dest.lanThi, opt => opt.MapFrom(src=> src.lanThi))
                .ForMember(dest => dest.diem, opt => opt.MapFrom(src=> src.diem));
            CreateMap<DiemThi, AddDiemThi>();
            CreateMap<DiemThi, UpdateMonHoc>();
            CreateMap<DThi,GetDiemThi>()
                .ForMember(dest => dest.tenSinhVien, opt => opt.MapFrom(src=>src.tenSinhVien.tenSV))
                .ForMember(dest => dest.tenMonHoc, opt => opt.MapFrom(src=>src.tenMonHoc.tenMH));
                // .ForMember(dest => dest.lanThi, opt => opt.MapFrom(src=>src.lanThi))
                // .ForMember(dest => dest.diem, opt => opt.MapFrom(src=>src.diem));
        }
    }
}