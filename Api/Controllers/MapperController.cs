using Microsoft.AspNetCore.Mvc;
using MigrateMap.Bal.Implementation;
using MigrateMap.Bal.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapperController : ControllerBase
    {
        public IMapperBal _mapperBal { get; set; }
        public MapperController(IMapperBal mapperBal)
        {
            _mapperBal = mapperBal;
        }
        [HttpGet("GetAvailbleTables")]
        public async Task<IActionResult> GetAvailbleTables()
        {
            return Ok(await _mapperBal.GetAvailableTables());
        }
        [HttpGet("GetAvailbleTableColumns")]
        public async Task<IActionResult> GetAvailbleTableColumns([FromQuery][Required(ErrorMessage = "Table name is required")] string tableName)
        {
            return Ok(await _mapperBal.GetAvailableTableColumns(tableName));
        }
    }
}
