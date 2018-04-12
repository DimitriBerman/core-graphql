using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicStore.Models;

namespace MusicStore.Data
{
    public class MusicianRepository : IMusicianRepository
    {
        private List<Musician> _Musicians;

        public MusicianRepository()
        {
            _Musicians = new List<Musician>{
                new Musician()
                {
                    Id = 1,
                    Name = "Dimi",
                    Description = "Compositor Cantante Productor Pianista",
                    Notes = "@DimiSet core",
                    Arrangement = "Paga Ra Prata",
                    Address = "Av.Caseros 3183 dto 11",
                    Email = "dimitriboccanera@gmail.com",
                    Phone = "+54 9 11 3008-3674",
                    Zone = "Parque Patricios - CABA"
                },
                new Musician()
                {
                    Id = 2,
                    Name = "Franco Donadio",
                    Description = "Guitarrista de Jazz, Compositor  Productor de IDM",
                    Notes = "Franco esta tocando en @Sexteto (referencia)",
                    Arrangement = "Franco esta dispuesto a ser invitado a eventos segun su agenda. Tambien esta dispuesto a hacer eventos pagos.",
                    Address = "Calle False 12345",
                    Email = "francodonadio@gmail.COOK",
                    Phone = "+54 11 1234-1234",
                    Zone = "Villa Ortuzar"
                }
            };
        }

        public Task<Musician> GetAsync(int id)
        {
            return Task.FromResult(_Musicians.FirstOrDefault(x => x.Id == id));
        }

        public Task<List<Musician>> GetAllAsync()
        {
            return Task.FromResult(_Musicians);
        }
    }
}