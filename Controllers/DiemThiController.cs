using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiemThiController : ControllerBase
    {
        private readonly IDiemThiService _diemThiService;
        public DiemThiController(IDiemThiService diemThiService)
        {
            _diemThiService = diemThiService;
        }
        [HttpGet("GetDiems")]
        public async Task<ActionResult<ServiceReponse<List<GetDiemThi>>>> GetDiemThis()
        {
            return Ok(await _diemThiService.GetDiemThis());
        }
        [HttpPut("Add")]
        public async Task<ActionResult<ServiceReponse<List<GetDiemThi>>>> AddDiemThi(AddDiemThi addDiemThi)
        {
            return Ok(await _diemThiService.AddDiemThi(addDiemThi));
        }
    }
}