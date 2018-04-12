using System.Collections.Generic;
using System.Threading.Tasks;
using MusicStore.Models;

namespace MusicStore.Data
{
    public interface IMusicianRepository
    {
        Task<List<Musician>> GetAllAsync();
        Task<Musician> GetAsync(int id);
    }
}