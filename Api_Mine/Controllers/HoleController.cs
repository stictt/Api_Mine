using Api_Mine.Models.API_Data_Model;
using Api_Mine.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api_Mine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoleController : Controller
    {
        private HoleService _holeService;
        public HoleController(HoleService holeService)
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
            return await _holeService.GetHole(id);
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
            return await _holeService.DeleteHole(id);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutHole(int id, EditHoleDTO editHoleDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("BadRequest");
            }
            return await _holeService.UpdateHole(editHoleDTO, id);
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PostHole(EditHoleDTO editHoleDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("BadRequest");
            }
            return await _holeService.AddHole(editHoleDTO);
        }
    }
}
