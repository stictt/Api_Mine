using Api_Mine.Infrastructure.Interfaces;
using Api_Mine.Models.Data_Access;
using Microsoft.EntityFrameworkCore;

namespace Api_Mine.Services
{
    public class HolePointsDataAccessService : IDatabaseService<HolePointsDatabaseModel>
    {

        private ApiContext _context;
        public HolePointsDataAccessService(ApiContext context)
        {
            _context = context;
        }

        public async Task<HolePointsDatabaseModel> Add(HolePointsDatabaseModel data)
        {
            await _context.HolePointsDatabaseModels.AddAsync(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<HolePointsDatabaseModel> Delete(int id)
        {
            var holePoints = await _context.HolePointsDatabaseModels
                .FirstOrDefaultAsync(x => x.Id == id);

            if (holePoints == null) { throw new ArgumentNullException(); }

            _context.HolePointsDatabaseModels.Remove(holePoints);
            await _context.SaveChangesAsync();
            return holePoints;
        }

        public async Task<HolePointsDatabaseModel> Get(int id)
        {
            var holePoints = await _context.HolePointsDatabaseModels
                .FirstOrDefaultAsync(x => x.Id == id);

            if (holePoints == null) { throw new ArgumentNullException(); }
            return holePoints;
        }

        public async Task<HolePointsDatabaseModel> Update(HolePointsDatabaseModel data)
        {
            var holePoints = await _context.HolePointsDatabaseModels
                .FirstOrDefaultAsync(x => x.Id == data.Id);

            if (holePoints == null) { throw new ArgumentNullException(); }

            _context.Entry(holePoints).CurrentValues.SetValues(data);
            await _context.SaveChangesAsync();
            return data;
        }
    }
}
