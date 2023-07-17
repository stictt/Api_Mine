using Api_Mine.Models.Common;
using Api_Mine.Models.Data_Access;
using Microsoft.EntityFrameworkCore;

namespace Api_Mine.Services
{
    public class ErrorHandlingService
    {
        private ApiContext _context;
        public ErrorHandlingService(ApiContext context)
        {
            _context = context;
        }

        public DrillBlockErrorMessage DrillBlockErrorHandling(int drillBlockId)
        {
            DrillBlockErrorMessage result = new DrillBlockErrorMessage();

            result.DrillBlockPointsId = _context
                .DrillBlockPointsDatabaseModels.AsNoTracking()
                .Where(x => x.DrillBlockId == drillBlockId)
                .Select(x => x.Id)
                .ToList();

            result.HolesId = _context
                .HoleDatabaseModels.AsNoTracking()
                .Where(x => x.DrillBlockDatabaseModelId == drillBlockId)
                .Select(x => x.Id)
                .ToList();

            return result;
        }

        public HoleErrorMessage HoleErrorHandling(int holeId)
        {
            HoleErrorMessage result = new HoleErrorMessage();

            result.HolePointsId = _context
                .HolePointsDatabaseModels.AsNoTracking()
                .Where(x => x.HoleId == holeId)
                .Select(x => x.Id)
                .ToList();

            return result;
        }
    }
}
