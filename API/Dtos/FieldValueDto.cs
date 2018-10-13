using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class FieldValueDto
    {
        public int Id { get; set; }

        [Required]
        public string Value { get; set; }
        public int FieldId { get; set; }
        public int ProductId { get; set; }
    }
}