using aspnetcoregraphql.Data;
using GraphQL.Types;

namespace aspnetcoregraphql.Models
{
    public class VenueType : ObjectGraphType<Venue>
    {
        public VenueType()
        {
            Field(x => x.Id).Description("Venue id.");
            Field(x => x.Name).Description("Venue name.");
            Field(x => x.Email).Description("Venue email.");
            Field(x => x.Address).Description("Venue Physical Address.");
            Field(x => x.Arrangement).Description("Venue Arrangement.");
            Field(x => x.Zone).Description("Venue Zone.");
            Field(x => x.ContactName).Description("Contact Name.");
            Field(x => x.Notes).Description("User Notes.");
            Field(x => x.Description, nullable: true).Description("Venue Description (optional).");
            Field(x => x.TechnicalRider, nullable: true).Description("Technical Rider (optional).");
        }
    }
}