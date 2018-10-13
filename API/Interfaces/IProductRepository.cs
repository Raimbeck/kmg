using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos.GET;
using API.Dtos.POST;
using API.Models;

namespace API.Interfaces
{
    public interface IProductRepository
    {
         Task<Product> GetProduct(int id);
         Task<IEnumerable<Product>> GetProducts();
         Task<Product> CreateProduct(PostProductDto dto);
         Task<bool> UpdateProduct(int id, PostProductDto dto);
         Task<bool> DeleteProduct(int id);
         Task<GetProductDto> GetProductDto(int id);
    }
}