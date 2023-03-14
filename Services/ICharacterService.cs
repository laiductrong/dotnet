using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services
{
    public interface ICharacterService
    {
        Task <ServiceReponse<GetCharacterDto>> GetSingle();
        Task <ServiceReponse<List<GetCharacterDto>>> GetList();
        Task <ServiceReponse<GetCharacterDto>> GetByID (int id);
        Task <ServiceReponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);
        Task <ServiceReponse<GetCharacterDto>> UpdateCharacter(UpdateCharaterDto changeCharacter);
        Task <ServiceReponse<List<GetCharacterDto>>> DeleteCharacter (int id);
    }
}