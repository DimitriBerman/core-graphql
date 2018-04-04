using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnetcoregraphql.Models;

namespace aspnetcoregraphql.Data
{
    public class VenueRepository : IVenueRepository
    {
        private List<Venue> _venues;

        public VenueRepository()
        {
            _venues = new List<Venue>{
                new Venue()
                {
                    Id = 1,
                    Name = "Eter Club",
                    Description = "Bar comodo y bien arreglado con un estilo moderno pero relajado.",
                    Notes = "@DimiSet toco el 30 de Marzo y el sonido estuvo aceptable. La Banda tocaba bien asunque el sonidista estuvo un poco flojo poruqe el Bajo no se escuchaba.",
                    Arrangement = "Al Sobre (sin gastos para los musicos) o -> <a href='https://drive.google.com/open?id=0B7BW9DSldqaLTUF2bGJBOU9zaTZ3T3FJWWhzTzV3dXk0WmRJ'Leer</a> ",
                    TechnicalRider = "https://drive.google.com/open?id=0B7BW9DSldqaLTUF2bGJBOU9zaTZ3T3FJWWhzTzV3dXk0WmRJ",
                    Address = "Av. Rivadavia 3832, C1176 CABA, Argentina",
                    Email = "eterclubmusicos@hotmail.com",
                    Phone = "+54 9 11 5376-8121",
                    ContactName = "Leandro",
                    Zone = "Villa del Parque"
                },
                new Venue()
                {
                    Id = 2,
                    Name = "Sr Duncan",
                    Description = "Bar comodo y bien arreglado con un estilo moderno pero relajado.",
                    Notes = "@DimiSet toco el 3 de Marzo y el sonido muy lindo.",
                    Arrangement = "Te comento cómo manejamos la programación en Duncan. Abrimos todos los días, a partir de las 19 hs. El lugar tiene dos salas en las que se puede cenar mientras dure la función, una con capacidad para 40 personas y la otra para 30, ambas equipadas con un sistema de sonido chico de 6 canales y 3 microfonos. Se programan eventos simultaneos en dos franjas horarias de dos horas de duración, calculando media hora para el armado, media para el ingreso de publico y levantada de pedidos y una para el espectáculo aproximadamente. La primera va de 20 a 22 hs y otra de 22.30 a 0.30 hs, y después se mantiene el formato de bar hasta el cierre. La idea del lugar es ofrecer propuestas acústicas, más que nada para cuidar el volumen por un problema que tenemos con unos vecinos así que tenemos que ser muy estrictos con eso, especialmente cuando hay percusión o caños.Los días de semana y domingos, la sala grande esta ocupada con ciclos semanales y los fines de semana se programan espectáculos con entrada a porcentaje, 70 para el artista y 30 para el lugar. Si pasan la fecha por SADAIC, primero se resta el %12 que piden ellos y despues se reparte 70-30. La sala chica se programa de miercoles a lunes y se deja a su eleccion si cobrar entrada con la misma modalidad o pasar la gorra, que queda integramente para los artistas. Si es con entrada el precio lo establecen los grupos, y pueden traer algun amigo que las cobre o las pueden cobrar los camareros en las mesas.Me gustaria dejar en claro, por experiencias que tuvimos con otros grupos y por el panorama de gente que frecuenta el lugar, que el espacio no cuenta con una convocatoria asegurada donde los grupos se presentan para la gente que pueda estar cenando en el lugar esa noche, sino que mas bien es un espacio que se ofrece para que los artistas puedan mostrarle a su publico su material. Por lo tanto, si bien nosotros colaboramos con la difusion del evento a traves de nuestras redes sociales, apuntamos a eventos que puedan garantizar una razonable convocatoria en relacion a la capacidad de las salas.En cuanto a las consumiciones, hace poco decidimos implementar una modalidad para incentivar a las bandas en la convocatoria que consiste en dos premisas.La primera es que si la convocatoria del grupo no supera un minimo de 10 personas en el caso de la sala chica y de 15 en la sala grande, no damos invitaciones sino que solo hacemos descuento para musicos del %20. Si superan ese minimo tienen invitaciones de pizza y cerveza/vino acorde a la cantidad de integrantes y despues de esas invitaciones se mantiene un %20 de descuento. La segunda, es que si cobrando entrada, venden mas de 26 en la sala chica o 36 en la grande la banda se lleva el %100 de las entradas.Si te interesa la propuesta, decime una fecha aproximada en la que les gustaria presentarse y te paso la disponibilidad de las salas. Te pido de paso, que me definas que intrumentos usan y que modalidad de arreglo prefieren.",
                    TechnicalRider = "",
                    Address = "",
                    Email = "seniorduncan@gmail.com",
                    Phone = "+54 11 4958-3633",
                    ContactName = "Juan",
                    Zone = "Almagro"
                }
            };
        }

        public Task<Venue> GetAsync(int id)
        {
            return Task.FromResult(_venues.FirstOrDefault(x => x.Id == id));
        }

        public Task<List<Venue>> GetAllAsync()
        {
            return Task.FromResult(_venues);
        }
    }
}