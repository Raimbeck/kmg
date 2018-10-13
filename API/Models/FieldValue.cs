using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("FieldValues")]
    public class FieldValue
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Value { get; set; }
        public int FieldId { get; set; }
        public Field Field { get; set; }
        public int ProductId { get; set; }
    }
}