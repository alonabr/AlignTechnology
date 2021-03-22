using AlignTechnology.BL;
using AlignTechnology.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlignTechnology.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionController : ControllerBase
    {
        private readonly IMissionService _missionService;

        public MissionController(IMissionService missionService)
        {
            _missionService = missionService;
        }

        [HttpGet("{id}", Name = "GetMission")]
        public async Task<ActionResult<MissionDto>> Get(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return BadRequest();
                }
                var mission = await _missionService.Get(id);
                if (mission == null)
                {
                    return NotFound();
                }
                return mission;
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }
        }

        [HttpPost]
        public async Task<ActionResult<MissionDto>> Post([FromBody] MissionDto mission)
        {
            try
            {
                if (mission == null)
                {
                    return BadRequest();
                }
                var result = await _missionService.Create(mission);
                return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }
        }

        [HttpGet("counties-by-isolation")]
        public async Task<ActionResult<string>> Get()
        {
            try
            {
                var result = await _missionService.GetCountryByIsolation();
                if (String.IsNullOrEmpty(result))
                {
                    return NoContent();
                }
                return result;
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpPost("find-closet")]
        public async Task<ActionResult<string>> FindClosetMission([FromBody] AddressDto address)
        {
            try
            {
                return await _missionService.GetClosetMission(address);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }
        }
    }
}
