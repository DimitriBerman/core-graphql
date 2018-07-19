using System.Linq;
using MusicStore.Data;
using GraphQL.Types;

namespace MusicStore.Models
{
    public class CategoryType : ObjectGraphType<Category>
    {
        public CategoryType(IProductRepository productRepository)
        {
            Field(x => x.Id).Description("Category id.");
            Field(x => x.Name, nullable: true).Description("Category name.");

            Field<ListGraphType<ProductType>>(
                "products", 
                resolve: context => productRepository.GetProductsWithByCategoryIdAsync(context.Source.Id).Result.ToList()
            );
        }
    }
}