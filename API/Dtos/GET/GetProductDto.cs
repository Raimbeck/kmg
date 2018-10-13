using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos.GET
{
    public class GetProductDto
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public GetCategoryDto Category { get; set; }
        public int CategoryId { get; set; }
        
    }
}