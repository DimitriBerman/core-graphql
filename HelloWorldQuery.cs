using System;
using GraphQL.Types;

public class HelloWorldQuery : ObjectGraphType
{
    public HelloWorldQuery()
    {
        Field<StringGraphType>(
            name: "hello",
            resolve: context => "world"
        );

        Field<StringGraphType>(
            name: "howdy",
            resolve: context => "universe"
        );

        Field<StringGraphType>(
            name: "ticks",
            resolve: context => DateTime.Now.Ticks.ToString()
        );

    }
}