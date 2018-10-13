using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public ICollection<Field> AdditionalFields { get; set; }

        public ICollection<Product> Products { get; set; }

        public Category()
        {
            AdditionalFields = new Collection<Field>();
            Products = new Collection<Product>();
        }
    }
}