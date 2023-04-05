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
        [HttpGet("GetDiem")]
        public async Task<ActionResult<ServiceReponse<List<GetDiemThi>>>> GetDiemThi(int idSV, int idMH)
        {
            return Ok(await _diemThiService.GetDiemThi(idSV, idMH));
        }
        [HttpGet("GetDiemBySV={idSV}")]
        public async Task<ActionResult<ServiceReponse<List<GetDiemThi>>>> GetDiemThiBySV(int idSV)
        {
            return Ok(await _diemThiService.GetDiemThiBySV(idSV));
        }
        [HttpGet("GetDiemByMH={idMH}")]
        public async Task<ActionResult<ServiceReponse<List<GetDiemThi>>>> GetDiemThiByMH(int idMH)
        {
            return Ok(await _diemThiService.GetDiemThiByMH(idMH));
        }
        [HttpPut("Add")]
        public async Task<ActionResult<ServiceReponse<List<GetDiemThi>>>> AddDiemThi(AddDiemThi addDiemThi)
        {
            return Ok(await _diemThiService.AddDiemThi(addDiemThi));
        }
        [HttpPost("Update")]
        public async Task<ActionResult<ServiceReponse<List<GetDiemThi>>>> UpdateDiemThi(UpdateDiemThi updateDiemThi)
        {
            return Ok(await _diemThiService.UpdateDiemThi(updateDiemThi));
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult<ServiceReponse<List<GetDiemThi>>>> DeleteDiemThi(UpdateDiemThi updateDiemThi)
        {
            return Ok(await _diemThiService.DeleteDiemThi(updateDiemThi));
        }
    }
}