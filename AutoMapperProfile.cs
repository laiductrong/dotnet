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
        }
    }
}