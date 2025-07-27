using NZWalks.API.Models.Dmain;

namespace NZWalks.API.Repositories
{
    public interface IWalkRepository
    {

        Task<Walks> CreateAsync(Walks walks);

         Task<List<Walks>>GetAllAsync();
    }
}
