using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SinhVienController : ControllerBase
    {
        private readonly ISinhVienService _sinhVienService;
        public SinhVienController(ISinhVienService sinhVienService)
        {
            _sinhVienService = sinhVienService;
        }
        [HttpGet("GetSinhViens")]
        public async Task<ActionResult<ServiceReponse<List<GetSinhVien>>>> GetSinhViens()
        {
            return Ok(await _sinhVienService.GetSinhViens());
        }
        [HttpGet("GetSinhVien={id}")]
        public async Task<ActionResult<ServiceReponse<GetSinhVien>>> GetSinhVien(int id)
        {
            return Ok(await _sinhVienService.GetSinhVien(id));
        }
        [HttpPut("AddSinhVien")]
        public async Task<ActionResult<ServiceReponse<List<GetSinhVien>>>> AddSinhVien(AddSinhVien addSinhVien)
        {
            return Ok(await _sinhVienService.AddSinhVien(addSinhVien));
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult<ServiceReponse<List<GetSinhVien>>>> DeleteSinhVien (int id)
        {
            return Ok(await _sinhVienService.DeleteSinhVien(id));
        }
        [HttpPost("Update")]
        public async Task<ActionResult<ServiceReponse<List<GetSinhVien>>>> UpdateSinhVien (UpdateSinhVien updateSinhVien)
        {
            return Ok(await _sinhVienService.UpdateSinhVien(updateSinhVien));
        }
    }
}