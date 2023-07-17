using Api_Mine.Models.API_Data_Model;
using Api_Mine.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api_Mine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrillBlockPointsController : Controller
    {

        private DrillBlockPointsService _drillBlockService;
        public DrillBlockPointsController(DrillBlockPointsService drillBlockService)
        {
            _drillBlockService = drillBlockService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDrillBlock(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("BadRequest");
            }
            return await _drillBlockService.GetDrillBlockPoints(id);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteDrillBlock(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("BadRequest");
            }
            return await _drillBlockService.DeleteDrillBlockPoints(id);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutDrillBlock(int id, EditDrillBlockPointsDTO editDrill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("BadRequest");
            }
            return await _drillBlockService.UpdateDrillBlockPoints(editDrill, id);
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PostDrillBlock(EditDrillBlockPointsDTO editDrill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("BadRequest");
            }
            return await _drillBlockService.AddDrillBlockPoints(editDrill);
        }
    }
}
