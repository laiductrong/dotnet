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
        }
    }
}