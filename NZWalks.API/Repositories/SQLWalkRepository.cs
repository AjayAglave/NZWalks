using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Dmain;

namespace NZWalks.API.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext dbContext;

        public SQLWalkRepository(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Walks> CreateAsync(Walks walks)
        {
          await dbContext.Walks.AddAsync(walks);
            await dbContext.SaveChangesAsync();
            return walks;
        }

      

        public async Task<List<Walks>> GetAllAsync()
        {
            var existingWalk = await dbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();
          
            return existingWalk;
        }

        public async Task <Walks?> GetByIdAsync(Guid id)
        {
           
            return await dbContext.Walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walks?> UpdateAsync(Guid id,Walks walks)
        {
            var existingWalk = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);  
            if (existingWalk == null)
            {
                return null;
            }
            existingWalk.Name=walks.Name;
            existingWalk.Description=walks.Description;
            existingWalk.WalkImageUrl=walks.WalkImageUrl;
            existingWalk.DifficultyId=walks.DifficultyId;
            existingWalk.RegionId=walks.RegionId;

            await dbContext.SaveChangesAsync();
            return existingWalk;
        }

        public async  Task<Walks?> DeleteAsync(Guid id)
        {
            var existingWalk = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if(existingWalk == null)
            {
                return null;
            }
            dbContext.Walks.Remove(existingWalk);
            await dbContext.SaveChangesAsync();
            return existingWalk;
        }
    }
}
