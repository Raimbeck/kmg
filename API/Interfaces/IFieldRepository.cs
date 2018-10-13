using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos.POST;
using API.Models;

namespace API.Interfaces
{
    public interface IFieldRepository
    {
        Task<bool> AddOrUpdateFields(Category category, List<PostFieldDto> fieldsDto);
    }
}