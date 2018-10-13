using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos.GET;
using API.Dtos.POST;
using API.Models;

namespace API.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> GetCategory(int id);
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> CreateCategory(PostCategoryDto dto);
        Task<bool> UpdateCategory(int id, PostCategoryDto dto);
        Task<bool> DeleteCategory(int id, bool deleteRelatedProducts);
    }
}