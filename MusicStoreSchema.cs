using System;
using GraphQL.Types;

namespace aspnetcoregraphql.Models
{
    public class MusicStoreSchema : Schema
    {
        public MusicStoreSchema(Func<Type, GraphType> resolveType)
            :base(resolveType)
        {
            Query = (MusicStoreQuery)resolveType(typeof(MusicStoreQuery));
            //Mutation = (MusicStoreMutation)resolveType(typeof(MusicStoreMutation));
            
        }
    }
}