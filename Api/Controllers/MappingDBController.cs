using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MigrateMap.Bal.Interfaces;
using MigrateMap.Bal.Models.Request;
using MigrateMap.Bal.Models.Response;
using System.ComponentModel.DataAnnotations;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MappingDBController : ControllerBase
    {

        private IMappingDBService _mapServ;
        public MappingDBController(IMappingDBService mapServ)
        {
            _mapServ = mapServ;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mapServ.GetAllMappingDB());
        }

        [HttpGet("GetCorporationById")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCorporationById([FromQuery][Required(ErrorMessage = "mappingdbid is required")] int mappingdbid)
        {
            return Ok(await _mapServ.GetMappingDBById(mappingdbid));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] BaseMappingDBResponse map)
        {
            await _mapServ.CreateMappingDB(map);
            return Ok();
        }

        [HttpPost("UpdateCorporation")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateCorporation([FromBody] MappingDBRequest map)
        {
            await _mapServ.UpdateMappingDB(map);
            return Ok();
        }
    }
}
