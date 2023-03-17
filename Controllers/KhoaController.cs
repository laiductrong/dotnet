using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KhoaController : ControllerBase
    {
        private readonly IKhoaService _khoaService;

        public KhoaController(IKhoaService khoaService)
        {
            _khoaService = khoaService;
        }

        [HttpGet("GetList")]
        public async Task<ActionResult<ServiceReponse<List<GetKhoa>>>> GetList()
        {
            return Ok(await _khoaService.getList());
        }

        [HttpGet("GetByID={id}")]
        public async Task<ActionResult<ServiceReponse<GetKhoa>>> GetByID(int id)
        {
            return Ok(await _khoaService.GetByID(id));
        }
        [HttpPut("Put")]
        public async Task<ActionResult<ServiceReponse<List<GetKhoa>>>> AddKhoa(AddKhoa newKhoa)
        {
            return Ok(await _khoaService.AddKHoa(newKhoa));
        }
        [HttpPost("Post")]
        public async Task<ActionResult<ServiceReponse<List<GetKhoa>>>> UpdateKhoa(UpdateKhoa newKhoa)
        {
            return Ok(await _khoaService.UpdateKhoa(newKhoa));
        }
        [HttpDelete("Delete={id}")]
        public async Task<ActionResult<ServiceReponse<List<GetKhoa>>>> DeleteKhoa(int id)
        {
            return Ok(await _khoaService.DeleteKhoa(id));
        }
    }
}