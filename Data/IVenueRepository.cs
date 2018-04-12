using System.Collections.Generic;
using System.Threading.Tasks;
using MusicStore.Models;

namespace MusicStore.Data
{
    public interface IVenueRepository
    {
        Task<List<Venue>> GetAllAsync();
        Task<Venue> GetAsync(int id);
        Task<Venue> AddAsync(Venue venue);
    }
}