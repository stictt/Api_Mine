using Api_Mine.Infrastructure.Interfaces;
using Api_Mine.Models.API_Data_Model;
using Api_Mine.Models.Data_Access;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Mine.Services
{
    public class HolePointsService
    {
        private IDatabaseService<HolePointsDatabaseModel> _databaseService { get; set; }
        private IDatabaseService<HoleDatabaseModel> _databaseHole { get; set; }
        private MapService _mapService { get; set; }
        public HolePointsService(IDatabaseService<HolePointsDatabaseModel> database,
            MapService mapService,
            IDatabaseService<HoleDatabaseModel> databaseHole)
        {
            _databaseService = database;
            _mapService = mapService;
            _databaseHole = databaseHole;
        }

        public async Task<IActionResult> GetHolePoints(int id)
        {
            try
            {
                var holePoints = await _databaseService.Get(id);
                return new OkObjectResult(_mapService.MapBase<HolePointsDatabaseModel, HolePointsDTO>(holePoints));
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

        public async Task<IActionResult> DeleteHolePoints(int id)
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
            catch (Exception ex)
            {
                var result = new ObjectResult("Error");
                result.StatusCode = 500;
                return result;
            }
        }

        public async Task<IActionResult> AddHolePoints(EditHolePointsDTO holeDTO)
        {
            try
            {
                if (!await IsExistsHole(holeDTO.HoleId))
                {
                    return new NotFoundObjectResult("Hole NotFound");
                }

                var dataBaseModel = _mapService.MapBase<EditHolePointsDTO, HolePointsDatabaseModel>(holeDTO);
                var hole = await _databaseService.Add(dataBaseModel);
                var modelDTO = _mapService.MapBase<HolePointsDatabaseModel, HolePointsDTO>(hole);
                return new OkObjectResult(modelDTO);
            }
            catch (Exception ex)
            {
                var result = new ObjectResult("Error");
                result.StatusCode = 500;
                return result;
            }
        }

        public async Task<IActionResult> UpdateHolePoints(EditHolePointsDTO holeDTO, int id)
        {
            try
            {
                if (!await IsExistsHole(holeDTO.HoleId))
                {
                    return new NotFoundObjectResult("Hole NotFound");
                }

                var dataBaseModel = _mapService.MapBase<EditHolePointsDTO, HolePointsDatabaseModel>(holeDTO);
                dataBaseModel.Id = id;
                var hole = await _databaseService.Update(dataBaseModel);
                var modelDTO = _mapService.MapBase<HolePointsDatabaseModel, HolePointsDTO>(hole);
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

        private async Task<bool> IsExistsHole(int id)
        {
            try
            {
                var item = await _databaseHole.Get(id);
                return item != null;
            }
            catch (ArgumentNullException ex)
            {
                return false;
            }
        }
    }
}
