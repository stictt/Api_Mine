using Api_Mine.Infrastructure.Interfaces;
using Api_Mine.Models.Data_Access;
using Microsoft.EntityFrameworkCore;

namespace Api_Mine.Services
{
    public class HoleDataAccessService : IDatabaseService<HoleDatabaseModel>
    {

        private ApiContext _context;
        public HoleDataAccessService(ApiContext context)
        {
            _context = context;
        }

        public async Task<HoleDatabaseModel> Add(HoleDatabaseModel data)
        {
            await _context.HoleDatabaseModels.AddAsync(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<HoleDatabaseModel> Delete(int id)
        {
            var hole = await _context.HoleDatabaseModels
                .FirstOrDefaultAsync(x => x.Id == id);

            if (hole == null) { throw new ArgumentNullException(); }

            _context.HoleDatabaseModels.Remove(hole);
            await _context.SaveChangesAsync();
            return hole;
        }

        public async Task<HoleDatabaseModel> Get(int id)
        {
            var hole = await _context.HoleDatabaseModels
                .FirstOrDefaultAsync(x => x.Id == id);

            if (hole == null) { throw new ArgumentNullException(); }
            return hole;
        }

        public async Task<HoleDatabaseModel> Update(HoleDatabaseModel data)
        {
            var hole = await _context.HoleDatabaseModels
                .FirstOrDefaultAsync(x => x.Id == data.Id);

            if (hole == null) { throw new ArgumentNullException(); }

            _context.Entry(hole).CurrentValues.SetValues(data);
            await _context.SaveChangesAsync();
            return data;
        }
    }
}
