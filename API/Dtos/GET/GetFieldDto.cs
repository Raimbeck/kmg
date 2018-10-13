using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos.GET
{
    public class GetFieldDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public FieldValueDto FieldValue { get; set; }
    }
}