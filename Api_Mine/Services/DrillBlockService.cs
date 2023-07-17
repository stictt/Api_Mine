using Api_Mine.Infrastructure.Interfaces;
using Api_Mine.Models.API_Data_Model;
using Api_Mine.Models.Data_Access;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Mine.Services
{
    public class DrillBlockService
    {
        private IDatabaseService<DrillBlockDatabaseModel> _databaseService { get; set; }
        private MapService _mapService { get; set; }
        private ErrorHandlingService _errorHandlingService { get; set; }
        public DrillBlockService(IDatabaseService<DrillBlockDatabaseModel> database,
            MapService mapService,
            ErrorHandlingService errorHandlingService) 
        { 
            _databaseService = database;
            _mapService = mapService;
            _errorHandlingService = errorHandlingService;
        }

        public async Task<IActionResult> GetDrillBlock(int id)
        {
            try
            {
                var block = await _databaseService.Get(id);
                return new OkObjectResult(_mapService.MapBase<DrillBlockDatabaseModel, DrillBlockDTO>(block));
            }
            catch (ArgumentNullException ex)
            {
                return new NotFoundObjectResult("NotFound");
            }
            catch (Exception ex)
            {
                var result = new ObjectResult("Error");
                result.StatusCode = 500;
                return result;
            }
        }

        public async Task<IActionResult> DeleteDrillBlock(int id)
        {
            try
            {
                var block = await _databaseService.Delete(id);
                return new OkObjectResult("Ok");
            }
            catch (ArgumentNullException ex)
            {
                return new NotFoundObjectResult("NotFound");
            }
            catch (DbUpdateException ex)
            {
                var errorMessage = _errorHandlingService.DrillBlockErrorHandling(id);
                errorMessage.Message = "It is forbidden to delete an object that has dependent entities.";
                return new ObjectResult(errorMessage) { StatusCode = 403 };
            }
            catch (Exception ex)
            {
                var result = new ObjectResult("Error");
                result.StatusCode = 500;
                return result;
            }
        }

        public async Task<IActionResult> AddDrillBlock(EditDrillBlockDTO drillBlock)
        {
            try
            {
                var dataBaseModel = _mapService.MapBase<EditDrillBlockDTO, DrillBlockDatabaseModel>(drillBlock);
                var block = await _databaseService.Add(dataBaseModel);
                var modelDTO = _mapService.MapBase<DrillBlockDatabaseModel, DrillBlockDTO>(block);
                return new OkObjectResult(modelDTO);
            }
            catch (Exception ex)
            {
                var result = new ObjectResult("Error");
                result.StatusCode = 500;
                return result;
            }
        }

        public async Task<IActionResult> UpdateDrillBlock(EditDrillBlockDTO drillBlock,int id)
        {
            try
            {
                var dataBaseModel = _mapService.MapBase<EditDrillBlockDTO, DrillBlockDatabaseModel>(drillBlock);
                dataBaseModel.Id = id;
                var block = await _databaseService.Update(dataBaseModel);
                var modelDTO = _mapService.MapBase<DrillBlockDatabaseModel, DrillBlockDTO>(block);
                return new OkObjectResult(modelDTO);
            }
            catch (ArgumentNullException ex)
            {
                return new NotFoundObjectResult("NotFound");
            }
            catch (Exception ex)
            {
                var result = new ObjectResult("Error");
                result.StatusCode = 500;
                return result;
            }
        }
    }
}
