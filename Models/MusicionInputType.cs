using GraphQL.Types;

public class MusicianInputType : InputObjectGraphType
{
    public MusicianInputType()
    {
        Name = "MusicianInput";
        Field<NonNullGraphType<StringGraphType>>("name");
        Field<StringGraphType>("email");
        Field<StringGraphType>("address");
        Field<StringGraphType>("zone");
        Field<StringGraphType>("notes");
        Field<StringGraphType>("Genres");
        Field<StringGraphType>("description");
        Field<StringGraphType>("arrangement");
    }
}