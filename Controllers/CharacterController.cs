using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService characterService;

        public CharacterController(ICharacterService characterService)
        {
            this.characterService = characterService;
        }

        [HttpGet("GetSingle")]
        public async Task <ActionResult<ServiceReponse<Character>>> GetSingle()
        {
            return Ok(await characterService.GetSingle());
        }

        [HttpGet("GetAll")]
        public async Task <ActionResult<ServiceReponse<List<GetCharacterDto>>>> GetList ()
        {
            return Ok(await characterService.GetList());
        }
        [HttpGet("GetByID/{id}")]
        public async Task<ActionResult<ServiceReponse<Character>>> GetByID(int id)
        {
            return Ok(await characterService.GetByID(id));
        }

        [HttpPost("Post")]
        public async Task<ActionResult<ServiceReponse<List<AddCharacterDto>>>> AddCharacter(AddCharacterDto newCharacter)
        {
            return Ok(await characterService.AddCharacter(newCharacter));
        }
        [HttpPut("Put")]
        public async Task<ActionResult<ServiceReponse<GetCharacterDto>>> UpdateCharacter(UpdateCharaterDto changeCharacter)
        {
            return Ok(await characterService.UpdateCharacter(changeCharacter));
        }
        [HttpDelete("DeleteId={id}")]
        public async Task<ActionResult<ServiceReponse<GetCharacterDto>>> DeleteCharacter(int id)
        {
            return Ok(await characterService.DeleteCharacter(id));
        }
    }
}