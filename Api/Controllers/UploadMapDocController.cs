using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MigrateMap.Bal.Interfaces;
using MigrateMap.Bal.Models.Request;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text.Json;

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
        public async Task<IActionResult> SaveMapDoc([FromBody] JsonElement request)
        {
            if (request.ValueKind == JsonValueKind.Array)
            {
                try
                {
                    // Handle array payload
                    var batchRequests = JsonConvert.DeserializeObject<List<MapDocRequest>>(request.GetRawText());
                    await _mapDocServ.SaveMapDoc(batchRequests);
                    return Ok("Batch save operation completed successfully.");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error processing batch request: {ex.Message}");
                }
            }
            else if (request.ValueKind == JsonValueKind.Object)
            {
                try
                {
                    // Handle single payload
                    var singleRequest = JsonConvert.DeserializeObject<MapDocRequest>(request.GetRawText());
                    await _mapDocServ.SaveMapDoc(singleRequest);
                    return Ok("Single save operation completed successfully.");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error processing single request: {ex.Message}");
                }
            }
            else
            {
                return BadRequest("Invalid request format. Expected a single object or an array.");
            }
        }



        [HttpPost("UpdateMapDoc")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateMapDoc([FromBody] JsonElement request)
        {
            try
            {
                object parsedRequest;

                // Determine if the input JSON is a single object or an array
                if (request.ValueKind == JsonValueKind.Object)
                {
                    // Deserialize a single object
                    parsedRequest = JsonConvert.DeserializeObject<MapDocRequest>(request.GetRawText());
                }
                else if (request.ValueKind == JsonValueKind.Array)
                {
                    // Deserialize an array of objects
                    parsedRequest = JsonConvert.DeserializeObject<List<MapDocRequest>>(request.GetRawText());
                }
                else
                {
                    return BadRequest("Invalid request format. Expected a single object or an array.");
                }

                // Pass the parsed request to the service
                await _mapDocServ.UpdateMapDoc(parsedRequest);

                return Ok("Update operation completed successfully.");
            }
            catch (Newtonsoft.Json.JsonException ex)
            {
                return BadRequest($"Invalid JSON format: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error processing update request: {ex.Message}");
            }
        }


    }
}
