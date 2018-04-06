using aspnetcoregraphql.Data;
using GraphQL.Types;

namespace aspnetcoregraphql.Models
{
    public class MusicStoreMutation : ObjectGraphType
    {
        public MusicStoreMutation(IVenueRepository venueRepository) {

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
        }
    }
}