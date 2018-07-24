using System.Collections.Generic;
using System.Threading.Tasks;
using MusicStore.Models;

namespace MusicStore.Data
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsAsync();
        Task<List<Product>> GetProductsWithByCategoryIdAsync(int categoryId);
        Task<Product> GetProductAsync(int id);
    }
}