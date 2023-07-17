using Api_Mine.Infrastructure.Interfaces;
using Api_Mine.Models.API_Data_Model;
using Api_Mine.Models.Business_Logic;
using Api_Mine.Models.Data_Access;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Mine.Services
{
    public class HoleService
    {
        private IDatabaseService<HoleDatabaseModel> _databaseService { get; set; }
        private IDatabaseService<DrillBlockDatabaseModel> _databaseDrillBlock { get; set; }
        private MapService _mapService { get; set; }
        private ErrorHandlingService _errorHandlingService { get; set; }
        public HoleService(IDatabaseService<HoleDatabaseModel> database,
            MapService mapService,
            ErrorHandlingService errorHandlingService,
            IDatabaseService<DrillBlockDatabaseModel> databaseDrillBlock)
        {
            _databaseService = database;
            _mapService = mapService;
            _errorHandlingService = errorHandlingService;
            _databaseDrillBlock = databaseDrillBlock;
        }

        public async Task<IActionResult> GetHole(int id)
        {
            try
            {
                var hole = await _databaseService.Get(id);
                return new OkObjectResult(_mapService.MapBase<HoleDatabaseModel, HoleDTO>(hole));
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

        public async Task<IActionResult> DeleteHole(int id)
        {
            try
            {
                var hole = await _databaseService.Delete(id);
                return new OkObjectResult("Ok");
            }
            catch (ArgumentNullException ex)
            {
                return new NotFoundObjectResult("NotFound");
            }
            catch (DbUpdateException ex)
            {
                var errorMessage = _errorHandlingService.HoleErrorHandling(id);
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

        public async Task<IActionResult> AddHole(EditHoleDTO holeDTO)
        {
            try
            {
                if (!await IsExistsDrillBlock(holeDTO.DrillBlockDatabaseModelId))
                {
                    return new NotFoundObjectResult("DrillBlock NotFound");
                }
                var dataBaseModel = _mapService.MapBase<EditHoleDTO, HoleDatabaseModel>(holeDTO);
                var hole = await _databaseService.Add(dataBaseModel);
                var modelDTO = _mapService.MapBase<HoleDatabaseModel, HoleDTO>(hole);
                return new OkObjectResult(modelDTO);
            }
            catch (Exception ex)
            {
                var result = new ObjectResult("Error");
                result.StatusCode = 500;
                return result;
            }
        }

        public async Task<IActionResult> UpdateHole(EditHoleDTO holeDTO, int id)
        {
            try
            {
                if (!await IsExistsDrillBlock(holeDTO.DrillBlockDatabaseModelId))
                {
                    return new NotFoundObjectResult("DrillBlock NotFound");
                }

                var dataBaseModel = _mapService.MapBase<EditHoleDTO, HoleDatabaseModel>(holeDTO);
                dataBaseModel.Id = id;
                var hole = await _databaseService.Update(dataBaseModel);
                var modelDTO = _mapService.MapBase<HoleDatabaseModel, HoleDTO>(hole);
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
                var item = await _databaseDrillBlock.Get(id);
                return item != null;
            }
            catch (ArgumentNullException ex)
            {
                return false;
            }
        }
    }
}
