using MusicStore.Data;
using GraphQL.Types;

namespace MusicStore.Models
{
    public class MusicianType : ObjectGraphType<Musician>
    {
        public MusicianType()
        {
            Field(x => x.Id).Description("Musician id.");
            Field(x => x.Name).Description("Musician name.");
            Field(x => x.Email).Description("Musician email.");
            Field(x => x.Address).Description("Musician Physical Address.");
            Field(x => x.Zone).Description("Musician Zone.");
            Field(x => x.Notes).Description("User Notes about Musician.");
            Field(x => x.Genres, nullable: true).Description("Musician Genres that handles.");
            Field(x => x.Description, nullable: true).Description("Musician Description (optional).");
            Field(x => x.Arrangement).Description("Musician Arrangement.");
        }
    }
}