using Api_Mine.Infrastructure.Interfaces;
using Api_Mine.Models.Data_Access;
using Microsoft.EntityFrameworkCore;

namespace Api_Mine.Services
{
    public class DrillBlockDataAccessService : IDatabaseService<DrillBlockDatabaseModel>
    {
        private ApiContext _context;
        public DrillBlockDataAccessService(ApiContext context)
        {
            _context = context;
        }

        public async Task<DrillBlockDatabaseModel> Add(DrillBlockDatabaseModel data)
        {
            await _context.DrillBlockDatabaseModels.AddAsync(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<DrillBlockDatabaseModel> Delete(int id)
        {
            var block = await _context.DrillBlockDatabaseModels
                .FirstOrDefaultAsync(x => x.Id == id);

            if (block == null) { throw new ArgumentNullException(); }

            _context.DrillBlockDatabaseModels.Remove(block);
            await _context.SaveChangesAsync();
            return block;
        }

        public async Task<DrillBlockDatabaseModel> Get(int id)
        {
            var block = await _context.DrillBlockDatabaseModels
                .FirstOrDefaultAsync(x => x.Id == id);

            if (block == null) { throw new ArgumentNullException(); }
            return block;
        }

        public async Task<DrillBlockDatabaseModel> Update(DrillBlockDatabaseModel data)
        {
            var block = await _context.DrillBlockDatabaseModels
                .FirstOrDefaultAsync(x => x.Id == data.Id);

            if (block == null) { throw new ArgumentNullException(); }

            _context.Entry(block).CurrentValues.SetValues(data);
            await _context.SaveChangesAsync();
            return data;
        }
    }
}
