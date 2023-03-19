using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonHocController : ControllerBase
    {
        private readonly IMonHocService _monHocService;
        public MonHocController(IMonHocService monHocService)
        {
            _monHocService = monHocService;
        }
        [HttpGet("GetMonHocs")]
        public async Task<ActionResult<ServiceReponse<List<GetMonHoc>>>> GetMonHocs()
        {
            return Ok(await _monHocService.GetMonHocs());
        }
        [HttpGet("GetMonHoc={id}")]
        public async Task<ActionResult<ServiceReponse<GetMonHoc>>> GetMonHoc(int id)
        {
            return Ok(await _monHocService.GetMonHoc(id));
        }
        [HttpPut("AddMonHoc")]
        public async Task<ActionResult<ServiceReponse<List<GetMonHoc>>>> AddMonHoc(AddMonHoc addMonHoc)
        {
            return Ok(await _monHocService.AddMonHoc(addMonHoc));
        }
        [HttpPost("UpdateMonHoc")]
        public async Task<ActionResult<ServiceReponse<List<GetMonHoc>>>> UpdateMonHoc(UpdateMonHoc updateMonHoc)
        {
            return Ok(await _monHocService.UpdateMonHoc(updateMonHoc));
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult<ServiceReponse<List<GetMonHoc>>>> DeleteMonHoc(int id)
        {
            return Ok(await _monHocService.DeleteMonHoc(id));
        }
    }
}