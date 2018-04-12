using System.Collections.Generic;
using System.Threading.Tasks;
using MusicStore.Models;

namespace MusicStore.Data
{
    public interface ICategoryRepository
    {
        Task<List<Category>> CategoriesAsync();
        Task<Category> GetCategoryAsync(int id);
    }
}