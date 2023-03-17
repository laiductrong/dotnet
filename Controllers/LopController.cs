using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LopController : ControllerBase
    {
        private readonly ILopService _lopService;
        public LopController(ILopService lopService)
        {
            _lopService = lopService;
        }
        [HttpGet("GetList")]
        public async Task<ActionResult<ServiceReponse<List<GetLop>>>> GetList(){
            return Ok(await _lopService.GetLops());
        }
        [HttpGet("GetByID={id}")]
        public async Task<ActionResult<ServiceReponse<GetLop>>> GetByID(int id){
            return Ok(await _lopService.GetLopByID(id));
        }
        [HttpPut("Put")]
        public async Task<ActionResult<ServiceReponse<List<GetLop>>>> AddLop(AddLop newLop)
        {
            return Ok(await _lopService.AddLop(newLop));
        }
        [HttpPost("Update")]
        public async Task<ActionResult<ServiceReponse<List<GetLop>>>> UpdateLop(UpdateLop newLop)
        {
            return Ok(await _lopService.UpdateLop(newLop));
        }
        [HttpDelete("Delete={id}")]
        public async Task<ActionResult<ServiceReponse<List<GetLop>>>> DeleteLop(int id)
        {
            return Ok(await _lopService.DeleteLop(id));
        }
    }
}