using System.Collections.Generic;

namespace API.Dtos.POST
{
    public class PostCategoryDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }

        public List<PostFieldDto> AdditionalFields { get; set; }

        public PostCategoryDto()
        {
            AdditionalFields = new List<PostFieldDto>();
        }
    }
}