using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos.GET
{
    public class GetCategoryDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }

        public List<GetFieldDto> AdditionalFields { get; set; }
        public int ProductsCount { get; set; }

        public GetCategoryDto()
        {
            AdditionalFields = new List<GetFieldDto>();
        }
    }
}