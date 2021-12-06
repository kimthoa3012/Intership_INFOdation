using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_CF.Model
{
    public class Product
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string Decription { get; set; }
        [Range(0, double.MaxValue)]
        public double Price { get; set; }


        public int? CataID { get; set; }
        [ForeignKey("CataID")]
        public Catalog Catalog { get; set; }
    }
}
