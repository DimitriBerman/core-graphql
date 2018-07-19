using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicStore.Data.EntityFramework;
using MusicStore.Models;

namespace MusicStore.Data
{
    public class MusicianEFRepository : IMusicianRepository
    {
        private MusicStoreDbContext _db { get; set; }

        public MusicianEFRepository(MusicStoreDbContext db)
        {
            _db = db;
        }

        public Task<Musician> GetAsync(int id)
        {
            return _db.Musicians.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<Musician>> GetAllAsync()
        {
            return _db.Musicians.ToListAsync();
        }

        public async Task<Musician> AddAsync(Musician musician)
        {
            await _db.Musicians.AddAsync(musician);
            await _db.SaveChangesAsync();
            return await GetAsync(musician.Id);
        }
    }
}