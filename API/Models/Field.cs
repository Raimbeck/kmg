using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Extensions;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace API.Models
{
    [Table("Fields")]
    public class Field
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Category Category { get; set; } 
        public int CategoryId { get; set; }
        public ICollection<FieldValue> FieldValues { get; set; }

        public Field()
        {
            FieldValues = new Collection<FieldValue>();
        }
    }
}