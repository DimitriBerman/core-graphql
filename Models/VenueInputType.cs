using GraphQL.Types;

public class VenueInputType : InputObjectGraphType
{
    public VenueInputType()
    {
        Name = "VenueInput";
        Field<NonNullGraphType<StringGraphType>>("name");
        Field<StringGraphType>("description");
    }
}