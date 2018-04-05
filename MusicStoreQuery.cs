using aspnetcoregraphql.Data;
using GraphQL.Types;

namespace aspnetcoregraphql.Models
{
    public class MusicStoreQuery : ObjectGraphType
    {
        public MusicStoreQuery(ICategoryRepository categoryRepository, IProductRepository productRepository, 
                                IVenueRepository venueRepository, IMusicianRepository musicianRepository)
        {
            Field<CategoryType>(
                "category",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "Category id" }
                ),
                resolve: context => categoryRepository.GetCategoryAsync(context.GetArgument<int>("id")).Result
            );

            Field<ProductType>(
                "product",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "Product id" }
                ),
                resolve: context => productRepository.GetProductAsync(context.GetArgument<int>("id")).Result
            );

            Field<ListGraphType<VenueType>>(
                "venues",
                resolve: context => venueRepository.GetAllAsync().Result
            );

            Field<VenueType>(
                "venue",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "Venue id" }
                ),
                resolve: context => venueRepository.GetAsync(context.GetArgument<int>("id")).Result
            );

            Field<ListGraphType<MusicianType>>(
                "musicians",
                resolve: context => musicianRepository.GetAllAsync().Result
            );

            Field<MusicianType>(
                "musician",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "Musician id" }
                ),
                resolve: context => musicianRepository.GetAsync(context.GetArgument<int>("id")).Result
            );
        }
    }
}