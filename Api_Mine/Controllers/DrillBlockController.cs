using Api_Mine.Models.API_Data_Model;
using Api_Mine.Models.Business_Logic;
using Api_Mine.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api_Mine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrillBlockController : Controller
    {
        private DrillBlockService _drillBlockService;
        public DrillBlockController(DrillBlockService drillBlockService)
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
            return await _drillBlockService.GetDrillBlock(id);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteDrillBlock(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("BadRequest");
            }
            return await _drillBlockService.DeleteDrillBlock(id);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutDrillBlock(int id, EditDrillBlockDTO editDrill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("BadRequest");
            }
            return await _drillBlockService.UpdateDrillBlock(editDrill,id);
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostDrillBlock(EditDrillBlockDTO editDrill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("BadRequest");
            }
            return await _drillBlockService.AddDrillBlock(editDrill);
        }
    }
}
