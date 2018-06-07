using MusicStore.Data;
using MusicStore.Models;
using GraphQL.Types;

namespace MusicStore.GraphQL
{
    public class MusicStoreMutation : ObjectGraphType<object>
    {
        public MusicStoreMutation(IVenueRepository venueRepository, IMusicianRepository musicianRepository) {

            Field<VenueType>(
                "createVenue",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<VenueInputType>> {Name = "venue"}
                ),
                resolve: context =>
                {
                    var venue = context.GetArgument<Venue>("venue");
                    return venueRepository.AddAsync(venue).Result;
                });

             Field<MusicianType>(
                "createMusician",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<MusicianInputType>> {Name = "musician"}
                ),
                resolve: context =>
                {
                    var musician = context.GetArgument<Musician>("musician");
                    return musicianRepository.AddAsync(musician).Result;
                });
        }
    }
}