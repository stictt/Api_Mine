using Api_Mine.Infrastructure.Interfaces;
using Api_Mine.Models.API_Data_Model;
using Api_Mine.Models.Data_Access;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Mine.Services
{
    public class DrillBlockPointsService
    {
        private IDatabaseService<DrillBlockPointsDatabaseModel> _databaseService { get; set; }
        private IDatabaseService<DrillBlockDatabaseModel> _databaseDrillBlock { get; set; }
        private MapService _mapService { get; set; }
        public DrillBlockPointsService(IDatabaseService<DrillBlockPointsDatabaseModel> database,
            MapService mapService,
            IDatabaseService<DrillBlockDatabaseModel> databaseDrillBlock)
        {
            _databaseService = database;
            _mapService = mapService;
            _databaseDrillBlock = databaseDrillBlock;
        }


        public async Task<IActionResult> GetDrillBlockPoints(int id)
        {
            try
            {
                var block = await _databaseService.Get(id);

                var modelDTO = _mapService.MapDrillBlockPointsDTO(block);

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

        public async Task<IActionResult> DeleteDrillBlockPoints(int id)
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
            catch (Exception ex)
            {
                var result = new ObjectResult("Error");
                result.StatusCode = 500;
                return result;
            }
        }

        public async Task<IActionResult> AddDrillBlockPoints(EditDrillBlockPointsDTO drillBlock)
        {
            try
            {
                if (!await IsExistsDrillBlock(drillBlock.DrillBlockId))
                {
                    return new NotFoundObjectResult("DrillBlock NotFound");
                }
                var dataBaseModel = _mapService.MapDrillBlockPointsDatabaseModel(drillBlock);

                var block = await _databaseService.Add(dataBaseModel);
                var modelDTO = _mapService.MapDrillBlockPointsDTO(block);

                return new OkObjectResult(modelDTO);
            }
            catch (Exception ex)
            {
                var result = new ObjectResult("Error");
                result.StatusCode = 500;
                return result;
            }
        }

        public async Task<IActionResult> UpdateDrillBlockPoints(EditDrillBlockPointsDTO drillBlock,int id)
        {
            try
            {
                if (!await IsExistsDrillBlock(drillBlock.DrillBlockId))
                {
                    return new NotFoundObjectResult("DrillBlock NotFound");
                }

                var dataBaseModel = _mapService.MapDrillBlockPointsDatabaseModel(drillBlock);

                dataBaseModel.Id = id;
                var block = await _databaseService.Update(dataBaseModel);
                var modelDTO = _mapService.MapDrillBlockPointsDTO(block);

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

        private async Task<bool> IsExistsDrillBlock(int id)
        {
            try
            {
                var item =  await _databaseDrillBlock.Get(id);
                return item != null;
            }
            catch (ArgumentNullException ex)
            {
                return false;
            }
        }
    }
}
