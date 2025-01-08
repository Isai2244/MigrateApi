using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MigrateMap.Bal.Interfaces;
using MigrateMap.Bal.Models.Request;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadMapDocController : ControllerBase
    {
        private IUploadMapDocService _mapDocServ;
        public UploadMapDocController(IUploadMapDocService corpServ)
        {
            _mapDocServ = corpServ;
        }

        [HttpPost("SaveMapDoc")]
        [AllowAnonymous]
        public async Task<IActionResult> SaveMapDoc([FromBody] MapDocRequest corp)
        {
            await _mapDocServ.SaveMapDoc(corp);
            return Ok();
        }
        [HttpPost("UpdateMapDoc")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateMapDoc([FromBody] MapDocRequest corp)
        {
            await _mapDocServ.UpdateMapDoc(corp);
            return Ok();
        }

    }
}
