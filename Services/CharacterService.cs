using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services
{
    public class CharacterService : ICharacterService
    {
        public List<Character> characters = new List<Character>{
            new Character{Id = 1 , Name = "First Name"},
            new Character{Id = 2 , Name = "Second Name"},
            new Character{Id = 3 , Name = "Third Name"},
            new Character{Id = 4 , Name = "Fourth Name"},
            new Character{Id = 5 , Name = "Fifth Name"},
            new Character{Id = 6 , Name = "Sixth Name"}
        };
        private readonly IMapper _imapper;
        private readonly DataContext _dataConText;
        public CharacterService(IMapper mapper, DataContext dataContext)
        {
            _dataConText = dataContext;
            _imapper = mapper;
        }
        public async Task<ServiceReponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceReponse = new ServiceReponse<List<GetCharacterDto>>();
            // var dbCharacters = await _dataConText.Characters.ToListAsync();
            //
            await _dataConText.AddAsync(_imapper.Map<Character>(newCharacter));
            // dbCharacters.Add(_imapper.Map<Character>(newCharacter));
            await _dataConText.SaveChangesAsync();
            var dbCharacters = await _dataConText.Characters.ToListAsync();
            serviceReponse.Data = dbCharacters.Select(c => _imapper.Map<GetCharacterDto>(c)).ToList();
            serviceReponse.Message = "Add character success";
            return serviceReponse;
        }

        public async Task<ServiceReponse<GetCharacterDto>> GetByID(int id)
        {
            var serviceReponse = new ServiceReponse<GetCharacterDto>();
            try
            {
                var dbCharacters = await _dataConText.Characters.FirstAsync(x => x.Id == id);
                if (dbCharacters is not null)
                {
                    serviceReponse.Data = _imapper.Map<GetCharacterDto>(dbCharacters);
                    serviceReponse.Message = "find character success";
                    return serviceReponse;
                }
            }
            catch (Exception ex)
            {
                serviceReponse.Data = null;
                serviceReponse.Message = "can not find character";
                serviceReponse.Success = false;
                return serviceReponse;
            }

            throw new Exception("chracter not fould");
        }

        public async Task<ServiceReponse<List<GetCharacterDto>>> GetList()
        {
            var dbCharacters = await _dataConText.Characters.ToListAsync();
            var serviceReponse = new ServiceReponse<List<GetCharacterDto>>();
            serviceReponse.Data = dbCharacters.Select(c => _imapper.Map<GetCharacterDto>(c)).ToList();
            serviceReponse.Message = "Get list success";
            return serviceReponse;
        }

        public async Task<ServiceReponse<GetCharacterDto>> GetSingle()
        {
            var singleCharater = await _dataConText.Characters.FirstAsync();
            var serviceReponse = new ServiceReponse<GetCharacterDto>();
            serviceReponse.Data = _imapper.Map<GetCharacterDto>(singleCharater);
            serviceReponse.Message = "find character success";
            return serviceReponse;
        }

        public async Task<ServiceReponse<GetCharacterDto>> UpdateCharacter(UpdateCharaterDto changeCharacter)
        {
            var dbCharacters = await _dataConText.Characters.FirstOrDefaultAsync(x => x.Id ==changeCharacter.Id);
            var serviceReponse = new ServiceReponse<GetCharacterDto>();
            try
            {
                var character = characters.FirstOrDefault(c => c.Id == changeCharacter.Id);
                if (dbCharacters is null)
                    throw new Exception("charater with id" + changeCharacter.Id + " not foud");
                dbCharacters.Name = changeCharacter.Name;
                dbCharacters.HitPoints = changeCharacter.HitPoints;
                dbCharacters.Strength = changeCharacter.Strength;
                dbCharacters.Defense = changeCharacter.Defense;
                dbCharacters.Intelligence = changeCharacter.Intelligence;
                dbCharacters.Class = changeCharacter.Class;
                await _dataConText.SaveChangesAsync();
                serviceReponse.Data = _imapper.Map<GetCharacterDto>(dbCharacters);
                serviceReponse.Message = "update success";
            }
            catch (Exception e)
            {
                serviceReponse.Data = null;
                serviceReponse.Message = e.Message;
            }
            return serviceReponse;
            // throw new NotImplementedException();
        }

        public async Task<ServiceReponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            var dbCharacters = await _dataConText.Characters.ToListAsync();
            var serviceReponse = new ServiceReponse<List<GetCharacterDto>>();
            try
            {
                var character = characters.First(x => x.Id == id);
                if (character is not null)
                {
                    characters.Remove(character);
                    serviceReponse.Data = characters.Select(c => _imapper.Map<GetCharacterDto>(c)).ToList();
                    // serviceReponse.Data = _imapper.Map<GetCharacterDto>(character);
                    serviceReponse.Message = "Delete Character Success";
                    return serviceReponse;
                }
            }
            catch (Exception e)
            {
                serviceReponse.Data = null;
                serviceReponse.Message = "Can not foul character " + id;
            }
            return serviceReponse;

        }
    }
}