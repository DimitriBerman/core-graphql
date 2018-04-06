using System.Collections.Generic;
using System.Threading.Tasks;
using aspnetcoregraphql.Models;

namespace aspnetcoregraphql.Data
{
    public interface IVenueRepository
    {
        Task<List<Venue>> GetAllAsync();
        Task<Venue> GetAsync(int id);
        Task<Venue> AddAsync(Venue venue);
    }
}