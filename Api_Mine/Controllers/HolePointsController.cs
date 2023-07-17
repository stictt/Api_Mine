using Api_Mine.Models.API_Data_Model;
using Api_Mine.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api_Mine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolePointsController : Controller
    {
        private HolePointsService _holeService;
        public HolePointsController(HolePointsService holeService)
        {
            _holeService = holeService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetHole(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("BadRequest");
            }
            return await _holeService.GetHolePoints(id);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteHole(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("BadRequest");
            }
            return await _holeService.DeleteHolePoints(id);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutHole(int id, EditHolePointsDTO editHoleDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("BadRequest");
            }
            return await _holeService.UpdateHolePoints(editHoleDTO, id);
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PostHole(EditHolePointsDTO editHoleDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("BadRequest");
            }
            return await _holeService.AddHolePoints(editHoleDTO);
        }
    }
}

