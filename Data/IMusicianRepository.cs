using System.Collections.Generic;
using System.Threading.Tasks;
using aspnetcoregraphql.Models;

namespace aspnetcoregraphql.Data
{
    public interface IMusicianRepository
    {
        Task<List<Musician>> GetAllAsync();
        Task<Musician> GetAsync(int id);
    }
}