using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MigrateMap.Bal.Interfaces;
using MigrateMap.Bal.Models.Request;
using MigrateMap.Bal.Models.Response;
using System.ComponentModel.DataAnnotations;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorporationController : ControllerBase
    {

        private ICorporationService _corpServ;
        public CorporationController(ICorporationService corpServ)
        {
            _corpServ = corpServ;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            return Ok(await _corpServ.GetAllCorporations());
        }

        [HttpGet("GetCorporationById")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCorporationById([FromQuery] [Required(ErrorMessage ="CorporationId is required")] int corporationId)
        {
            return Ok(await _corpServ.GetCorporationById(corporationId));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] BaseCorporationResponse corp)
        {
            await _corpServ.CreateCorporation(corp);
            return Ok();
        }

        [HttpPost("UpdateCorporation")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateCorporation([FromBody] CorporationRequest corp)
        {
            await _corpServ.UpdateCorporation(corp);
            return Ok();
        }
    }
}
