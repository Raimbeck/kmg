using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos.POST
{
    public class PostProductDto
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public PostCategoryDto Category { get; set; }
        public int? CategoryId { get; set; }
    }
}