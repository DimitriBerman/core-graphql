using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicStore.Data.EntityFramework;
using MusicStore.Models;
using Microsoft.EntityFrameworkCore;

namespace MusicStore.Data
{
    public class VenueEFRepository : IVenueRepository
    {
        private MusicStoreDbContext _db { get; set; }

        public VenueEFRepository(MusicStoreDbContext db) { 
            _db = db;
        }

        public Task<Venue> GetAsync(int id)
        {
            return _db.Venues.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<Venue>> GetAllAsync()
        {
            return _db.Venues.ToListAsync();
        }

        public async Task<Venue> AddAsync(Venue venue)
        {
            await _db.Venues.AddAsync(venue);
            await _db.SaveChangesAsync();
            return await GetAsync(venue.Id);
        }
    }
}