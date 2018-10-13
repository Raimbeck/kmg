using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Dtos.POST;
using API.Models;

namespace API.Interfaces
{
    public interface IFieldValueRepository
    {
         Task<bool> AddOrUpdateValues(int productId, List<PostFieldDto> fieldsDto);
         Task<FieldValue> GetFieldValueById(int productId, int fieldId);
         Task<IEnumerable<FieldValue>> GetFieldValues(int productId, List<int> ids = null);
    }
}