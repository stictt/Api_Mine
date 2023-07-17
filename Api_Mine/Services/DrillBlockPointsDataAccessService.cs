using Api_Mine.Infrastructure.Interfaces;
using Api_Mine.Models.Data_Access;
using Microsoft.EntityFrameworkCore;

namespace Api_Mine.Services
{
    public class DrillBlockPointsDataAccessService : IDatabaseService<DrillBlockPointsDatabaseModel>
    {

        private ApiContext _context;
        public DrillBlockPointsDataAccessService(ApiContext context)
        {
            _context = context;
        }

        public async Task<DrillBlockPointsDatabaseModel> Add(DrillBlockPointsDatabaseModel data)
        {
            await _context.DrillBlockPointsDatabaseModels.AddAsync(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<DrillBlockPointsDatabaseModel> Delete(int id)
        {
            var blockPoints = await _context.DrillBlockPointsDatabaseModels
                .FirstOrDefaultAsync(x => x.Id == id);

            if (blockPoints == null) { throw new ArgumentNullException(); }

            _context.DrillBlockPointsDatabaseModels.Remove(blockPoints);
            await _context.SaveChangesAsync();
            return blockPoints;
        }

        public async Task<DrillBlockPointsDatabaseModel> Get(int id)
        {
            var blockPoints = await _context.DrillBlockPointsDatabaseModels
                .Include(x=>x.Sequence)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (blockPoints == null) { throw new ArgumentNullException(); }
            return blockPoints;
        }

        public async Task<DrillBlockPointsDatabaseModel> Update(DrillBlockPointsDatabaseModel data)
        {
            var blockPoints = await _context.DrillBlockPointsDatabaseModels
                .Include(x=>x.Sequence)
                .FirstOrDefaultAsync(x => x.Id == data.Id);

            if (blockPoints == null) { throw new ArgumentNullException(); }

            _context.Entry(blockPoints).CurrentValues.SetValues(data);
            blockPoints.Sequence = data.Sequence;
            await _context.SaveChangesAsync();
            return data;
        }
    }
}
