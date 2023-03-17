using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GiangVienController : ControllerBase
    {
        private readonly IGiangVienService _giangVienService;
        public GiangVienController(IGiangVienService giangVienService)
        {
            _giangVienService = giangVienService;
        }
        [HttpGet("GetList")]
        public async Task<ActionResult< ServiceReponse<List<GetGiangVien>>>> GetList()
        {
            return Ok(await _giangVienService.GetGiangVien());
        }
        [HttpGet("GetByID={id}")]
        public async Task<ActionResult<ServiceReponse<GetGiangVien>>> GetByID(int id)
        {
            return Ok(await _giangVienService.GetByID(id));
        }
        [HttpPost("Post")]
        public async Task<ActionResult<ServiceReponse<List<GetGiangVien>>>> AddGiangVien(AddGiangVien newGiangVien)
        {
            return Ok(await _giangVienService.AddGiangVien(newGiangVien));
        }
        [HttpPut("updateGiangVien")]
        public async Task<ActionResult<ServiceReponse<List<GetGiangVien>>>> UpdateGiangVien(UpdateGiangVien newGiangVien)
        {
            return Ok(await _giangVienService.UpdateGiangVien(newGiangVien));
        }
        [HttpDelete("delete")]
        public async Task<ActionResult<ServiceReponse<List<GetGiangVien>>>> DeleteGiangVien(int id)
        {
            return Ok(await _giangVienService.DeleteGiangVien(id));
        }

    }
}